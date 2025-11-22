using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using static FERRY_BOOKING.Dialogs.FerryRegistrationForm;

namespace FERRY_BOOKING.DATABASE
{
    internal class FerryOwnerHelper
    {
        private readonly DatabaseHelper db = new DatabaseHelper();

        public bool RegisterFerryOwner(string firstName, string lastName, string companyName, string email, string password)
        {
            try
            {
                // Hash the password and get as byte array
                byte[] passwordHash = HashPassword(password);

                string query = @"INSERT INTO Users (FirstName, LastName, CompanyName, Email, PasswordHash, Role) 
                               VALUES (@FirstName, @LastName, @CompanyName, @Email, @PasswordHash, 'FerryOwner')";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", firstName),
                    new SqlParameter("@LastName", lastName),
                    new SqlParameter("@CompanyName", companyName),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@PasswordHash", passwordHash) // Now passing byte[] instead of string
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Registration failed: " + ex.Message);
            }
        }

        // Password hashing method - returns byte array
        private byte[] HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        // Method to check if email already exists
        public bool EmailExists(string email)
        {
            try
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email", email)
                };

                var result = db.ExecuteScalar(query, parameters);
                return result != null && Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking email: " + ex.Message);
            }
        }

        // Method to validate ferry owner login

        // Add this method to FerryOwnerHelper.cs
        public string ValidateLoginWithRole(string email, string password)
        {
            try
            {
                string query = "SELECT Role FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash AND IsActive = 1";

                byte[] passwordHash = HashPassword(password);
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Email", email),
            new SqlParameter("@PasswordHash", passwordHash)
                };

                var result = db.ExecuteScalar(query, parameters);
                return result?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                throw new Exception("Login validation error: " + ex.Message);
            }
        }



        // In FerryOwnerHelper.cs - add this method
        public (int UserID, string FirstName, string LastName, string CompanyName) GetUserDetailsByEmail(string email)
        {
            try
            {
                string query = "SELECT UserID, FirstName, LastName, CompanyName FROM Users WHERE Email = @Email AND Role = 'FerryOwner'";

                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (
                                    Convert.ToInt32(reader["UserID"]),
                                    reader["FirstName"].ToString(),
                                    reader["LastName"].ToString(),
                                    reader["CompanyName"].ToString()
                                );
                            }
                        }
                    }
                }

                // Return defaults if no user found
                return (0, "", "", "");
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user details: " + ex.Message);
            }
        }






        public bool RegisterFerry(
            string ferryName,
            string ferryCode,
            int totalFloors,
            int totalCapacity,
            List<FloorLayout> floors,
            byte[] coFileBytes,
            byte[] vrFileBytes,
            byte[] scFileBytes,
            byte[] idFileBytes,
            byte[] poFileBytes,
            byte[] fpFileBytes,
            int ownerID
        )
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert Ferry
                    int ferryID;
                    using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Ferry (FerryCode, FerryName, TotalFloors, TotalCapacity, OwnerID)
                OUTPUT INSERTED.FerryID
                VALUES (@code, @name, @floors, @capacity, @owner)", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@code", ferryCode);
                        cmd.Parameters.AddWithValue("@name", ferryName);
                        cmd.Parameters.AddWithValue("@floors", totalFloors);
                        cmd.Parameters.AddWithValue("@capacity", totalCapacity);
                        cmd.Parameters.AddWithValue("@owner", ownerID);

                        ferryID = (int)cmd.ExecuteScalar();
                    }

                    // Insert Floor Layouts (NO PRICE)
                    foreach (var f in floors)
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO FerryFloor (FerryID, FloorNumber, Rows, Columns)
                    VALUES (@fid, @num, @rows, @cols)", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@fid", ferryID);
                            cmd.Parameters.AddWithValue("@num", f.FloorNumber);
                            cmd.Parameters.AddWithValue("@rows", f.Rows);
                            cmd.Parameters.AddWithValue("@cols", f.Columns);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Insert Documents
                    using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO FerryDocuments (FerryID, COFile, VRFile, SCFile, IDFile, POFile, FPFile)
                VALUES (@fid, @co, @vr, @sc, @id, @po, @fp)", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@fid", ferryID);
                        cmd.Parameters.AddWithValue("@co", coFileBytes);
                        cmd.Parameters.AddWithValue("@vr", vrFileBytes);
                        cmd.Parameters.AddWithValue("@sc", scFileBytes);
                        cmd.Parameters.AddWithValue("@id", idFileBytes);
                        cmd.Parameters.AddWithValue("@po", poFileBytes);
                        cmd.Parameters.AddWithValue("@fp", fpFileBytes);

                        cmd.ExecuteNonQuery();
                    }

                    // COMMIT
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }



        public int GetUserIDByEmail(string email)
        {
            string query = "SELECT UserID FROM Users WHERE Email = @Email";

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public DataTable LoadFerriesForOwner(int OwnerID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT FerryID, FerryName FROM Ferry WHERE OwnerID = @OwnerID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OwnerID", OwnerID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading ferries: " + ex.Message);
            }

            return dt;
        }


        public bool AddRouteToFerry(int ferryID, string origin, string destination, decimal distance, TimeSpan duration)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert route if it doesn't exist
                    int routeID;
                    using (SqlCommand cmd = new SqlCommand(@"
                                  DECLARE @routeID INT;

                    IF NOT EXISTS (SELECT 1 FROM Route WHERE Origin=@origin AND Destination=@destination)
                    BEGIN
                        INSERT INTO Route (Origin, Destination, Distance, Duration)
                        VALUES (@origin, @destination, @distance, @duration);

                        SET @routeID = SCOPE_IDENTITY();
                    END
                    ELSE
                    BEGIN
                        SELECT @routeID = RouteID FROM Route WHERE Origin=@origin AND Destination=@destination;
                    END

                    SELECT @routeID;

            ", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@origin", origin);
                        cmd.Parameters.AddWithValue("@destination", destination);
                        cmd.Parameters.AddWithValue("@distance", distance);

                        // Send the TimeSpan directly for TIME column
                        cmd.Parameters.Add("@duration", SqlDbType.Time).Value = duration;

                        routeID = (int)cmd.ExecuteScalar();
                    }

                    // Assign this route to the ferry
                    using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO FerryRoute (FerryID, RouteID)
                VALUES (@ferryID, @routeID)
            ", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ferryID", ferryID);
                        cmd.Parameters.AddWithValue("@routeID", routeID);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error adding route:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
        }

        public bool UpdateRoute(int routeID, int ferryID, string origin, string destination, decimal distance, TimeSpan duration)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Update Route table
                        string updateRouteQuery = @"
                        UPDATE Route
                        SET Origin = @origin,
                            Destination = @destination,
                            Distance = @distance,
                            Duration = @duration
                        WHERE RouteID = @routeID;
                    ";

                        using (SqlCommand cmd = new SqlCommand(updateRouteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@origin", origin);
                            cmd.Parameters.AddWithValue("@destination", destination);
                            cmd.Parameters.AddWithValue("@distance", distance);
                            cmd.Parameters.Add("@duration", SqlDbType.Time).Value = duration;
                            cmd.Parameters.AddWithValue("@routeID", routeID);
                            cmd.ExecuteNonQuery();
                        }

                        // Ensure FerryRoute link exists
                        string ferryRouteQuery = @"
                        IF NOT EXISTS (SELECT 1 FROM FerryRoute WHERE FerryID=@ferryID AND RouteID=@routeID)
                        BEGIN
                            INSERT INTO FerryRoute (FerryID, RouteID)
                            VALUES (@ferryID, @routeID)
                        END
                    ";

                        using (SqlCommand cmd = new SqlCommand(ferryRouteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ferryID", ferryID);
                            cmd.Parameters.AddWithValue("@routeID", routeID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating route:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
        public bool DeleteRoute(int ferryRouteID)
        {
            try
            {
                string query = "DELETE FROM FerryRoute WHERE FerryRouteID = @ID";

                SqlParameter[] parameters =
                {
            new SqlParameter("@ID", ferryRouteID)
        };

                DatabaseHelper db = new DatabaseHelper();
                int affected = db.ExecuteNonQuery(query, parameters);

                return affected > 0;
            }
            catch
            {
                return false;
            }
        }



        // Optional: Get route by ID for edit dialog
        public DataRow GetRouteById(int routeID)
        {
            string query = "SELECT * FROM Route WHERE RouteID = @routeID";
            SqlParameter[] p = { new SqlParameter("@routeID", routeID) };
            DataTable dt = db.ExecuteDataTable(query, p);
            return dt.Rows.Count == 1 ? dt.Rows[0] : null;
        }



        public int InsertSchedule(
            int ferryID,
            int routeID,
            TimeSpan departure,
            TimeSpan arrival,
            string daysOfWeek,
            DateTime startDate,
            DateTime endDate,
            bool isActive
                 )
              {
            string query = @"
            INSERT INTO Schedule (
                FerryID, RouteID, DepartureTime, ArrivalTime, 
                DaysOfWeek, StartDate, EndDate, IsActive
            )
            VALUES (
                @FerryID, @RouteID, @Departure, @Arrival,
                @DaysOfWeek, @StartDate, @EndDate, @IsActive
            );
            SELECT SCOPE_IDENTITY();
             ";

            SqlParameter[] prms = {
            new SqlParameter("@FerryID", ferryID),
            new SqlParameter("@RouteID", routeID),
            new SqlParameter("@Departure", departure),
            new SqlParameter("@Arrival", arrival),
            new SqlParameter("@DaysOfWeek", daysOfWeek),
            new SqlParameter("@StartDate", startDate),
            new SqlParameter("@EndDate", endDate),
            new SqlParameter("@IsActive", isActive)
            };

            object result = db.ExecuteScalar(query, prms);
            return Convert.ToInt32(result);
        }


        public List<int> GenerateTripsFromSchedule(
        int scheduleID,
        int ferryID,
        int routeID,
        string daysOfWeek,
        DateTime startDate,
        DateTime endDate,
        TimeSpan departure,
        TimeSpan arrival
)
        {
            List<int> tripIDs = new List<int>();

            // Convert "MON,TUE,FRI" → HashSet<DayOfWeek>
            var allowed = new HashSet<DayOfWeek>(
                daysOfWeek.Split(',')
                    .Select(d => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), d, true))
            );

            DateTime current = startDate;

            while (current <= endDate)
            {
                if (allowed.Contains(current.DayOfWeek))
                {
                    // INSERT Trip
                    string insertTrip = @"
                INSERT INTO Trip (ScheduleID, FerryID, RouteID, TripDate, DepartureTime, ArrivalTime)
                VALUES (@ScheduleID, @FerryID, @RouteID, @TripDate, @Departure, @Arrival);
                SELECT SCOPE_IDENTITY();
            ";

                    SqlParameter[] prms = {
                new SqlParameter("@ScheduleID", scheduleID),
                new SqlParameter("@FerryID", ferryID),
                new SqlParameter("@RouteID", routeID),
                new SqlParameter("@TripDate", current.Date),
                new SqlParameter("@Departure", departure),
                new SqlParameter("@Arrival", arrival)
            };

                    int tripID = Convert.ToInt32(db.ExecuteScalar(insertTrip, prms));
                    tripIDs.Add(tripID);
                }

                current = current.AddDays(1);
            }

            return tripIDs;
        }

        public void InsertTripFloorPrice(int tripID, int ferryID, int floorNumber, decimal price)
        {
            string query = @"
        INSERT INTO TripFloorPrice (TripID, FerryID, FloorNumber, Price)
        VALUES (@TripID, @FerryID, @FloorNumber, @Price);
        ";

                SqlParameter[] prms = {
            new SqlParameter("@TripID", tripID),
            new SqlParameter("@FerryID", ferryID),
            new SqlParameter("@FloorNumber", floorNumber),
            new SqlParameter("@Price", price)
        };

            db.ExecuteNonQuery(query, prms);
        }


        public DataRow GetFerryById(int ferryId)
        {
            string query = "SELECT FerryID, FerryCode, FerryName, TotalFloors, TotalCapacity, Status, OwnerID FROM Ferry WHERE FerryID = @FerryID";
            SqlParameter[] parameters = { new SqlParameter("@FerryID", ferryId) };
            DataTable dt = db.ExecuteDataTable(query, parameters);
            return dt != null && dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Return FerryFloor rows for a ferry (FloorID, FloorNumber, Rows, Columns, Capacity).
        /// </summary>
        public DataTable GetFerryFloors(int ferryID)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT FloorNumber, Rows, Columns, Capacity
                    FROM FerryFloor
                    WHERE FerryID = @FerryID
                    ORDER BY FloorNumber ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FerryID", ferryID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Update simple ferry details and replace floor layout (no documents).
        /// Floors is expected to contain columns FloorNumber, Rows, Columns.
        /// </summary>
        public bool UpdateFerry(int ferryId, string ferryCode, string ferryName, DataTable floors, out string error)
        {
            error = "";

            // 1. Validate if ferry can be edited
            if (!CanEditFerry(ferryId, out error))
                return false;

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 2. Compute totals
                        int totalFloors = floors?.Rows.Count ?? 0;
                        int totalCapacity = 0;

                        if (floors != null)
                        {
                            foreach (DataRow r in floors.Rows)
                            {
                                totalCapacity += Convert.ToInt32(r["Rows"]) * Convert.ToInt32(r["Columns"]);
                            }
                        }

                        // 3. Update Ferry
                        using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE Ferry
                    SET FerryCode = @code,
                        FerryName = @name,
                        TotalFloors = @floors,
                        TotalCapacity = @cap
                    WHERE FerryID = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@code", ferryCode);
                            cmd.Parameters.AddWithValue("@name", ferryName);
                            cmd.Parameters.AddWithValue("@floors", totalFloors);
                            cmd.Parameters.AddWithValue("@cap", totalCapacity);
                            cmd.Parameters.AddWithValue("@id", ferryId);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Remove floors (safe because editing was validated)
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM FerryFloor WHERE FerryID = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", ferryId);
                            cmd.ExecuteNonQuery();
                        }

                        // 5. Insert fresh floors
                        if (floors != null)
                        {
                            foreach (DataRow row in floors.Rows)
                            {
                                using (SqlCommand cmd = new SqlCommand(
                                    "INSERT INTO FerryFloor(FerryID, FloorNumber, Rows, Columns) VALUES (@fid, @num, @r, @c)",
                                    conn, tran))
                                {
                                    cmd.Parameters.AddWithValue("@fid", ferryId);
                                    cmd.Parameters.AddWithValue("@num", row["FloorNumber"]);
                                    cmd.Parameters.AddWithValue("@r", row["Rows"]);
                                    cmd.Parameters.AddWithValue("@c", row["Columns"]);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        error = ex.Message;
                        return false;
                    }
                }
            }
        }


        /// <summary>
        /// Delete a ferry if there are no dependent trips/bookings.
        /// Returns true when deleted; returns false when deletion is blocked (dependent data).
        /// </summary>
        public bool DeleteFerry(int ferryId, out string error)
        {
            error = "";

            // Validate delete
            if (!CanDeleteFerry(ferryId, out error))
                return false;

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        ExecuteDelete(tran, "DELETE FROM TripFloorPrice WHERE FerryID = @id", ferryId);
                        ExecuteDelete(tran, "DELETE FROM BookedSeats WHERE FerryID = @id", ferryId);
                        ExecuteDelete(tran, "DELETE FROM FerryRoute WHERE FerryID = @id", ferryId);
                        ExecuteDelete(tran, "DELETE FROM Schedule WHERE FerryID = @id", ferryId);
                        ExecuteDelete(tran, "DELETE FROM FerryDocuments WHERE FerryID = @id", ferryId);
                        ExecuteDelete(tran, "DELETE FROM FerryFloor WHERE FerryID = @id", ferryId);

                        // Finally delete ferry record
                        ExecuteDelete(tran, "DELETE FROM Ferry WHERE FerryID = @id", ferryId);

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        error = ex.Message;
                        return false;
                    }
                }
            }
        }


        private void ExecuteDelete(SqlTransaction tran, string sql, int id)
        {
            using (SqlCommand cmd = new SqlCommand(sql, tran.Connection, tran))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }


        public bool CanEditFerry(int ferryId, out string reason)
        {
            reason = "";

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // 1. Any Routes?
                if (HasRecord(conn, "SELECT COUNT(*) FROM FerryRoute WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry is assigned to one or more Routes.";
                    return false;
                }

                // 2. Any Schedules?
                if (HasRecord(conn, "SELECT COUNT(*) FROM Schedule WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry has existing Schedules.";
                    return false;
                }

                // 3. Any Trips?
                if (HasRecord(conn, "SELECT COUNT(*) FROM Trip WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry has Trips. Editing is disabled.";
                    return false;
                }

                // 4. Any Bookings?
                if (HasRecord(conn,
                    "SELECT COUNT(*) FROM Booking WHERE TripID IN (SELECT TripID FROM Trip WHERE FerryID = @id)", ferryId))
                {
                    reason = "Ferry has Bookings.";
                    return false;
                }

                // 5. Any Booked Seats?
                if (HasRecord(conn, "SELECT COUNT(*) FROM BookedSeats WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry has booked seats.";
                    return false;
                }

                // 6. Any TripFloorPrice?
                if (HasRecord(conn, "SELECT COUNT(*) FROM TripFloorPrice WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry has floor prices set for existing trips.";
                    return false;
                }

                return true;
            }
        }

        private bool HasRecord(SqlConnection conn, string sql, int id)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

  

        public bool CanDeleteFerry(int ferryId, out string reason)
        {
            reason = "";

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // A ferry CANNOT be deleted if any dependent records exist.

                if (HasRecord(conn, "SELECT COUNT(*) FROM FerryRoute WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry is assigned to a route.";
                    return false;
                }

                if (HasRecord(conn, "SELECT COUNT(*) FROM Schedule WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry has schedules. Remove schedules first.";
                    return false;
                }

                if (HasRecord(conn, "SELECT COUNT(*) FROM Trip WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry has trips. Cannot delete ferries used in trips.";
                    return false;
                }

                if (HasRecord(conn,
                    "SELECT COUNT(*) FROM Booking WHERE TripID IN (SELECT TripID FROM Trip WHERE FerryID = @id)", ferryId))
                {
                    reason = "Ferry has bookings. Cannot delete ferries with booking history.";
                    return false;
                }

                if (HasRecord(conn, "SELECT COUNT(*) FROM BookedSeats WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry has booked seats. Cannot delete.";
                    return false;
                }

                if (HasRecord(conn, "SELECT COUNT(*) FROM TripFloorPrice WHERE FerryID = @id", ferryId))
                {
                    reason = "Ferry has floor prices linked to trips. Cannot delete.";
                    return false;
                }

                return true;
            }
        }














    }
}