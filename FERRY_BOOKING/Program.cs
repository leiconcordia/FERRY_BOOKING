using FERRY_BOOKING.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FERRY_BOOKING
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new StaffForm());
            //Application.Run(new OwnerForm(1, "supercat@gmail.com", "Lei", "Concordia","Supercat"));
        }
    }
}