using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        static string id;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserLoginDetails;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
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
        protected void Display()
        {
            id = Session["ID"].ToString();
            StringBuilder html = new StringBuilder();
            selectQuery qs = new selectQuery();
            DataTable dt = qs.SelectAllinTable(id);
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            html.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            
        }
        protected void UpdateProfilePages(object sender, EventArgs e)
        {
            if (LName.Text != "" && psw.Text != "" && RName.Text != "" && LName.Text != "" && DName.Text != "" && DOB.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [dbo].[useraccount] SET [Login Name]='" + LName.Text + "',[Password]='" + psw.Text + "'," +
                    "[Real Name]='" + RName.Text + "'," +
                    "[Department]='" + DName.Text + "'," +
                    "[Date of Birth]='" + DOB.Text + "' WHERE [ID]=" + id + "";
                int check = cmd.ExecuteNonQuery();
                selectQuery qs = new selectQuery();
                List<string> data = qs.SelectAll(id);
                if (data.Count == 6)
                {
                    LName.Text = data[0];
                    psw.Text = data[1];
                    RName.Text = data[2];
                    DName.Text = data[3];
                    DOB.Text = data[4];
                    id = data[5];
                }

                if (check != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated successfully...')", true);
                    LName.Text = ""; psw.Text = ""; RName.Text = ""; DName.Text = ""; DOB.Text = "";
                    PlaceHolder1.Controls.Clear();
                    Display();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated unsuccessfull, try again.')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fileds should not be blank.')", true);
            }
        }

        protected void GotoProfilePage(object sender, EventArgs e)
        {
            Response.Redirect("ProfilePage.aspx");
        }

        protected void GetAllDetails(object sender, EventArgs e)
        {
            if (id != null)
            {
                selectQuery qs = new selectQuery();
                List<string> data = qs.SelectAll(id);

                if (data.Count == 6)
                {
                    LName.Text = data[0];
                    psw.Text = data[1];
                    RName.Text = data[2];
                    DName.Text = data[3];
                    DOB.Text = data[4];
                    id = data[5];
                }
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