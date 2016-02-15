using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newMaster
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        const string CON_STR = "Data Source=ACADEMY016-VM;Initial Catalog=Contacts;Integrated Security=SSPI";
        List<Contact> myContacts = new List<Contact>();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }







        private void LoadContacts()
        {
            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand("select * from Contact", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string id = myReader["ID"].ToString();
                    string firstname = myReader["firstname"].ToString();
                    string lastname = myReader["lastname"].ToString();
                    //string birthday = myReader["birthday"].ToString().Substring(0, 10);
                    //string bnr = myReader["bnr"].ToString();

                    myContacts.Add(new Contact(id, firstname, lastname));
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }

            //if (!IsPostBack)
            //{
            //    int selIndex = lboxContacts.SelectedIndex;
            //    lboxContacts.Items.Clear();
            //    foreach (var tmpContact in myContacts)
            //    {
            //        ListItem tmpItem = new ListItem($"{tmpContact.Firstname} {tmpContact.Lastname}", tmpContact.ID);
            //        lboxContacts.Items.Add(tmpItem);

            //    }

            //    if (selIndex > 0)
            //        lboxContacts.SelectedIndex = selIndex;






        }
    }
}