using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Admin_Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection thisConnection = new SqlConnection(
            @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
            "Database=wastelandDB");

        thisConnection.Open();
        SqlCommand thisCommand = thisConnection.CreateCommand();
        thisCommand.CommandText = "INSERT INTO Enemy VALUES ('";
        thisCommand.CommandText += TextBox2.Text + "','";
        thisCommand.CommandText += TextBox5.Text + "',";
        thisCommand.CommandText += TextBox3.Text + ",";
        thisCommand.CommandText += TextBox4.Text + ")";

        thisCommand.ExecuteReader();

        thisConnection.Close();

        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
    }
}
