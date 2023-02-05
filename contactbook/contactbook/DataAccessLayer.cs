using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace contactbook
{
    public class DataAccessLayer
    {
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WinFormsContacts;Data Source=DESKTOP-9HFPVDN");

        public void InsertContact(Contact contact)
        {
            try
            {
                conn.Open();
                string query = " INSERT INTO Contacts (txtname, txtcompany, txtprofile, txtimage, txtemail, txtbirthdate, txtphonew, txtphonep, txtaddress) VALUES (@txtname, @txtcompany, @txtprofile, @txtimage, @txtemail, @txtbirthdate, @txtphonew, @txtphonep, @txtaddress)";

                SqlParameter txtname = new SqlParameter("@txtname", contact.txtname);
                SqlParameter txtcompany = new SqlParameter("@txtcompany", contact.txtcompany);
                SqlParameter txtprofile = new SqlParameter("@txtprofile", contact.txtprofile);
                SqlParameter txtimage = new SqlParameter("@txtimage", contact.txtimage);
                SqlParameter txtemail = new SqlParameter("@txtemail", contact.txtemail);
                SqlParameter txtbirthdate = new SqlParameter("@txtbirthdate", contact.txtbirthdate);
                SqlParameter txtphonew = new SqlParameter("@txtphonew", contact.txtphonew);
                SqlParameter txtphonep = new SqlParameter("@txtphonep", contact.txtphonep);
                SqlParameter txtaddress = new SqlParameter("@txtaddress", contact.txtaddress);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(txtname);
                command.Parameters.Add(txtcompany);
                command.Parameters.Add(txtprofile);
                command.Parameters.Add(txtimage);
                command.Parameters.Add(txtemail);
                command.Parameters.Add(txtbirthdate);
                command.Parameters.Add(txtphonew);
                command.Parameters.Add(txtphonep);
                command.Parameters.Add(txtaddress);

                command.ExecuteNonQuery();

            } 
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void  UpdateContact(Contact contact)
        {
            try
            {

                conn.Open();
                string query = " UPDATE Contacts SET txtname = @txtname, txtcompany = @txtcompany, txtprofile = @txtprofile, txtimage = @txtimage, txtemail = @txtemail, txtbirthdate = @txtbirthdate, txtphonew = @txtphonew, txtphonep = @txtphonep, txtaddress = @txtaddress WHERE Id = @Id ";

                SqlParameter Id = new SqlParameter("@Id", contact.Id);
                SqlParameter txtname = new SqlParameter("@txtname", contact.txtname);
                SqlParameter txtcompany = new SqlParameter("@txtcompany", contact.txtcompany);
                SqlParameter txtprofile = new SqlParameter("@txtprofile", contact.txtprofile);
                SqlParameter txtimage = new SqlParameter("@txtimage", contact.txtimage);
                SqlParameter txtemail = new SqlParameter("@txtemail", contact.txtemail);
                SqlParameter txtbirthdate = new SqlParameter("@txtbirthdate", contact.txtbirthdate);
                SqlParameter txtphonew = new SqlParameter("@txtphonew", contact.txtphonew);
                SqlParameter txtphonep = new SqlParameter("@txtphonep", contact.txtphonep);
                SqlParameter txtaddress = new SqlParameter("@txtaddress", contact.txtaddress);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(Id);
                command.Parameters.Add(txtname);
                command.Parameters.Add(txtcompany);
                command.Parameters.Add(txtprofile);
                command.Parameters.Add(txtimage);
                command.Parameters.Add(txtemail);
                command.Parameters.Add(txtbirthdate);
                command.Parameters.Add(txtphonew);
                command.Parameters.Add(txtphonep);
                command.Parameters.Add(txtaddress);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); };
        }

        public void DeleteContact(int id)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM Contacts WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Id", id));

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); };
        }

        public List<Contact> GetContacts(string search = null)
        {

            List<Contact> contacts = new List<Contact>();

            try
            {
                conn.Open();
                string query = " SELECT Id, txtname, txtcompany, txtprofile, txtimage, txtemail, txtbirthdate, txtphonew, txtphonep, txtaddress FROM Contacts ";

                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(search))
                {
                    query += "WHERE txtname LIKE @Search OR txtcompany LIKE @Search OR txtprofile LIKE @Search OR txtimage LIKE @Search OR txtemail LIKE @Search OR txtbirthdate LIKE @Search OR txtphonew LIKE @Search OR txtphonep LIKE @Search OR txtaddress LIKE @Search";

                    command.Parameters.Add(new SqlParameter("@Search", $"%{search}%"));
                }

                command.CommandText = query;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(new Contact
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        txtname = reader["txtname"].ToString(),
                        txtcompany = reader["txtcompany"].ToString(),
                        txtprofile = reader["txtprofile"].ToString(),
                        txtimage = reader["txtimage"].ToString(),
                        txtemail = reader["txtemail"].ToString(),
                        txtbirthdate = reader["txtbirthdate"].ToString(),
                        txtphonew = reader["txtphonew"].ToString(),
                        txtphonep = reader["txtphonep"].ToString(),
                        txtaddress = reader["txtaddress"].ToString(),

                    });
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }

            return contacts;
        }

    }
}
