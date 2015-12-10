using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Users : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    XmlDocument xdoc = new XmlDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadUserWorks();
    }

    private void LoadUserWorks()
    {
        DataColumn col = new DataColumn();
        dt.Columns.Add("name", typeof(string));
       
      //  xdoc.Load(Server.MapPath("Xml/users.xml"));

        // ladataan polku webconfigista
        String usersXml = ConfigurationManager.AppSettings["users"];
        xdoc.Load(Server.MapPath(usersXml));

        foreach (XmlNode node in xdoc.DocumentElement)
        {
            string name = node["name"].InnerText;
          

            dt.Rows.Add(name);
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        // Käyttäjä kirjautuu sisään
        if (LinkButton1.Text == "Login" && Session["name"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            // Käyttäjä kirjautuu ulos
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }


}