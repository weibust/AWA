using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newMaster
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        const string CON_STR = "Data Source=ACADEMY016-VM;Initial Catalog=Contacts;Integrated Security=SSPI";
        List<Contact> myContacts = new List<Contact>();

        protected void Page_Load(object sender, EventArgs e)
        {
            phUserInfoBox.Controls.Add(LoadControl("~/myUserControl.ascx"));




            LoadContacts();

            if (Request.RequestType == "POST")
            {
                AddContact();
            }
        }






        private void AddContact()
        {
            string fname = firstname.Text;
            string ename = lastname.Text;

            if (fname.Length > 0 && ename.Length > 0)
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = CON_STR;

                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "spAddContactV2";

                myCommand.Parameters.AddWithValue("@firstName", firstname.Text);
                myCommand.Parameters.AddWithValue("@lastName", lastname.Text);

                SqlParameter paramID = new SqlParameter("@new_id", SqlDbType.Int);
                paramID.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(paramID);

                myCommand.ExecuteNonQuery();
                myContacts.Clear();
                myConnection.Close();
                LoadContacts();
                firstname.Text = "";
                lastname.Text = "";
            }
            else
            {
                string info = "<div class=\"alert alert-danger\">";
                info += "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                info += "<strong>Error!</strong>Please fill out the form correctly.";
                info += "</div>";
                LiteralInfo.Text = info;
            }
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

            if (myContacts.Count > 0)
            {
                string info = "";
                #region Some text
                info += "<div class=\"container\">";
                info += "<div class=\"table-responsive\">";
                info += "<table class=\"table\">";
                info += "<thead>";
                info += "<tr>";
                info += " <th>#</th>";
                info += " <th>Förnamn</th>";
                info += " <th>Efternamn</th>";
                info += " <th>Alternativ</th>";
                //info += " <th>SSN</th>";
                //info += " <th>&nbsp</th>";
                info += "</tr>";
                info += "</thead>";
                info += "<tbody>";
                #endregion

                int counter = 1;
                foreach (var tmpContact in myContacts)
                {
                    info += "<tr>";
                    info += $" <td>{counter++}</td>";
                    //info += $" <td><img id=\"contactImg{tmpContact.ID}\" onClick=\"showModal(this);\" src=\"Images/{tmpContact.Img}\" class=\"img-thumbnail\" alt=\"Test\" width=\"80\"></td>";
                    info += $" <td>{tmpContact.Firstname}</td>";
                    info += $" <td>{tmpContact.Lastname}</td>";
                    info += "<td>";
                    info += "<button type =\"button\" class=\"btn btn-info btn-lgSmaller\" data-toggle=\"modal\" data-target=\"#myModalShowContact\">Visa</button>";
                    info += " ";
                    info += "<button type =\"button\" class=\"btn btn-infoYellow btn-lgSmaller\" data-toggle=\"modal\" data-target=\"#myModalChangeContact\">Ändra</button>";
                    info += " ";
                    info += "<button type =\"button\" class=\"btn btn-infoRed btn-lgSmaller\" data-toggle=\"modal\" data-target=\"#myModalDeleteContact\">Ta Bort</button>";



                    //info += " <td>N/A</td>";

                    //info += " <td>";
                    //info += "  <div class=\"dropdown\">";
                    //info += "  <button class=\"btn btn-primary dropdown-toggle\" type=\"button\" data-toggle=\"dropdown\">";
                    //info += "  <span class=\"caret\"></span></button>";
                    //info += "  <ul class=\"dropdown-menu\">";
                    //info += $"   <li><a href=\"ViewContact.aspx?id={tmpContact.ID}\">View</a></li>";
                    //info += $"   <li><a href=\"EditContact.aspx?id={tmpContact.ID}\">Edit</a></li>";
                    //info += $"   <li><a href=\"DeleteContact.aspx?id={tmpContact.ID}\">Delete</a></li>";
                    //info += "  </ul>";
                    //info += "  </div>";


                    //info += $"<a href=\"ViewContact.aspx?id={tmpContact.ID}\">View</a>";
                    //info += "&nbsp;|&nbsp;";
                    //info += $"<a href=\"EditContact.aspx?id={tmpContact.ID}\">Edit</a>";
                    //info += "&nbsp;|&nbsp;";
                    //info += $"<a href=\"DeleteContact.aspx?id={tmpContact.ID}\">Delete</a>";
                    //info += " </td>";
                    //info += "</tr>";
                }

                #region Some text 
                info += "</tbody>";
                info += "</table>";
                info += "</div>";
                info += "</div>";
                #endregion

                litContactTable.Text = info;




            }
        }




        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (IsPostBack)
        //    {
        //        if (Request.RequestType == "POST")
        //        {
        //            string fname = firstname.Text;
        //            string lname = lastname.Text;
        //            //string ssn = lastname.Text;

        //            if (fname.Length > 0 && lname.Length > 0 /*&& ssn.Length > 0*/)
        //            {
        //                //Add contact
        //            }
        //            else
        //            {
        //                string info = "<div class=\"alert alert-danger\">";
        //                info += "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
        //                info += "<strong>Error!</strong>Please fill out the form correctly.";
        //                info += "</div>";
        //                LiteralInfo.Text = info;
        //            }
        //        }
        //    }
        //}






























        //if (IsPostBack)
        //{
        //    if (Request.RequestType == "POST")
        //    {
        //        int newID = 0;

        //        SqlConnection myConnection = new SqlConnection();
        //        myConnection.ConnectionString = CON_STR;

        //        try
        //        {
        //            myConnection.Open();

        //            SqlCommand myCommand = new SqlCommand();
        //            myCommand.Connection = myConnection;
        //            myCommand.CommandType = CommandType.StoredProcedure;
        //            myCommand.CommandText = "spAddContactV2";

        //            myCommand.Parameters.AddWithValue("@firstName", firstname.Text);
        //            myCommand.Parameters.AddWithValue("@lastName", lastname.Text);

        //            SqlParameter paramID = new SqlParameter("@new_id", SqlDbType.Int);
        //            paramID.Direction = ParameterDirection.Output;
        //            myCommand.Parameters.Add(paramID);

        //            int numberOfRows = myCommand.ExecuteNonQuery();
        //            //Console.WriteLine($"Added {numberOfRows} row.");

        //            newID = (int)paramID.Value;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return newID;
        //    }






    }

}
