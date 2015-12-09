using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Tunnit : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    XmlDocument xdoc = new XmlDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Tarkistetaan onko käyttäjä kirjautunut sisään
        if (Session["name"] != null)
        {
            
            LinkButton1.Text = "Logout";
        }
        else
        {
            
            LinkButton1.Text = "Login";
        }

        LoadWorks();


    }

    private void LoadWorks()
    {
        DataColumn col = new DataColumn();
        dt.Columns.Add("name", typeof (string));
        dt.Columns.Add("workname", typeof (string));
        dt.Columns.Add("date", typeof(string));
        dt.Columns.Add("hours", typeof(Int32));
        dt.Columns.Add("minutes", typeof(Int32));

        xdoc.Load(Server.MapPath("Xml/works.xml"));

        foreach (XmlNode node in xdoc.DocumentElement)
        {
            string name = node["name"].InnerText;
            string workname = node["workname"].InnerText;
            string date = node["date"].InnerText;
            int hour = Convert.ToInt32(node["hours"].InnerText);
            int minutes = Convert.ToInt32(node["minutes"].InnerText);

            dt.Rows.Add(name, workname, date, hour, minutes);
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();


        object SumTotalHours;
        SumTotalHours = dt.Compute("Sum(hours)", "");

        object SumTotalMinutes;
        SumTotalMinutes = dt.Compute("Sum(minutes)", "");

        int tunnit = Convert.ToInt32(SumTotalHours);
        int minuutit = Convert.ToInt32(SumTotalMinutes);
      


        if (minuutit >= 60)
        {   
            //tunnits kokonaistunnit minuuteista
            int tunnits = minuutit/60;
            // tulos on tunnit + kokonaistunnit minuuteista
            int tulos = tunnit + tunnits;
            // minutesj on jakojäännös kun otetaan kokonaistunnit minuutesta
            int minutesj = minuutit%60;
            Label1.Text = tulos.ToString()+"tuntia";
            Label2.Text = minutesj.ToString()+"minuuttia";

        }

      
        


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