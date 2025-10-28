using System;
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

    }
}
