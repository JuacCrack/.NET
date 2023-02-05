using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contactbook
{
    public partial class Main : Form
    {
        private BusinessLogicLayer _businessLogicLayer;
        public Main()
        {
            InitializeComponent();

            _businessLogicLayer = new BusinessLogicLayer();

        }

        #region EVENTS
        private void btnadd_Click(object sender, EventArgs e)
        {
            OpenContactDetailsDialog();
        }
        #endregion

        #region PRIVATE METHODS
        private void OpenContactDetailsDialog()
        {
            contactdetails contactDetails = new contactdetails();

            contactDetails.ShowDialog(this);
        }
        #endregion

        private void gridcontacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           DataGridViewLinkCell cell = (DataGridViewLinkCell)gridcontacts.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if(cell.Value.ToString() == "Edit")
            {
                contactdetails contactdetails = new contactdetails();
                contactdetails.LoadContact(new Contact
                {
                    Id = int.Parse((gridcontacts.Rows[e.RowIndex].Cells[0]).Value.ToString()),
                    txtname = gridcontacts.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    txtcompany = gridcontacts.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    txtprofile = gridcontacts.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    txtimage = gridcontacts.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    txtemail = gridcontacts.Rows[e.RowIndex].Cells[5].Value.ToString(),
                    txtbirthdate = gridcontacts.Rows[e.RowIndex].Cells[6].Value.ToString(),
                    txtphonew = gridcontacts.Rows[e.RowIndex].Cells[7].Value.ToString(),
                    txtphonep = gridcontacts.Rows[e.RowIndex].Cells[8].Value.ToString(),
                    txtaddress = gridcontacts.Rows[e.RowIndex].Cells[9].Value.ToString(),


                });
                contactdetails.ShowDialog(this);
            }
            else if (cell.Value.ToString() == "Delete")
                {
                DeleteContact(int.Parse((gridcontacts.Rows[e.RowIndex].Cells[0]).Value.ToString()));
                PopulateContacts();
            }
        }

        private void DeleteContact(int id)
        {
            _businessLogicLayer.DeleteContact(id);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateContacts();
        }

        public void PopulateContacts(string searchText = null)
        {
            List<Contact> contacts = _businessLogicLayer.GetContacts(searchText);
            gridcontacts.DataSource = contacts;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            PopulateContacts(txtsearch.Text);
            txtsearch.Text = string.Empty;
        }
    }
}
