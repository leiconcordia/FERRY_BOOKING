using System;
using System.Data;
using System.Data.SqlClient;

namespace FERRY_BOOKING.DATABASE
{
    internal class StaffHelper
    {
        private readonly DatabaseHelper db = new DatabaseHelper();

        /// <summary>
        /// Inserts a default admin account if not yet existing.
        /// </summary>
        public string ValidateLogin(string userName, string password)
        {
            string query = @"SELECT Role FROM Users 
                         WHERE Username = @Username AND PasswordHash = @Password 
                         AND Status = 'active'";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", userName),
                new SqlParameter("@Password", password)
            };

            try
            {
                object result = db.ExecuteScalar(query, parameters);
                return result?.ToString() ?? string.Empty; // returns role or empty if not found
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public DataTable GetAllFerryCompanies()
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT DISTINCT CompanyName FROM Users WHERE Role='FerryOwner' AND IsActive=1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching ferry companies: " + ex.Message);
                return null;
            }
        }

        public DataTable GetAllRoutes()
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT RouteID, Origin, Destination FROM Route";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());

                        // Add a new column for display purposes
                        dt.Columns.Add("RouteDisplay", typeof(string), "Origin + ' -> ' + Destination");

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching routes: " + ex.Message);
                return null;
            }
        }

        public (string Company, string FerryName, string Route, string DepartureTime) GetFerryTripDetails(int ferryID, int tripID)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    u.CompanyName,
                    f.FerryName,
                    r.Origin + ' --> ' + r.Destination AS Route,
                    FORMAT(t.DepartureTime,'hh:mm tt') AS DepartureTime
                FROM Ferry f
                INNER JOIN Users u ON u.UserID = f.OwnerID
                INNER JOIN Trip t ON t.FerryID = f.FerryID
                INNER JOIN Route r ON r.RouteID = t.RouteID
                WHERE f.FerryID = @ferryID AND t.TripID = @tripID
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ferryID", ferryID);
                        cmd.Parameters.AddWithValue("@tripID", tripID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (
                                    reader["CompanyName"].ToString(),
                                    reader["FerryName"].ToString(),
                                    reader["Route"].ToString(),
                                    reader["DepartureTime"].ToString()
                                );
                            }
                            else
                            {
                                return ("Not Found", "Not Found", "Not Found", "Not Found");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching ferry trip details: " + ex.Message);
                return ("Error", "Error", "Error", "Error");
            }
        }



        public int GetTotalFloors(int ferryID)
        {
            string query = "SELECT TotalFloors FROM Ferry WHERE FerryID = @FerryID";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@FerryID", ferryID)
            };

            object result = db.ExecuteScalar(query, parameters);

            if (result != null && int.TryParse(result.ToString(), out int totalFloors))
            {
                return totalFloors;
            }
            else
            {
                MessageBox.Show("Unable to get TotalFloors for this ferry.");
                return 0;
            }
        }

        // Get all floors for a ferry
        public DataTable GetFloors(int ferryID)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"
            SELECT  FerryID,
                    FloorNumber,
                    Rows,
                    Columns,
                    Capacity
            FROM    FerryFloor
            WHERE   FerryID = @FerryID
            ORDER BY FloorNumber ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FerryID", ferryID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Get ferry code for a given FerryID
        public string GetFerryCode(int ferryID)
        {
            string query = "SELECT FerryCode FROM Ferry WHERE FerryID = @FerryID";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@FerryID", ferryID)
            };

            object result = db.ExecuteScalar(query, parameters);
            return result != null ? result.ToString() : "XXX";
        }



        // Return every seat code that is already booked for a given trip
        public List<string> GetBookedSeatsForTrip(int tripID)
        {
            string query =
                "SELECT SeatNumber FROM BookedSeats WHERE TripID = @TripID";

            SqlParameter[] p = { new SqlParameter("@TripID", tripID) };
            DataTable dt = db.ExecuteDataTable(query, p);

            return dt.AsEnumerable()
                     .Select(r => r.Field<string>("SeatNumber"))
                     .ToList();
        }
    }
}
