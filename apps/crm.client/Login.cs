using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm.client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Hide();
            var frm = new Main();
            frm.ShowDialog();
            Application.Exit();
        }
    }
}
