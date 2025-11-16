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
                IF NOT EXISTS (SELECT 1 FROM Route WHERE Origin=@origin AND Destination=@destination)
                BEGIN
                    INSERT INTO Route (Origin, Destination, Distance, Duration)
                    VALUES (@origin, @destination, @distance, @duration)
                END
                SELECT RouteID FROM Route WHERE Origin=@origin AND Destination=@destination
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
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
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











    }
}
