using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class LoginPage : System.Web.UI.Page
    {
        static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (count == 0)
            {
                Session["bgcolor"] = color.SelectedItem.Text;
                count = 1;
            }
            else
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
        }

        protected void GotoProfilePage(object sender, EventArgs e)
        {
            var LoginName = LName.Text;
            var LoginPwd = psw.Text;
            var userName = "";
            var userPWd = "";
            var id = "";
            if (LoginName != null && LoginPwd != null)
            {
                selectQuery qs = new selectQuery();
                List<string> datas = qs.SelectIUP(LoginName, LoginPwd);
                if (datas.Count == 3)
                {
                    id = datas[0];
                    userName = datas[1];
                    userPWd = datas[2];
                }
                if (userName != LoginName && userPWd != LoginPwd)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login name and password is incorrect...')", true);
                }
                else if (userName == LoginName)
                {
                    if (userPWd == LoginPwd)
                    {
                        Session["ID"] = id;
                        Response.Redirect("ProfilePage.aspx");
                    }
                    else
                    {
                        psw.Text = "";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login password is incorrect...')", true);
                    }
                }
                else
                {
                    LName.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login name is incorrect...')", true);
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

