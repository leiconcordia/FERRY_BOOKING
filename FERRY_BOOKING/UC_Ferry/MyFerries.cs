using FERRY_BOOKING.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Ferry
{
    public partial class MyFerries : UserControl
    {
        public MyFerries()
        {
            InitializeComponent();
        }
      
        private void btnRegisterFerry_Click(object sender, EventArgs e)
        {
            FerryRegistrationForm popup = new FerryRegistrationForm();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ShowDialog();
        }

      
    }
}
