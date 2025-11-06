using System;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

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
        public (string FirstName, string LastName, string CompanyName) GetUserDetailsByEmail(string email)
        {
            try
            {
                string query = "SELECT FirstName, LastName, CompanyName FROM Users WHERE Email = @Email AND Role = 'FerryOwner'";

                using (SqlConnection conn = new SqlConnection(@"Server=BORK\SQLEXPRESS;Database=DB_FERRY_BOOKING;Trusted_Connection=True;"))
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
                                    reader["FirstName"].ToString(),
                                    reader["LastName"].ToString(),
                                    reader["CompanyName"].ToString()
                                );
                            }
                        }
                    }
                }
                return ("", "", "");
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user details: " + ex.Message);
            }
        }
    }
}