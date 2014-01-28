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

public partial class CharGen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonCharSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection thisConnection = new SqlConnection(
            @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
            "Database=wastelandDB");

        thisConnection.Open();
        SqlCommand thisCommand = thisConnection.CreateCommand();

        /////////////////////////////////////////////////////////
        // Insert data
        string insertTxt = "INSERT INTO Char "; //(UserID, Name, Sex, Class, Defense, Offense, Str, Int, HealthCur, HealthMax, LocationX, LocationY, Experience) ";

        insertTxt += "VALUES( '";
        insertTxt += User.Identity.Name;
        insertTxt += "', '" + TextBoxName.Text + "', '";
        insertTxt += RadioButtonListSex.Text + "', '";

        if (DropDownListClass.Text == "Scientist")
        {
            insertTxt += DropDownListClass.Text + "', 5, 15, 40, 40, 330, 96, 0)";
            thisCommand.CommandText = insertTxt;
            thisCommand.ExecuteReader();
            thisConnection.Close();

            // Scientist gets Loafers, Labcoat, and Supersoaker
            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Labcoat', 10, NULL, 5, 'This labcoat is all that remains of your once glamourous job as a scientist.', 0, 0, 'Armor', 'Chest')";
            thisCommand.ExecuteReader();
            thisConnection.Close();

            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Slacks', 5, NULL, 3, 'Dockers, Yeah they look good but the mutant ladies dont care.', 0, 0, 'Armor', 'Legs')";
            thisCommand.ExecuteReader();
            thisConnection.Close();

            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Loafers', 5, NULL, 2, 'Comfortable, brown leather loafers.  Arent you fancy!', 0, 0, 'Armor', 'Chest')";
            thisCommand.ExecuteReader();
            thisConnection.Close();

            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Supersoaker', 25, 15, NULL, 'A supersoaker filled with acid, Warning: Avoid contact with the eyes', 0, 15, 'Weapon', 'Weapon')";
            thisCommand.ExecuteReader();
            thisConnection.Close();
        }

        // SOLDIER CLASS
        else if (DropDownListClass.Text == "Soldier")
        {
            insertTxt += DropDownListClass.Text + "', 15, 5, 50, 50, 330, 96, 0)";
            thisCommand.CommandText = insertTxt;
            thisCommand.ExecuteReader();
            thisConnection.Close();

            // Soldier gets Army Jacket, Jeans, Old boots, and Nightstick
            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Army Jacket', 10, NULL, 10, 'A camouflage jacket that is tough enough to stop small stones and bottlerockets.', 5, 0, 'Armor', 'Chest')";
            thisCommand.ExecuteReader();
            thisConnection.Close();

            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Jeans', 5, NULL, 6, 'Some old cowboy jeans, offer little protection but still look good.', 0, 0, 'Armor', 'Legs')";
            thisCommand.ExecuteReader();
            thisConnection.Close();

            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Crappy Boots', 5, NULL, 6, 'Old boots that are worn out to their last few miles.', 5, 0, 'Armor', 'Chest')";
            thisCommand.ExecuteReader();
            thisConnection.Close();

            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Nightstick', 15, 10, NULL, 'This is your mutant beating nightstick.', 0, 15, 'Weapon', 'Weapon')";
            thisCommand.ExecuteReader();
            thisConnection.Close();
        }

        // Handyman Class
        else if (DropDownListClass.Text == "Handyman")
        {
            insertTxt += DropDownListClass.Text + "', 10, 10, 40, 40, 330, 96, 0)";
            thisCommand.CommandText = insertTxt;
            thisCommand.ExecuteReader();
            thisConnection.Close();

            // Handyman gets Work Vest, Jeans, Old boots, and Hammer
            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Roadworker Vest', 10, NULL, 8, 'A camouflage jacket that is tough enough to stop small stones and bottlerockets.', 5, 0, 'Armor', 'Chest')";
            thisCommand.ExecuteReader();
            thisConnection.Close();

            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Jeans', 5, NULL, 6, 'Some old cowboy jeans, offer little protection but still look good.', 0, 0, 'Armor', 'Legs')";
            thisCommand.ExecuteReader();
            thisConnection.Close();

            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Crappy Boots', 5, NULL, 6, 'Old boots that are worn out to their last few miles.', 5, 0, 'Armor', 'Chest')";
            thisCommand.ExecuteReader();
            thisConnection.Close();

            thisConnection.Open();
            thisCommand.CommandText = "INSERT INTO Inv VALUES( '" +
                User.Identity.Name + "', 'Hammer', 15, 10, NULL, 'This is your mutant crushing hammer.', 0, 15, 'Weapon', 'Weapon')";
            thisCommand.ExecuteReader();
            thisConnection.Close();
        }
    }
}
