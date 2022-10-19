using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        static string id;
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
            id = Session["ID"].ToString();
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

        protected void GotoUpdateProfilePage(object sender, EventArgs e)
        {
            Session["ID"] = id;
            Response.Redirect("UpdateProfilePage.aspx");
        }
        protected void GotoUpdateLoginPage(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
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