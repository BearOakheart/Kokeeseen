using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        // ladataan polku webconfigista
        String usersXml = ConfigurationManager.AppSettings["users"];
        xdoc.Load(Server.MapPath(usersXml));

        string username = txtLogin.Text;
        string password = txtPassword.Text;

        // salaus
        using (MD5 md5Hash = MD5.Create()) {
            
            string passwordhash = GetMd5Hash(md5Hash, password);

       
                foreach (XmlNode node in xdoc.DocumentElement)
                {

                    string nameXml = node["name"].InnerText;
                    
                    string usernameXml = node["username"].InnerText;
                    string passwordXml = node["password"].InnerText;

                    if (username == usernameXml && VerifyMd5Hash(md5Hash, password, passwordhash))
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

    static string GetMd5Hash(MD5 md5Hash, string input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    // Verify a hash against a string.
    static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
    {
        // Hash the input.
        string hashOfInput = GetMd5Hash(md5Hash, input);

        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        if (0 == comparer.Compare(hashOfInput, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}