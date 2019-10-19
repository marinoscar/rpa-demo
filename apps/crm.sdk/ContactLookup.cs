using crm.client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.sdk
{
    /// <summary>
    /// Provides a way to lookup contacts in the database
    /// </summary>
    public class ContactLookup
    {
        /// <summary>
        /// Gets a <see cref="Contact"/> object
        /// </summary>
        /// <param name="contactCode">The code of the contact to extract</param>
        /// <returns>A <see cref="Contact"/> object</returns>
        /// <exception cref="ArgumentException">When the <paramref name="contactCode"/> is empty or null</exception>
        /// <exception cref="DataException">When the <paramref name="contactCode"/> does not yield any results in the lookup operation</exception>
        public Contact GetContactObject(string contactCode)
        {
            if (string.IsNullOrWhiteSpace(contactCode)) throw new ArgumentException("Invalid contact code, cannot be empty or null");
            var data = ContactData.GetContacts();
            var contact = data.SingleOrDefault(i => i.Code.ToLowerInvariant().Equals(contactCode.ToLowerInvariant()));
            if (contact == null) throw new DataException("Provided code does not returns a valid contact");
            return contact;
        }

        /// <summary>
        /// Gets a <see cref="DataTable"/> with single <see cref="DataRow"/> with the contact information
        /// </summary>
        /// <param name="contactCode">The code of the contact to extract</param>
        /// <returns>A <see cref="DataTable"/> with a single <see cref="DataRow"/> that contains the contact information</returns>
        /// <exception cref="ArgumentException">When the <paramref name="contactCode"/> is empty or null</exception>
        /// <exception cref="DataException">When the <paramref name="contactCode"/> does not yield any results in the lookup operation</exception>
        public DataTable GetContactTable(string contactCode)
        {
            return GetTable(GetContactObject(contactCode));
        }

        private DataTable GetTable(Contact contact)
        {
            var dt = new DataTable("Contact");
            dt.Columns.Add("Code",typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("County", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Zip", typeof(string));
            dt.Columns.Add("Phone1", typeof(string));
            dt.Columns.Add("Phone2", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            var row = dt.NewRow();
            dt.Rows.Add(row);
            row["Code"] = contact.Code;
            row["Name"] = contact.Name;
            row["LastName"] = contact.LastName;
            row["Company"] = contact.Company;
            row["Address"] = contact.Address;
            row["City"] = contact.City;
            row["County"] = contact.County;
            row["State"] = contact.State;
            row["Zip"] = contact.Zip;
            row["Phone1"] = contact.Phone1;
            row["Phone2"] = contact.Phone2;
            row["Email"] = contact.Email;
            return dt;
        }
    }
}
