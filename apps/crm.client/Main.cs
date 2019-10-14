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
    public partial class Main : Form
    {
        private List<Contact> _contacts;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _contacts = ContactData.GetContacts().ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text;
            var contact = _contacts.FirstOrDefault(i => i.Code.ToLowerInvariant().Equals(code.ToLowerInvariant()));
            if(contact == null)
            {
                MessageBox.Show("Contact with the provided code not found", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CleanForm();
                return;
            }
            LoadContact(contact);
        }

        private void CleanForm()
        {
            txtName.Text = null;
            txtLastName.Text = null;
            txtCompany.Text = null;
            txtPhone.Text = null;
            txtEmail.Text = null;
            txtAddress.Text = null;
            txtCity.Text = null;
            txtState.Text = null;
            txtZip.Text = null;
        }

        private void LoadContact(Contact contact)
        {
            CleanForm();
            txtName.Text = contact.Name;
            txtLastName.Text = contact.LastName;
            txtCompany.Text = contact.Company;
            txtPhone.Text = contact.Phone1;
            txtEmail.Text = contact.Email;
            txtAddress.Text = contact.Address;
            txtCity.Text = contact.City;
            txtState.Text = contact.State;
            txtZip.Text = contact.Zip;
        }
    }
}
