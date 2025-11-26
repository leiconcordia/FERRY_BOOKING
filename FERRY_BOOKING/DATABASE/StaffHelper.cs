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
            
                    // Get DISTINCT routes across all ferries
                    string query = @"
                SELECT DISTINCT 
                    r.RouteID, 
                    r.Origin + ' -> ' + r.Destination AS RouteDisplay,
                    r.Origin,
                    r.Destination
                FROM Route r
                INNER JOIN Trip t ON t.RouteID = r.RouteID
                WHERE t.TripStatus = 'Active'
                  AND t.TripDate >= CAST(GETDATE() AS DATE)
                ORDER BY r.Origin, r.Destination
            ";
            
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
                MessageBox.Show("Error fetching routes: " + ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public (string Company, string FerryName, string Route, string DepartureTime, string TripDate, string ArrivalTime, string Origin, string Destination) GetFerryTripDetails(int ferryID, int tripID)
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
                        r.Origin,
                        r.Destination,
                        r.Origin + ' --> ' + r.Destination AS Route,
                        FORMAT(t.DepartureTime,'hh:mm tt') AS DepartureTime,
                        FORMAT(t.ArrivalTime,'hh:mm tt')   AS ArrivalTime,
                        FORMAT(t.TripDate, 'dd MMM yyyy')  AS TripDate
                            FROM Ferry f
                            INNER JOIN Users u ON u.UserID = f.OwnerID
                            INNER JOIN Trip t ON t.FerryID = f.FerryID
                            INNER JOIN Route r ON r.RouteID = t.RouteID
                            WHERE f.FerryID = @ferryID
                              AND t.TripID  = @tripID
                              AND t.TripStatus  = 'Active';  
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
                                    reader["DepartureTime"].ToString(),
                                    reader["TripDate"].ToString(),
                                    reader["ArrivalTime"].ToString(),
                                    reader["Origin"].ToString(),
                                    reader["Destination"].ToString()
                                );
                            }
                            else
                            { 
                                return ("Not Found", "Not Found", "Not Found", "Not Found", "Not Found", "Not Found", "Not Found", "Not Found");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching ferry trip details: " + ex.Message);
                return ("Error", "Error", "Error", "Error", "Error", "Error", "Error", "Error");
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

        // Returns the price for a given trip + floor (natural key)
        public decimal GetTripFloorPrice(int tripID, int floorNumber)
        {
            const string sql =
                "SELECT Price FROM TripFloorPrice WHERE TripID = @t AND FloorNumber = @f";

            SqlParameter[] p =
            {
        new SqlParameter("@t", tripID),
        new SqlParameter("@f", floorNumber)
    };

            object result = db.ExecuteScalar(sql, p);
            return result == null ? 0.00m : Convert.ToDecimal(result);
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

        public long SaveBookingHeader(string bookingRef, int tripID, decimal totalAmount)
        {
            const string sql =
                "INSERT INTO Booking(BookingRef, TripID, TotalAmount, BookingDate) " +
                "VALUES (@br, @t, @amt, GETDATE()); " +
                "SELECT SCOPE_IDENTITY();";

            SqlParameter[] p =
            {
                new SqlParameter("@br",  bookingRef),
                new SqlParameter("@t",   tripID),
                new SqlParameter("@amt", totalAmount)
            };

            object id = db.ExecuteScalar(sql, p);   // returns bigint
            return Convert.ToInt64(id);
        }

        /* 2.  passenger --------------------------------------------------- */
        public void SavePassenger(long bookingID, string seatCode, string fullName,
                          int age, string gender, string discount,
                          decimal price, byte[] idImage, byte[] validIDImage, string contactNumber)
        {
            const string sql =
                "INSERT INTO BookingPassenger(BookingID, SeatCode, FullName, Age, Gender, " +
                "                             Discount, Price, IDImage, ValidID, ContactNumber) " +
                "VALUES (@id, @seat, @name, @age, @g, @disc, @price, @img, @validID, @contact);";

            SqlParameter[] p =
            {
                new SqlParameter("@id",       bookingID),
                new SqlParameter("@seat",     seatCode),
                new SqlParameter("@name",     fullName),
                new SqlParameter("@age",      age),
                new SqlParameter("@g",        gender),
                new SqlParameter("@disc",     string.IsNullOrEmpty(discount) ? DBNull.Value : discount),
                new SqlParameter("@price",    price),
                new SqlParameter("@img",      SqlDbType.VarBinary)   // Discount ID (optional)
                { Value = (object)idImage ?? DBNull.Value },
                new SqlParameter("@validID",  SqlDbType.VarBinary)   // Valid ID (required)
                { Value = (object)validIDImage ?? DBNull.Value },
                new SqlParameter("@contact",  contactNumber ?? string.Empty)
            };

            db.ExecuteNonQuery(sql, p);
        }


        /* 3.  seat lock ---------------------------------------------------- */
        public void InsertBookedSeat(int tripID, int ferryID, string seatNumber)
        {
            const string sql =
                "INSERT dbo.BookedSeats(TripID, FerryID, SeatNumber, BookingDate) " +
                "VALUES (@t, @f, @seat, GETDATE())";

            SqlParameter[] p =
            {
                new SqlParameter("@t",    tripID),
                new SqlParameter("@f",    ferryID),
                new SqlParameter("@seat", seatNumber)
            };
            db.ExecuteNonQuery(sql, p);
        }
    }
}
