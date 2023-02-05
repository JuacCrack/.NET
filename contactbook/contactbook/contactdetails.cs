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
    public partial class contactdetails : Form
    {
        private BusinessLogicLayer _businessLogicLayer;

        private Contact _Contact;
        public contactdetails()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        private void contactdetails_Load(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            SaveContact();
            this.Close();
            ((Main)this.Owner).PopulateContacts();

        }

        private void SaveContact()
        {
            Contact contact = new Contact();
            contact.txtname = txtname.Text;
            contact.txtcompany = txtcompany.Text;
            contact.txtprofile = txtprofile.Text;
            contact.txtimage = txtimage.Text;
            contact.txtemail = txtemail.Text;
            contact.txtbirthdate = txtbirthdate.Text;
            contact.txtphonew = txtphonew.Text;
            contact.txtphonep = txtphonep.Text;
            contact.txtaddress = txtaddress.Text;

            contact.Id = _Contact != null ? _Contact.Id : 0;

            _businessLogicLayer.SaveContact(contact);
        }

        public void LoadContact(Contact contact)
        {
            _Contact = contact;
            if (contact != null)
            {
                txtname.Text = contact.txtname;
                txtcompany.Text = contact.txtcompany;
                txtprofile.Text = contact.txtprofile;
                txtimage.Text = contact.txtimage;
                txtemail.Text = contact.txtemail;
                txtbirthdate.Text = contact.txtbirthdate;
                txtphonew.Text = contact.txtphonew;
                txtphonep.Text = contact.txtphonep;
                txtaddress.Text = contact.txtaddress;

            }
        }

        private void ClearForm()
        {
            txtname.Text = string.Empty;
            txtcompany.Text = string.Empty;
            txtprofile.Text = string.Empty;
            txtimage.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtbirthdate.Text = string.Empty;
            txtphonew.Text = string.Empty;
            txtphonep.Text = string.Empty;
            txtaddress.Text = string.Empty;
        }

    }
}
