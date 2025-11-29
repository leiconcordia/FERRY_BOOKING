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
        public bool IsFerryDuplicate(string ferryCode, string ferryName, int ownerId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                // SQL Logic: 
                // 1. Check if FerryCode exists (Globally, because your table says UNIQUE)
                // 2. OR Check if FerryName exists (For this specific OwnerID)
                string query = @"
            SELECT COUNT(1) 
            FROM Ferry 
            WHERE FerryCode = @FerryCode 
               OR (FerryName = @FerryName AND OwnerID = @OwnerID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FerryCode", ferryCode);
                    cmd.Parameters.AddWithValue("@FerryName", ferryName);
                    cmd.Parameters.AddWithValue("@OwnerID", ownerId);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();

                    // If count is greater than 0, a duplicate exists
                    return count > 0;
                }
            }
        }


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
                        // 1. Check if any trips for this route have bookings
                        string checkBookingsQuery = @"
                    SELECT COUNT(1)
                    FROM Trip t
                    JOIN Booking b ON t.TripID = b.TripID
                    WHERE t.RouteID = @routeID
                ";

                        using (SqlCommand cmd = new SqlCommand(checkBookingsQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@routeID", routeID);
                            int bookingCount = (int)cmd.ExecuteScalar();

                            if (bookingCount > 0)
                            {
                                MessageBox.Show(
                                    "Cannot edit Origin or Destination because there are bookings for trips on this route.",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return false; // Stop update
                            }
                        }

                        // 2. Update Route table (safe fields: Distance and Duration always; Origin/Destination if no bookings)
                        string updateRouteQuery = @"
                    UPDATE Route
                    SET Origin = @origin,
                        Destination = @destination,
                        Distance = @distance,
                        Duration = @duration
                    WHERE RouteID = @routeID
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

                        // 3. Ensure FerryRoute link exists
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
                        MessageBox.Show(
                            "Error updating route:\n" + ex.Message,
                            "Database Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return false;
                    }
                }
            }
        }

        public bool DeleteRoute(int ferryRouteID)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Check if any trips exist for this FerryRoute
                        string checkTripsQuery = @"
                    SELECT COUNT(1)
                    FROM Trip t
                    JOIN FerryRoute fr ON t.RouteID = fr.RouteID AND t.FerryID = fr.FerryID
                    WHERE fr.FerryRouteID = @ferryRouteID
                ";

                        using (SqlCommand cmd = new SqlCommand(checkTripsQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ferryRouteID", ferryRouteID);
                            int tripCount = (int)cmd.ExecuteScalar();

                            if (tripCount > 0)
                            {
                                MessageBox.Show(
                                    "Cannot delete this Ferry-Route link because there are trips associated with it.",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return false; // Stop deletion
                            }
                        }

                        // 2. Delete the FerryRoute record
                        string deleteQuery = "DELETE FROM FerryRoute WHERE FerryRouteID = @ferryRouteID";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ferryRouteID", ferryRouteID);
                            int affected = cmd.ExecuteNonQuery();

                            if (affected > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(
                            "Error deleting Ferry-Route:\n" + ex.Message,
                            "Database Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return false;
                    }
                }
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
            bool isActive)
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
        SELECT SCOPE_IDENTITY();";

            var prms = new[]
            {
                new SqlParameter("@FerryID", ferryID),
                new SqlParameter("@RouteID", routeID),
                new SqlParameter("@Departure", SqlDbType.Time){ Value = departure },
                new SqlParameter("@Arrival",   SqlDbType.Time){ Value = arrival },
                new SqlParameter("@DaysOfWeek", daysOfWeek),
                new SqlParameter("@StartDate", SqlDbType.Date){ Value = startDate.Date },
                new SqlParameter("@EndDate",   SqlDbType.Date){ Value = endDate.Date },
                new SqlParameter("@IsActive", isActive),
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
        TimeSpan arrival)
        {
            List<int> tripIDs = new();

            var allowed = new HashSet<DayOfWeek>(
                daysOfWeek.Split(',').Select(d => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), d, true)));

            DateTime current = startDate.Date;

            while (current <= endDate.Date)
            {
                if (allowed.Contains(current.DayOfWeek))
                {
                    string insertTrip = @"
                INSERT INTO Trip (ScheduleID, FerryID, RouteID, TripDate, DepartureTime, ArrivalTime)
                VALUES (@ScheduleID, @FerryID, @RouteID, @TripDate, @Departure, @Arrival);
                SELECT SCOPE_IDENTITY();";

                    var prms = new[]
                    {
                        new SqlParameter("@ScheduleID", scheduleID),
                        new SqlParameter("@FerryID", ferryID),
                        new SqlParameter("@RouteID", routeID),
                        new SqlParameter("@TripDate", SqlDbType.Date){ Value = current.Date },
                        new SqlParameter("@Departure", SqlDbType.Time){ Value = departure },
                        new SqlParameter("@Arrival",   SqlDbType.Time){ Value = arrival },
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


        // ============================================================================
        // ENHANCED VALIDATION SYSTEM - Hybrid Soft/Hard Delete
        // ============================================================================

        /// <summary>
        /// Validates if a ferry can be deleted (hard or soft)
        /// Returns validation result with detailed information
        /// </summary>
        public ValidationResult ValidateFerryDeletion(int ferryId)
        {
            var result = new ValidationResult { CanProceed = true };

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Check for upcoming/active trips
                string upcomingTripsQuery = @"
                    SELECT COUNT(*) 
                    FROM Trip 
                    WHERE FerryID = @id 
                    AND TripDate >= CAST(GETDATE() AS DATE)";

                int upcomingTrips = Convert.ToInt32(ExecuteScalar(conn, upcomingTripsQuery, ferryId));

                // Check for completed trips (history)
                string completedTripsQuery = @"
                    SELECT COUNT(*) 
                    FROM Trip 
                    WHERE FerryID = @id 
                    AND TripDate < CAST(GETDATE() AS DATE)";

                int completedTrips = Convert.ToInt32(ExecuteScalar(conn, completedTripsQuery, ferryId));

                // Check for any bookings
                string bookingsQuery = @"
                    SELECT COUNT(*) 
                    FROM Booking b
                    JOIN Trip t ON b.TripID = t.TripID
                    WHERE t.FerryID = @id";

                int totalBookings = Convert.ToInt32(ExecuteScalar(conn, bookingsQuery, ferryId));

                // Determine delete type
                if (upcomingTrips > 0)
                {
                    result.CanProceed = false;
                    result.Message = $"Cannot delete ferry: {upcomingTrips} upcoming trip(s) scheduled.\n" +
                                   "Please cancel or complete all upcoming trips first.";
                    result.DeleteType = DeleteType.Blocked;
                }
                else if (completedTrips > 0 || totalBookings > 0)
                {
                    // Has history - use soft delete
                    result.CanProceed = true;
                    result.Message = $"This ferry has historical data:\n" +
                                   $"- {completedTrips} completed trip(s)\n" +
                                   $"- {totalBookings} total booking(s)\n\n" +
                                   "The ferry will be marked as INACTIVE (soft delete) to preserve history.";
                    result.DeleteType = DeleteType.Soft;
                    result.AffectedRecords = completedTrips + totalBookings;
                }
                else
                {
                    // No history - can hard delete
                    result.CanProceed = true;
                    result.Message = "Ferry has no trip history and will be permanently deleted.";
                    result.DeleteType = DeleteType.Hard;
                }
            }

            return result;
        }

        /// <summary>
        /// Validates if a route can be deleted
        /// </summary>
        public ValidationResult ValidateRouteDeletion(int ferryRouteID)
        {
            var result = new ValidationResult { CanProceed = true };

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Get RouteID from FerryRoute
                string getRouteQuery = "SELECT RouteID FROM FerryRoute WHERE FerryRouteID = @id";
                int routeID = Convert.ToInt32(ExecuteScalar(conn, getRouteQuery, ferryRouteID));

                // Check for active schedules
                string activeSchedulesQuery = @"
                    SELECT COUNT(*) 
                    FROM Schedule 
                    WHERE RouteID = @routeID 
                    AND IsActive = 1
                    AND (EndDate IS NULL OR EndDate >= CAST(GETDATE() AS DATE))";

                int activeSchedules = Convert.ToInt32(ExecuteScalar(conn, activeSchedulesQuery, routeID));

                // Check for future trips
                string futureTripsQuery = @"
                    SELECT COUNT(*) 
                    FROM Trip 
                    WHERE RouteID = @routeID 
                    AND TripDate >= CAST(GETDATE() AS DATE)";

                int futureTrips = Convert.ToInt32(ExecuteScalar(conn, futureTripsQuery, routeID));

                // Check for booking history
                string bookingHistoryQuery = @"
                    SELECT COUNT(*) 
                    FROM Booking b
                    JOIN Trip t ON b.TripID = t.TripID
                    WHERE t.RouteID = @routeID";

                int bookings = Convert.ToInt32(ExecuteScalar(conn, bookingHistoryQuery, routeID));

                if (activeSchedules > 0 || futureTrips > 0)
                {
                    result.CanProceed = false;
                    result.Message = $"Cannot delete route:\n" +
                                   $"- {activeSchedules} active schedule(s)\n" +
                                   $"- {futureTrips} future trip(s)\n\n" +
                                   "Please deactivate schedules and cancel future trips first.";
                    result.DeleteType = DeleteType.Blocked;
                }
                else if (bookings > 0)
                {
                    result.CanProceed = true;
                    result.Message = $"Route has {bookings} booking(s) in history.\n" +
                                   "The route assignment will be removed but history will be preserved.";
                    result.DeleteType = DeleteType.Soft;
                    result.AffectedRecords = bookings;
                }
                else
                {
                    result.CanProceed = true;
                    result.Message = "Route has no history and will be permanently deleted.";
                    result.DeleteType = DeleteType.Hard;
                }
            }

            return result;
        }

        /// <summary>
        /// Validates if a schedule can be deleted
        /// </summary>
        public ValidationResult ValidateScheduleDeletion(int scheduleID)
        {
            var result = new ValidationResult { CanProceed = true };

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Check for future trips with bookings
                string futureBookingsQuery = @"
                    SELECT COUNT(DISTINCT b.BookingID)
                    FROM Booking b
                    JOIN Trip t ON b.TripID = t.TripID
                    WHERE t.ScheduleID = @id
                    AND t.TripDate >= CAST(GETDATE() AS DATE)";

                int futureBookings = Convert.ToInt32(ExecuteScalar(conn, futureBookingsQuery, scheduleID));

                // Check for all bookings
                string allBookingsQuery = @"
                    SELECT COUNT(DISTINCT b.BookingID)
                    FROM Booking b
                    JOIN Trip t ON b.TripID = t.TripID
                    WHERE t.ScheduleID = @id";

                int totalBookings = Convert.ToInt32(ExecuteScalar(conn, allBookingsQuery, scheduleID));

                if (futureBookings > 0)
                {
                    result.CanProceed = false;
                    result.Message = $"Cannot delete schedule: {futureBookings} active booking(s) for future trips.\n\n" +
                                   "Please cancel or complete all booked trips first.";
                    result.DeleteType = DeleteType.Blocked;
                    result.AffectedRecords = futureBookings;
                }
                else if (totalBookings > 0)
                {
                    result.CanProceed = true;
                    result.Message = $"Schedule has {totalBookings} booking(s) in history.\n" +
                                   "Schedule will be marked INACTIVE to preserve booking records.";
                    result.DeleteType = DeleteType.Soft;
                    result.AffectedRecords = totalBookings;
                }
                else
                {
                    result.CanProceed = true;
                    result.Message = "Schedule has no bookings and will be permanently deleted.";
                    result.DeleteType = DeleteType.Hard;
                }
            }

            return result;
        }

        /// <summary>
        /// Validates if ferry can be edited
        /// </summary>
        public ValidationResult ValidateFerryEdit(int ferryId)
        {
            var result = new ValidationResult { CanProceed = true };

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Check for upcoming trips
                string upcomingTripsQuery = @"
                    SELECT COUNT(*) 
                    FROM Trip 
                    WHERE FerryID = @id 
                    AND TripDate >= CAST(GETDATE() AS DATE)";

                int upcomingTrips = Convert.ToInt32(ExecuteScalar(conn, upcomingTripsQuery, ferryId));

                // Check for booked seats
                string bookedSeatsQuery = @"
                    SELECT COUNT(*) 
                    FROM BookedSeats bs
                    JOIN Trip t ON bs.TripID = t.TripID
                    WHERE bs.FerryID = @id
                    AND t.TripDate >= CAST(GETDATE() AS DATE)";

                int bookedSeats = Convert.ToInt32(ExecuteScalar(conn, bookedSeatsQuery, ferryId));

                if (upcomingTrips > 0 || bookedSeats > 0)
                {
                    result.CanProceed = false;
                    result.Message = $"Cannot edit ferry configuration:\n" +
                                   $"- {upcomingTrips} upcoming trip(s)\n" +
                                   $"- {bookedSeats} booked seat(s)\n\n" +
                                   "Ferry name can be edited, but floor configuration is locked.";
                    result.DeleteType = DeleteType.Blocked;
                    result.AllowPartialEdit = true; // Can edit name only
                }
                else
                {
                    result.CanProceed = true;
                    result.Message = "Ferry can be fully edited.";
                }
            }

            return result;
        }

        /// <summary>
        /// Validates if route can be edited
        /// </summary>
        public ValidationResult ValidateRouteEdit(int routeID)
        {
            var result = new ValidationResult { CanProceed = true };

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Check for existing trips
                string tripsQuery = @"
                    SELECT COUNT(*) 
                    FROM Trip 
                    WHERE RouteID = @id";

                int trips = Convert.ToInt32(ExecuteScalar(conn, tripsQuery, routeID));

                if (trips > 0)
                {
                    result.CanProceed = false;
                    result.Message = $"Cannot change origin/destination: {trips} trip(s) exist using this route.\n\n" +
                                   "Distance and duration can still be updated.";
                    result.AllowPartialEdit = true; // Can edit distance/duration only
                }
                else
                {
                    result.CanProceed = true;
                    result.Message = "Route can be fully edited.";
                }
            }

            return result;
        }

        // ============================================================================
        // ENHANCED DELETE OPERATIONS
        // ============================================================================

        /// <summary>
        /// Delete ferry with hybrid soft/hard delete logic
        /// </summary>
        public bool DeleteFerryEnhanced(int ferryId, out string error)
        {
            error = "";
            var validation = ValidateFerryDeletion(ferryId);

            if (!validation.CanProceed)
            {
                error = validation.Message;
                return false;
            }

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (validation.DeleteType == DeleteType.Soft)
                        {
                            // Soft delete - mark as inactive
                            ExecuteNonQuery(tran, "UPDATE Ferry SET Status = 'Inactive' WHERE FerryID = @id", ferryId);
                        }
                        else
                        {
                            // Hard delete - remove all related records
                            ExecuteDelete(tran, "DELETE FROM TripFloorPrice WHERE FerryID = @id", ferryId);
                            ExecuteDelete(tran, "DELETE FROM FerryRoute WHERE FerryID = @id", ferryId);
                            ExecuteDelete(tran, "DELETE FROM FerryDocuments WHERE FerryID = @id", ferryId);
                            ExecuteDelete(tran, "DELETE FROM FerryFloor WHERE FerryID = @id", ferryId);
                            ExecuteDelete(tran, "DELETE FROM Ferry WHERE FerryID = @id", ferryId);
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
        /// Delete schedule with hybrid logic
        /// </summary>
        public bool DeleteScheduleEnhanced(int scheduleID, out string error)
        {
            error = "";
            var validation = ValidateScheduleDeletion(scheduleID);

            if (!validation.CanProceed)
            {
                error = validation.Message;
                return false;
            }

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (validation.DeleteType == DeleteType.Soft)
                        {
                            // Soft delete - mark as inactive
                            ExecuteNonQuery(tran, "UPDATE Schedule SET IsActive = 0 WHERE ScheduleID = @id", scheduleID);
                        }
                        else
                        {
                            // Hard delete - remove all related data (trips, floor prices, booked seats)
                            
                            // 1. Delete TripFloorPrice for all trips in this schedule
                            using (SqlCommand cmd = new SqlCommand(@"
                                DELETE FROM TripFloorPrice 
                                WHERE TripID IN (SELECT TripID FROM Trip WHERE ScheduleID = @id)", 
                                tran.Connection, tran))
                            {
                                cmd.Parameters.AddWithValue("@id", scheduleID);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Delete BookedSeats for all trips in this schedule (in case any exist)
                            using (SqlCommand cmd = new SqlCommand(@"
                                DELETE FROM BookedSeats 
                                WHERE TripID IN (SELECT TripID FROM Trip WHERE ScheduleID = @id)", 
                                tran.Connection, tran))
                            {
                                cmd.Parameters.AddWithValue("@id", scheduleID);
                                cmd.ExecuteNonQuery();
                            }

                            // 3. Delete all trips for this schedule
                            using (SqlCommand cmd = new SqlCommand(@"
                                DELETE FROM Trip WHERE ScheduleID = @id", 
                                tran.Connection, tran))
                            {
                                cmd.Parameters.AddWithValue("@id", scheduleID);
                                cmd.ExecuteNonQuery();
                            }

                            // 4. Finally, delete the schedule itself
                            ExecuteDelete(tran, "DELETE FROM Schedule WHERE ScheduleID = @id", scheduleID);
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

        // ============================================================================
        // HELPER METHODS
        // ============================================================================

        private object ExecuteScalar(SqlConnection conn, string query, int id)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@routeID", id);
                return cmd.ExecuteScalar();
            }
        }

        private void ExecuteNonQuery(SqlTransaction tran, string query, int id)
        {
            using (SqlCommand cmd = new SqlCommand(query, tran.Connection, tran))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // ============================================================================
        // DASHBOARD STATISTICS METHODS
        // ============================================================================

        public int GetTotalBookingsToday(int ownerID)
        {
            string query = @"
        SELECT COUNT(*)
        FROM Booking b
        JOIN Trip t ON b.TripID = t.TripID
        JOIN Ferry f ON t.FerryID = f.FerryID
        WHERE f.OwnerID = @OwnerID
        AND CAST(b.BookingDate AS DATE) = CAST(GETDATE() AS DATE)
        AND t.TripStatus = 'Active'";
            SqlParameter[] parameters = { new SqlParameter("@OwnerID", ownerID) };
            return Convert.ToInt32(db.ExecuteScalar(query, parameters));
        }

        public decimal GetTotalRevenueToday(int ownerID)
        {
            string query = @"
        SELECT 
            ISNULL(SUM(b.TotalAmount), 0) - ISNULL(SUM(CASE 
                WHEN br.RefundStatus = 'Completed' AND CAST(br.RefundDate AS DATE) = CAST(GETDATE() AS DATE) 
                THEN br.RefundAmount 
                ELSE 0 
            END), 0) AS NetRevenue
        FROM Booking b
        JOIN Trip t ON b.TripID = t.TripID
        JOIN Ferry f ON t.FerryID = f.FerryID
        LEFT JOIN BookingRefund br ON b.BookingID = br.BookingID
        WHERE f.OwnerID = @OwnerID
        AND CAST(b.BookingDate AS DATE) = CAST(GETDATE() AS DATE)
        AND t.TripStatus = 'Active'";
            SqlParameter[] parameters = { new SqlParameter("@OwnerID", ownerID) };
            object result = db.ExecuteScalar(query, parameters);
            return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        public string GetMostBookedFerry(int ownerID)
        {
            string query = @"
        SELECT TOP 1 f.FerryName,
            CAST((CAST(COUNT(bs.BookedSeatID) AS FLOAT) / f.TotalCapacity) * 100 AS DECIMAL(5,2)) AS Occupancy
        FROM Ferry f
        JOIN Trip t ON f.FerryID = t.FerryID
        LEFT JOIN BookedSeats bs ON t.TripID = bs.TripID
        WHERE f.OwnerID = @OwnerID
        AND t.TripStatus = 'Active'
        GROUP BY f.FerryName, f.TotalCapacity
        ORDER BY Occupancy DESC";
            SqlParameter[] parameters = { new SqlParameter("@OwnerID", ownerID) };
            DataTable dt = db.ExecuteDataTable(query, parameters);
            if (dt.Rows.Count == 0) return "No data";
            return $"{dt.Rows[0]["FerryName"]} ({dt.Rows[0]["Occupancy"]}%)";
        }

        public (int availableSeats, int tripsToday) GetAvailableSeatsAndTrips(int ownerID)
        {
            string query = @"
        SELECT 
            SUM(f.TotalCapacity - ISNULL(BS.BookedSeats, 0)) AS AvailableSeats,
            COUNT(*) AS TripsToday
        FROM Trip t
        JOIN Ferry f ON t.FerryID = f.FerryID
        LEFT JOIN (
            SELECT TripID, COUNT(*) AS BookedSeats
            FROM BookedSeats
            GROUP BY TripID
        ) BS ON BS.TripID = t.TripID
        WHERE f.OwnerID = @OwnerID
        AND CAST(t.TripDate AS DATE) = CAST(GETDATE() AS DATE)
        AND t.TripStatus = 'Active'";
            SqlParameter[] parameters = { new SqlParameter("@OwnerID", ownerID) };
            DataTable dt = db.ExecuteDataTable(query, parameters);
            int available = dt.Rows[0]["AvailableSeats"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["AvailableSeats"]) : 0;
            int trips = dt.Rows[0]["TripsToday"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["TripsToday"]) : 0;
            return (available, trips);
        }

        /// <summary>
        /// Get ferry documents by FerryID
        /// Returns DataRow with COFile, VRFile, SCFile, IDFile, POFile, FPFile as byte arrays
        /// </summary>
        public DataRow GetFerryDocuments(int ferryID)
        {
            string query = "SELECT COFile, VRFile, SCFile, IDFile, POFile, FPFile FROM FerryDocuments WHERE FerryID = @FerryID";
            SqlParameter[] parameters = { new SqlParameter("@FerryID", ferryID) };
            DataTable dt = db.ExecuteDataTable(query, parameters);
            return dt != null && dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataRow GetScheduleById(int scheduleID)
        {
            string query = "SELECT * FROM Schedule WHERE ScheduleID = @ScheduleID";
            SqlParameter[] p = { new SqlParameter("@ScheduleID", scheduleID) };
            DataTable dt = db.ExecuteDataTable(query, p);
            return dt.Rows.Count == 1 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Update schedule record. Returns true on success.
        /// Also leaves trips in place; call UpdateTripsTimes to sync trip times if desired.
        /// </summary>
        public bool UpdateSchedule(
            int scheduleID,
            int ferryID,
            int routeID,
            TimeSpan departure,
            TimeSpan arrival,
            string daysOfWeek,
            DateTime startDate,
            DateTime endDate,
            bool isActive)
        {
            try
            {
                string query = @"
                    UPDATE Schedule
                    SET FerryID = @FerryID,
                        RouteID = @RouteID,
                        DepartureTime = @Departure,
                        ArrivalTime = @Arrival,
                        DaysOfWeek = @DaysOfWeek,
                        StartDate = @StartDate,
                        EndDate = @EndDate,
                        IsActive = @IsActive
                    WHERE ScheduleID = @ScheduleID
                ";

                var prms = new[]
                {
                    new SqlParameter("@FerryID", ferryID),
                    new SqlParameter("@RouteID", routeID),
                    new SqlParameter("@Departure", SqlDbType.Time){ Value = departure },
                    new SqlParameter("@Arrival",   SqlDbType.Time){ Value = arrival },
                    new SqlParameter("@DaysOfWeek", daysOfWeek),
                    new SqlParameter("@StartDate", SqlDbType.Date){ Value = startDate.Date },
                    new SqlParameter("@EndDate",   SqlDbType.Date){ Value = endDate.Date },
                    new SqlParameter("@IsActive", isActive),
                    new SqlParameter("@ScheduleID", scheduleID),
                };

                db.ExecuteNonQuery(query, prms);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating schedule: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Update departure/arrival times for trips that belong to the schedule.
        /// </summary>
        public void UpdateTripsTimes(int scheduleID, TimeSpan departure, TimeSpan arrival)
        {
            try
            {
                string q = @"
                    UPDATE Trip
                    SET DepartureTime = @Departure, ArrivalTime = @Arrival
                    WHERE ScheduleID = @ScheduleID
                ";

                var prms = new[]
                {
                    new SqlParameter("@Departure", SqlDbType.Time){ Value = departure },
                    new SqlParameter("@Arrival",   SqlDbType.Time){ Value = arrival },
                    new SqlParameter("@ScheduleID", scheduleID),
                };

                db.ExecuteNonQuery(q, prms);
            }
            catch
            {
                // non-fatal
            }
        }


        public (bool hasConflict, string message, DataTable details) CheckTripConflicts(
            int ferryID,
            int routeID,
            DateTime startDate,
            DateTime endDate,
            string operatingDays,
            DateTime newDeparture,
            DateTime newArrival)
        {
            // 1. Setup
            bool hasConflict = false;
            string message = "";
            DataTable conflictTable = new DataTable();
            conflictTable.Columns.Add("Ferry", typeof(string));
            conflictTable.Columns.Add("ConflictType", typeof(string));
            conflictTable.Columns.Add("Time", typeof(string));
            conflictTable.Columns.Add("DateRange", typeof(string));

            string myOrigin = "";
            string myDestination = "";
            TimeSpan myDep = newDeparture.TimeOfDay;
            TimeSpan myArr = newArrival.TimeOfDay;
            TimeSpan oneHour = TimeSpan.FromHours(1);

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // ---------------------------------------------------------
                // SECTION 0: GET MY ROUTE INFO
                // ---------------------------------------------------------
                using (SqlCommand cmd = new SqlCommand("SELECT Origin, Destination FROM Route WHERE RouteID = @rid", conn))
                {
                    cmd.Parameters.AddWithValue("@rid", routeID);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            myOrigin = rdr["Origin"].ToString();
                            myDestination = rdr["Destination"].ToString();
                        }
                    }
                }

                // ---------------------------------------------------------
                // SECTION -1: THE "GHOST SHIP" CHECK (Previous Location) 👻
                // ---------------------------------------------------------
                string historyQuery = @"
            SELECT TOP 1 r.Destination, s.EndDate, s.ArrivalTime
            FROM Schedule s
            JOIN Route r ON s.RouteID = r.RouteID
            WHERE s.FerryID = @FerryID
            AND s.IsActive = 1
            AND s.EndDate < @StartDate -- Strictly before our new start
            ORDER BY s.EndDate DESC, s.ArrivalTime DESC";

                using (SqlCommand cmd = new SqlCommand(historyQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@FerryID", ferryID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Date);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            string lastPort = rdr["Destination"].ToString();
                            DateTime lastDate = Convert.ToDateTime(rdr["EndDate"]);

                            // RULE: If the boat ended in CEBU, the new schedule MUST start in CEBU.
                            if (lastPort != myOrigin)
                            {
                                TimeSpan gap = startDate.Date - lastDate.Date;

                                // If gap is less than 24 hours, we flag it.
                                if (gap.TotalHours < 24)
                                {
                                    hasConflict = true;

                                    // ✅ CALCULATE THE SAFE DATE (1 Day After)
                                    DateTime safeDate = lastDate.AddDays(1);

                                    message += $"⚠️ IMPOSSIBLE STARTING LOCATION!\n" +
                                               $"This ferry's last known location is '{lastPort}' (ended on {lastDate:MMM dd, yyyy}).\n" +
                                               $"It cannot start at '{myOrigin}' on {startDate:MMM dd} without travel time.\n\n" +
                                               $"💡 SUGGESTION: Schedule this trip starting on or after {safeDate:MMMM dd, yyyy} to allow the ferry to travel to {myOrigin}.\n\n";

                                    conflictTable.Rows.Add("THIS FERRY", "Teleportation", "Start of Sched", "Location Mismatch");
                                }
                            }
                        }
                    }
                }

                // ---------------------------------------------------------
                // SECTION 1: "LANE LOYALTY" CHECK (Exclusive Route Pair) 🔒
                // ---------------------------------------------------------
                string laneQuery = @"
            SELECT DISTINCT r.Origin, r.Destination
            FROM Schedule s
            JOIN Route r ON s.RouteID = r.RouteID
            WHERE s.FerryID = @FerryID
            AND s.IsActive = 1
            AND (s.StartDate <= @EndDate AND s.EndDate >= @StartDate)";

                using (SqlCommand cmd = new SqlCommand(laneQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@FerryID", ferryID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Date);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string existingOrigin = rdr["Origin"].ToString();
                            string existingDest = rdr["Destination"].ToString();

                            bool isSameLane =
                                (existingOrigin == myOrigin && existingDest == myDestination) ||
                                (existingOrigin == myDestination && existingDest == myOrigin);

                            if (!isSameLane)
                            {
                                hasConflict = true;
                                message += $"⚠️ ROUTE LOCK VIOLATION!\n" +
                                           $"This ferry is exclusively assigned to the '{existingOrigin}-{existingDest}' lane for these dates.\n" +
                                           $"You cannot schedule a trip to {myDestination} until the previous contract ends.\n\n";

                                conflictTable.Rows.Add("THIS FERRY", "Lane Violation", "N/A", "Date Range Conflict");
                            }
                        }
                    }
                }

                // ---------------------------------------------------------
                // SECTION 2: "PHYSICS ENGINE" (Teleportation Check) 👻
                // ---------------------------------------------------------
                // We fetch ALL trips for this ferry on the overlapping days to check the sequence.

                var dailyItinerary = new List<(TimeSpan Dep, TimeSpan Arr, string Org, string Dest, string Source)>();
                dailyItinerary.Add((myDep, myArr, myOrigin, myDestination, "NEW TRIP"));

                string physicsQuery = @"
            SELECT s.DepartureTime, s.ArrivalTime, r.Origin, r.Destination, s.DaysOfWeek
            FROM Schedule s
            JOIN Route r ON s.RouteID = r.RouteID
            WHERE s.FerryID = @FerryID
            AND s.IsActive = 1
            AND (s.StartDate <= @EndDate AND s.EndDate >= @StartDate)";

                using (SqlCommand cmd = new SqlCommand(physicsQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@FerryID", ferryID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Date);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string existingDays = rdr["DaysOfWeek"].ToString();
                            if (!AreDaysOverlapping(operatingDays, existingDays)) continue;

                            dailyItinerary.Add((
                                (TimeSpan)rdr["DepartureTime"],
                                (TimeSpan)rdr["ArrivalTime"],
                                rdr["Origin"].ToString(),
                                rdr["Destination"].ToString(),
                                "EXISTING"
                            ));
                        }
                    }
                }

                // Sort by Time 🕒
                dailyItinerary = dailyItinerary.OrderBy(x => x.Dep).ToList();

                for (int i = 0; i < dailyItinerary.Count - 1; i++)
                {
                    var currentTrip = dailyItinerary[i];
                    var nextTrip = dailyItinerary[i + 1];

                    // 1. Time Overlap Check
                    if (currentTrip.Arr > nextTrip.Dep)
                    {
                        if (currentTrip.Source == "NEW TRIP" || nextTrip.Source == "NEW TRIP")
                        {
                            hasConflict = true;
                            message += $"⚠️ TIME OVERLAP!\n" +
                                       $"Trip ({currentTrip.Org}-{currentTrip.Dest}) ends at {currentTrip.Arr:hh\\:mm},\n" +
                                       $"but the next trip starts at {nextTrip.Dep:hh\\:mm}.\n\n";
                            conflictTable.Rows.Add("THIS FERRY", "Time Overlap", currentTrip.Arr.ToString(), "N/A");
                        }
                    }
                    // 2. Teleportation Check (Location Mismatch) 🛑
                    else if (currentTrip.Dest != nextTrip.Org)
                    {
                        if (currentTrip.Source == "NEW TRIP" || nextTrip.Source == "NEW TRIP")
                        {
                            hasConflict = true;

                            // 💡 THE UPGRADE: Dynamic Suggestion for Same-Day conflicts
                            string suggestion = "";

                            // If the gap is tight (less than 2 hours), suggest next day
                            double gapHours = (nextTrip.Dep - currentTrip.Arr).TotalHours;

                            if (gapHours < 4) // Assuming it takes >4 hours to move empty
                            {
                                suggestion = $"💡 SUGGESTION: The ferry finishes in {currentTrip.Dest} at {currentTrip.Arr:hh\\:mm}.\n" +
                                             $"It cannot reach {nextTrip.Org} by {nextTrip.Dep:hh\\:mm}.\n" +
                                             $"Please schedule this trip on the NEXT DAY to allow travel time.";
                            }
                            else
                            {
                                suggestion = $"💡 SUGGESTION: You need a 'Deadhead' (empty) trip to move the ferry from {currentTrip.Dest} to {nextTrip.Org} between {currentTrip.Arr:hh\\:mm} and {nextTrip.Dep:hh\\:mm}.";
                            }

                            message += $"⚠️ IMPOSSIBLE LOCATION (SAME DAY)!\n" +
                                       $"Ferry arrives in {currentTrip.Dest} at {currentTrip.Arr:hh\\:mm}.\n" +
                                       $"But acts like it starts from {nextTrip.Org} at {nextTrip.Dep:hh\\:mm}.\n\n" +
                                       $"{suggestion}\n\n";

                            conflictTable.Rows.Add("THIS FERRY", "Teleportation", nextTrip.Dep.ToString(), "Location Mismatch");
                        }
                    }
                }

                // ---------------------------------------------------------
                // SECTION 3: PORT CONGESTION (The 1-Hour Rule) 🚦
                // ---------------------------------------------------------
                string portQuery = @"
            SELECT f.FerryName, r.Origin, r.Destination, s.DepartureTime, s.ArrivalTime, s.DaysOfWeek 
            FROM Schedule s
            JOIN Route r ON s.RouteID = r.RouteID
            JOIN Ferry f ON s.FerryID = f.FerryID
            WHERE s.IsActive = 1
            AND s.FerryID != @FerryID 
            AND (r.Origin = @Origin OR r.Destination = @Dest)
            AND (s.StartDate <= @EndDate AND s.EndDate >= @StartDate)";

                using (SqlCommand cmd = new SqlCommand(portQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@FerryID", ferryID);
                    cmd.Parameters.AddWithValue("@Origin", myOrigin);
                    cmd.Parameters.AddWithValue("@Dest", myDestination);
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Date);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string existingDays = rdr["DaysOfWeek"].ToString();
                            if (!AreDaysOverlapping(operatingDays, existingDays)) continue;

                            TimeSpan otherDep = (TimeSpan)rdr["DepartureTime"];
                            TimeSpan otherArr = (TimeSpan)rdr["ArrivalTime"];
                            string otherFerry = rdr["FerryName"].ToString();

                            if (rdr["Origin"].ToString() == myOrigin)
                            {
                                if (Math.Abs((myDep - otherDep).TotalMinutes) < 60)
                                {
                                    hasConflict = true;
                                    message += $"⚠️ PORT CONGESTION ({myOrigin}): {otherFerry} departs at {otherDep:hh\\:mm}.\n";
                                    conflictTable.Rows.Add(otherFerry, "Traffic", otherDep.ToString(), "N/A");
                                }
                            }
                            if (rdr["Destination"].ToString() == myDestination)
                            {
                                if (Math.Abs((myArr - otherArr).TotalMinutes) < 60)
                                {
                                    hasConflict = true;
                                    message += $"⚠️ PORT CONGESTION ({myDestination}): {otherFerry} arrives at {otherArr:hh\\:mm}.\n";
                                    conflictTable.Rows.Add(otherFerry, "Traffic", otherArr.ToString(), "N/A");
                                }
                            }
                        }
                    }
                }
            }

            if (!hasConflict) message = "Schedule is Valid! ✅";

            return (hasConflict, message, conflictTable);
        }



        // Helper to compare "Monday, Wednesday" vs "Wednesday, Friday"
        private bool AreDaysOverlapping(string myDays, string otherDays)
        {
            var mySet = new HashSet<string>(myDays.Split(','));
            var otherSet = new HashSet<string>(otherDays.Split(','));

            // Returns true if they share ANY day
            return mySet.Overlaps(otherSet);
        }
    }




/// </summary>

public class ValidationResult
    {
        public bool CanProceed { get; set; }
        public string Message { get; set; }
        public DeleteType DeleteType { get; set; }
        public int AffectedRecords { get; set; }
        public bool AllowPartialEdit { get; set; }
    }

    public enum DeleteType
    {
        Hard,
        Soft,
        Blocked
    }
}