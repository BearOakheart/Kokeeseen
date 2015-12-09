using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Tuntikirjaus : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {

            LinkButton1.Text = "Logout";
        }
        else
        {

            LinkButton1.Text = "Login";
        }


        lblName.Text = Session["name"].ToString();
    }

    protected void Selection_Change(Object sender, EventArgs e)
    {
        txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        XmlDocument xdoc = new XmlDocument();

        String name = lblName.Text;
        String workname = txtWorkname.Text;
        String date = txtDate.Text;
        String hours = txtHours.Text;
        String minutes = txtMinutes.Text;

        xdoc.Load(Server.MapPath("Xml/works.xml"));

        XmlElement father = xdoc.CreateElement("work");
        XmlElement nameXml = xdoc.CreateElement("name");
        XmlElement worknameXml = xdoc.CreateElement("workname");
        XmlElement dateXml = xdoc.CreateElement("date");
        XmlElement hoursXml = xdoc.CreateElement("hours");
        XmlElement minutesXml = xdoc.CreateElement("minutes");

        nameXml.InnerText = name;
        worknameXml.InnerText = workname;
        dateXml.InnerText = date;
        hoursXml.InnerText = hours;
        minutesXml.InnerText = minutes;

        father.AppendChild(nameXml);
        father.AppendChild(worknameXml);
        father.AppendChild(dateXml);
        father.AppendChild(hoursXml);
        father.AppendChild(minutesXml);


        xdoc.DocumentElement.AppendChild(father);

        xdoc.Save(Server.MapPath("Xml/works.xml"));
    }
}