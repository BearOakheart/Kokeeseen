using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(Server.MapPath("Xml/users.xml"));

        string username = txtLogin.Text;
        string password = txtPassword.Text;

        foreach (XmlNode node in xdoc.DocumentElement)
        {

            string nameXml = node["name"].InnerText;
            
            string usernameXml = node["username"].InnerText;
            string passwordXml = node["password"].InnerText;

            if (username == usernameXml && password == passwordXml)
            {
                lblError.Text = "Login Success!";

                Session["username"] = usernameXml;
                Session["name"] = nameXml;

                Response.Redirect("Tunnit.aspx");
            }
            else
            {
                lblError.Text = "Login failed";
            }
        }
    }
}