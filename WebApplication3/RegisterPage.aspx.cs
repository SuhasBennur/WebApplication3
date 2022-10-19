using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bgc = Session["bgcolor"].ToString();
            if (bgc == "Select Theme")
            {
                bodyID.Attributes.Add("style", "background-color: #9B01F9");
            }
            else if (bgc == "Black")
            {
                bodyID.Attributes.Add("style", "background-color: #000000");
            }
            else if (bgc == "Orange")
            {
                bodyID.Attributes.Add("style", "background-color: #FFA500");
            }
            else if (bgc == "Blue")
            {
                bodyID.Attributes.Add("style", "background-color: #0000FF");
            }
        }

        protected void Register(object sender, EventArgs e)
        {
            if (LName.Text != "" && psw.Text != "" && RName.Text != "" && LName.Text != "" && DName.Text != "" && DOB.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserLoginDetails;Integrated Security=True");
                con.Open();
                String sqlquery = "INSERT INTO [dbo].[useraccount]([Login Name],[Password],[Real Name],[Department],[Date of Birth]) values('" +
                    LName.Text.Trim() + "','" + psw.Text.Trim() + "','" + RName.Text.Trim() + "','" + DName.Text.Trim() + "','" + DOB.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                int check = cmd.ExecuteNonQuery();
                con.Close();
                if (check != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registered successfully...')", true);
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registration unsuccessfull, try again.')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fileds should not be blank.')", true);
            }
        }

        protected void color_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = color.SelectedItem.Text;
            Session["bgcolor"] = selectedText;
            if (selectedText == "Select Theme")
            {
                bodyID.Attributes.Add("style", "background-color: #9B01F9");
            }
            else if (selectedText == "Black")
            {
                bodyID.Attributes.Add("style", "background-color: #000000");
            }
            else if (selectedText == "Orange")
            {
                bodyID.Attributes.Add("style", "background-color: #FFA500");
            }
            else if (selectedText == "Blue")
            {
                bodyID.Attributes.Add("style", "background-color: #0000FF");
            }
        }
    }
}