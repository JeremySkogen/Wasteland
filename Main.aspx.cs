using System;
using System.IO;
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

public partial class Main : System.Web.UI.Page
{
    int mapWidth;
    int mapHeight;
    int mapLabelWidth = 31;
    int mapLabelHeight = 21;
    lis
    int userHealthCur;
    int userHealthMax;
    int userInt;
    int userStr;
    int userDefense;
    int userOffense;
    int posX;
    int posY;

    string selectedItem;

    string map;

    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
        getItems();


        if (this.IsPostBack)
        {
            if (Request.Form.Get("__EVENTTARGET") == "ListBoxInv")
            {
                selectedItem = Request.Form.Get("ListBoxInv");
                ShowSelectedData();
            }

            if (LabelMap.Text.StartsWith("You have encountered a"))
            {

            }

        }


        if (ListBoxInv.SelectedItem != null)
        {
            string itemName = ListBoxInv.SelectedItem.ToString();
            int cutPos = itemName.IndexOf(' ');
            itemName = itemName.Substring(0, (itemName.Length - cutPos));
            LabelItemInfo.Text = itemName;
        }
        
        // Set up labels
        string healthBar = "";
        LabelHealthStr.Text = "(" + userHealthCur.ToString() + "/" + userHealthMax.ToString() + ")";
        LabelUserName.Text = User.Identity.Name;
        LabelStr.Text = userStr.ToString();
        LabelInt.Text = userInt.ToString();
        TextBoxHealth.Text = healthBar.ToString();
        LabelLoc.Text = posX.ToString() + "," + posY.ToString();

        // Check for an encounter
        if (!LabelMap.Text.StartsWith("You have encountered a") && !encounter())
        {
            LoadMap();
            ShowMap(posX, posY);
        }
    }

    protected void getData()
    {
        SqlConnection thisConnection = new SqlConnection(
            @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
            "Database=wastelandDB");

        thisConnection.Open();
        SqlCommand thisCommand = thisConnection.CreateCommand();

        thisCommand.CommandText = "SELECT * FROM Char WHERE UserID = '" + User.Identity.Name + "'";
        SqlDataReader result = thisCommand.ExecuteReader();

        result.Read();

        userStr = result.GetInt32(4);
        userInt = result.GetInt32(5);
        userHealthCur = result.GetInt32(6);
        userHealthMax = result.GetInt32(7);
        posX = result.GetInt32(8);
        posY = result.GetInt32(9);

        thisConnection.Close();

        thisConnection.Open();
        thisCommand = thisConnection.CreateCommand();
        thisCommand.CommandText = "SELECT SUM(ItemDefense) FROM Inv WHERE UserID = '" + User.Identity.Name + "'";
        result = thisCommand.ExecuteReader();
        result.Read();
        userDefense = result.GetInt32(0);
        thisConnection.Close();

        thisConnection.Open();
        thisCommand = thisConnection.CreateCommand();
        thisCommand.CommandText = "SELECT ItemOffense FROM Inv WHERE UserID = '" + User.Identity.Name + "' and ItemLoc = 'Weapon'";
        result = thisCommand.ExecuteReader();
        result.Read();
        userOffense = result.GetInt32(0);
        thisConnection.Close();
    }

    protected void getItems()
    {
        SqlConnection thisConnection = new SqlConnection(
            @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
            "Database=wastelandDB");

        thisConnection.Open();
        SqlCommand thisCommand = thisConnection.CreateCommand();

        thisCommand.CommandText = "SELECT * FROM Inv WHERE UserID = '" + User.Identity.Name + "'";
        SqlDataReader result = thisCommand.ExecuteReader();

        result.Read();

        ListBoxInv.Items.Clear();

        string addToBox = "";

        do
        {
            addToBox += result.GetString(1);
            addToBox.TrimEnd();
            addToBox += "," + result.GetString(8);

            ListBoxInv.Items.Add(addToBox);
            addToBox = "";
        }while (result.Read()) ;

        thisConnection.Close();
    }

    protected void setPosX()
    {
        SqlConnection thisConnection = new SqlConnection(
            @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
            "Database=wastelandDB");

        thisConnection.Open();
        SqlCommand thisCommand = thisConnection.CreateCommand();
        thisCommand.CommandText = "UPDATE Char SET LocationX = " + posX + " WHERE UserID = '" + User.Identity.Name + "'";
        thisCommand.ExecuteReader();

        thisConnection.Close();
    }

    protected void setPosY()
    {
        SqlConnection thisConnection = new SqlConnection(
            @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
            "Database=wastelandDB");

        thisConnection.Open();
        SqlCommand thisCommand = thisConnection.CreateCommand();
        thisCommand.CommandText = "UPDATE Char SET LocationY = " + posY + "WHERE UserID = '" + User.Identity.Name + "'";
        thisCommand.ExecuteReader();

        thisConnection.Close();
    }

    protected void ButtonUp_Click(object sender, EventArgs e)
    {
        Move("Up");
    }

    protected void ButtonDown_Click(object sender, EventArgs e)
    {
        Move("Down");
    }

    protected void ButtonLeft_Click(object sender, EventArgs e)
    {
        Move("Left");
    }

    protected void ButtonRight_Click(object sender, EventArgs e)
    {

        Move("Right");

    }

    protected bool CanMove(string position)
    {
        if (position == "|" || position == "/" || position == "\\" || position == "_" || position == "M")
            return false;
        else
            return true;
    }

    protected void Move(string Direction)
    {
        if (Direction == "Right")
        {
            posX = posX + 1;
            setPosX();
        }
        if (Direction == "Left")
        {
            posX = posX - 1;
            setPosX();
        }
        if (Direction == "Down")
        {
            posY++;
            setPosY();
        }
        if (Direction == "Up")
        {
            posY--;
            setPosY();
        }

        if (!LabelMap.Text.StartsWith("You have encountered a"))
        {
            if (map == null)
                LoadMap();

            ShowMap(posX, posY);
        }
    }

    protected void LoadMap()
    {
        map = File.ReadAllText("map.txt");
        mapWidth = map.IndexOf('\r') + 2;
        mapHeight = map.LastIndexOf('\r') / mapWidth;
    }

    protected void ShowMap(int posX, int posY)
    {
        string up = "";
        string down = "";
        string left = "";
        string right = "";
        string resultMap = "";
        int mapStart, middleY;
        //mapWidth = mapWidth + 2;
        mapStart = ((posY - (mapLabelWidth / 2)) * mapWidth) + (posX - (mapLabelWidth / 2));
        middleY = (mapLabelHeight / 2) + 1;

        for (int i = 1; i <= mapLabelHeight; i++)
        {
            // Set Player position and get left, right chars
            if (i == middleY)
            {
                resultMap += map.Substring(mapStart, (mapLabelWidth / 2));

                // Gets the character before and after the center
                left = resultMap.Substring(resultMap.Length - 1, 1);
                right = map.Substring((mapStart + (mapLabelWidth / 2) + 1), 1);

                resultMap += "@";
                resultMap += map.Substring((mapStart + (mapLabelWidth / 2) + 1), (mapLabelWidth / 2));
                resultMap += "<BR />";
                mapStart += mapWidth;
            }
            // Get Up Char
            if (i == middleY - 1)
            {
                up = map.Substring(mapStart + (mapLabelWidth / 2), 1);
                resultMap += map.Substring(mapStart, mapLabelWidth);
                resultMap += "<BR />";
                mapStart += mapWidth;
            }
            // Get down char
            if (i == middleY + 1)
            {
                down = map.Substring(mapStart + (mapLabelWidth / 2), 1);
                resultMap += map.Substring(mapStart, mapLabelWidth);
                resultMap += "<BR />";
                mapStart += mapWidth;
            }
            else
            {
                resultMap += map.Substring(mapStart, mapLabelWidth);
                resultMap += "<BR />";
                mapStart += mapWidth;
            }

        }
        /*
        if (CanMove(up))
            ButtonUp.Visible = true;
        else
            ButtonUp.Visible = false;

        if (CanMove(down))
            ButtonDown.Visible = true;
        else
            ButtonDown.Visible = false;

        if (CanMove(left))
            ButtonLeft.Visible = true;
        else
            ButtonLeft.Visible = false;

        if (CanMove(right))
            ButtonRight.Visible = true;
        else
            ButtonRight.Visible = false;
        */

        LabelMap.Style.Value = "font-size: 14px; letter-spacing: 5px; text-align: left; line-height: 14px; vertical-align: top;";
        LabelMap.Text = resultMap;
    }

    protected void ShowSelectedData()
    {
        selectedItem = selectedItem.Trim();
        int cutPos = selectedItem.IndexOf(',') + 1;

        // Get the type(armor/weapon...)
        string selectedType = selectedItem.Substring(cutPos, (selectedItem.Length - cutPos));

        // Get the Item Name
        selectedItem = selectedItem.Remove(cutPos - 1);
        selectedItem = selectedItem.Trim();

        getItemInfo(selectedItem, selectedType);

    }

    protected void getItemInfo(string itemName, string itemCategory)
    {
        SqlConnection thisConnection = new SqlConnection(
            @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
            "Database=wastelandDB");

        thisConnection.Open();
        SqlCommand thisCommand = thisConnection.CreateCommand();

        if (itemCategory == "Armor")
        {
            thisCommand.CommandText = "SELECT * FROM ItemArmor WHERE ItemName = '" + itemName + "'";
            SqlDataReader result = thisCommand.ExecuteReader();

            result.Read();

            string addToBox = "Name: " + itemName + "<br />";
            addToBox += "Value: " + result.GetInt32(1).ToString() + "<br />";
            addToBox += "Defense: " + result.GetInt32(2).ToString() + "<br />";
            addToBox += "Description: " + result.GetString(3) + "<br />";
            addToBox += "Int Req: " + result.GetInt32(4).ToString() + "<br />";
            addToBox += "Str Req: " + result.GetInt32(5).ToString() + "<br />";

            LabelItemInfo.Text = addToBox;
        }
        else if (itemCategory == "Weapon")
        {
            thisCommand.CommandText = "SELECT * FROM ItemWeapon WHERE ItemName = '" + itemName + "'";
            SqlDataReader result = thisCommand.ExecuteReader();

            result.Read();

            string addToBox = "Name: " + itemName + "<br />";
            addToBox += "Value: " + result.GetInt32(1).ToString() + "<br />";
            addToBox += "Offense: " + result.GetInt32(2).ToString() + "<br />";
            addToBox += "Description: " + result.GetString(3) + "<br />";
            addToBox += "Int Req: " + result.GetInt32(4).ToString() + "<br />";
            addToBox += "Str Req: " + result.GetInt32(5).ToString() + "<br />";

            LabelItemInfo.Text = addToBox;
        }
        else if (itemCategory == "Misc")
        {
            thisCommand.CommandText = "SELECT * FROM ItemMisc WHERE ItemName = '" + itemName + "'";
            SqlDataReader result = thisCommand.ExecuteReader();

            result.Read();

            string addToBox = "Name: " + itemName + "<br />";
            addToBox += "Value: " + result.GetInt32(1).ToString() + "<br />";
            addToBox += "Defense: " + result.GetInt32(2).ToString() + "<br />";
            addToBox += "Description: " + result.GetString(3) + "<br />";

            LabelItemInfo.Text = addToBox;
        }

        thisConnection.Close();
    }
    

    protected bool encounter()
    {
        Random determineEncounter = new Random();
        int val = determineEncounter.Next(99);
        if (val < 10)
        {
            // Determine Enemy, SQL Block
            SqlConnection thisConnection = new SqlConnection(
                @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
                "Database=wastelandDB");
            thisConnection.Open();
            SqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT count(*) FROM Enemy WHERE Health < " + userHealthMax * 2 + " and Health > 0";
            SqlDataReader result = thisCommand.ExecuteReader();
            result.Read();
            int numEnemies = result.GetInt32(0);
            thisConnection.Close();

            // Determine which enemy will be fought
            int rand = determineEncounter.Next(1,numEnemies);

            // Get data about enemies
            thisConnection.Open();
            thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM Enemy WHERE Health < " + userHealthMax * 2 + " and Health > 0";
            result = thisCommand.ExecuteReader();

            // Loop until the enemy is reached
            for (int i = 0; i < rand; i++)
            {
                result.Read();
            }

            // Name
            String EnemyName = result.GetString(0);
            EnemyName = EnemyName.Trim();
            // Description
            String EnemyDescription = result.GetString(1);
            EnemyDescription = EnemyDescription.Trim();
            // Health
            int EnemyHealth = result.GetInt32(2);
            // Close Connection
            thisConnection.Close();

            // Get info about the enemies equipment
            thisConnection.Open();
            thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM EnemyInv WHERE Name = '" + EnemyName + "'";
            result = thisCommand.ExecuteReader();
            result.Read();

            string Arms = null;
            string Legs = null;
            string Chest = null;
            string Feet = null;
            string Head = null;
            string Weapon = null;
            if (!result.IsDBNull(1))
            {
                Arms = result.GetString(1);
                Arms = Arms.Trim();
            }
            if (!result.IsDBNull(2))
            {
                Legs = result.GetString(2);
                Legs = Legs.Trim();
            }
            if (!result.IsDBNull(3))
            {
                Chest = result.GetString(3);
                Chest = Chest.Trim();
            }
            if (!result.IsDBNull(4))
            {
                Feet = result.GetString(4);
                Feet = Feet.Trim();
            }
            if (!result.IsDBNull(5))
            {
                Head = result.GetString(5);
                Head = Head.Trim();
            }
            if (!result.IsDBNull(6))
            {
                Weapon = result.GetString(6);
                Weapon = Weapon.Trim();
            }


            thisConnection.Close();

            // Init Defense & Attack number
            int EnemyDefense = 0;
            int EnemyAttack = 0;
            string Equipment = "";

            if (Arms != null)
            {
                // Get info about Armor
                thisConnection.Open();
                thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT ItemDefense FROM ItemArmor WHERE ItemName = '" + Arms + "'";
                result = thisCommand.ExecuteReader();
                result.Read();
                EnemyDefense += result.GetInt32(0);
                thisConnection.Close();

                Equipment += Arms + ",";
            }
            if (Legs != null)
            {
                // Get info about Armor
                thisConnection.Open();
                thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT ItemDefense FROM ItemArmor WHERE ItemName = '" + Legs + "'";
                result = thisCommand.ExecuteReader();
                result.Read();
                EnemyDefense += result.GetInt32(0);
                thisConnection.Close();

                Equipment += Legs + ",";
            }
            if (Chest != null)
            {
                // Get info about Armor
                thisConnection.Open();
                thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT ItemDefense FROM ItemArmor WHERE ItemName = '" + Chest + "'";
                result = thisCommand.ExecuteReader();
                result.Read();
                EnemyDefense += result.GetInt32(0);
                thisConnection.Close();

                Equipment += Chest + ",";
            }
            if (Feet != null)
            {
                // Get info about Armor
                thisConnection.Open();
                thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT ItemDefense FROM ItemArmor WHERE ItemName = '" + Feet + "'";
                result = thisCommand.ExecuteReader();
                result.Read();
                EnemyDefense += result.GetInt32(0);
                thisConnection.Close();

                Equipment += Feet + ",";
            }
            if (Head != null)
            {
                // Get info about Armor
                thisConnection.Open();
                thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT ItemDefense FROM ItemArmor WHERE ItemName = '" + Head + "'";
                result = thisCommand.ExecuteReader();
                result.Read();
                EnemyDefense += result.GetInt32(0);
                thisConnection.Close();

                Equipment += Head + ",";
            }

            // Get Attack power
            if (Weapon != null)
            {
                // Get info about Armor
                thisConnection.Open();
                thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT ItemOffense FROM ItemWeapon WHERE ItemName = '" + Weapon + "'";
                result = thisCommand.ExecuteReader();
                result.Read();
                EnemyAttack += result.GetInt32(0);
                thisConnection.Close();

                Equipment += Weapon;
            }

            // Get Defense and Offense of creature
            LabelMap.Text = "You have encountered a " + EnemyName +
                ".<BR /><BR />Health: " + EnemyHealth.ToString() + "/" + EnemyHealth.ToString() +
                "<BR />Defense: " + EnemyDefense.ToString() +
                "<BR />Offense: " + EnemyAttack.ToString() +
                "<BR />Description: " + EnemyDescription +
                "<BR />Equipment: " + Equipment +
                "<BR /><BR />You can run or you can fight.";

            LabelMap.Style.Value = "font-size: 14px; letter-spacing: normal; text-align: left; line-height: normal; vertical-align: top;";
            ButtonUp.Visible = false;
            ButtonDown.Visible = false;
            ButtonLeft.Visible = false;
            ButtonRight.Visible = false;
            ButtonRun.Visible = true;
            ButtonFight.Visible = true;
            
            return true;
        }
        else
            return false;
    }



    ///////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////
    //////////     DEALS WITH THE HEALTH OF THE PLAYER          ///////////////////
    ///////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// This will refresh the health bar
    /// </summary>
    protected void drawHealth()
    {
        string healthBar = "";
        LabelHealthStr.Text = "(" + userHealthCur.ToString() + "/" + userHealthMax.ToString() + ")";

        float healthPercent = userHealthCur / userHealthMax;
        healthPercent *= 100;
        userHealthCur = ((int)healthPercent) / 3;

        for (int i = 0; i < userHealthCur; i++)
        {
            healthBar += "|";
        }
    }

    /// <summary>
    /// This Changes the health and updates the database.
    /// </summary>
    /// <param name="val"></param>
    protected void changeHealth(int val)
    {
        getData();
        userHealthCur += val;

        // SQL Block
        SqlConnection thisConnection = new SqlConnection(
            @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
            "Database=wastelandDB");
        thisConnection.Open();
        SqlCommand thisCommand = thisConnection.CreateCommand();
        thisCommand.CommandText = "UPDATE Char SET HealthCur = " + userHealthCur + " WHERE UserID = '" + User.Identity.Name + "'";
        thisCommand.ExecuteReader();
        thisConnection.Close();

        // Display new data
        drawHealth();
    }

    // Run when enemy encountered
    protected void ButtonRun_Click(object sender, EventArgs e)
    {
        LabelMap.Text = "You have successfully run away.  You Coward!";
        LabelMap.Style.Value = "font-size: 14px; letter-spacing: normal; text-align: center; line-height: normal; vertical-align: middle;";
        
        ButtonUp.Visible = true;
        ButtonDown.Visible = true;
        ButtonLeft.Visible = true;
        ButtonRight.Visible = true;
        ButtonRun.Visible = false;
        ButtonFight.Visible = false;
    }
    protected void ButtonFight_Click(object sender, EventArgs e)
    {
        attackEnemy();
    }

    protected void attackEnemy()
    {

        // Get current data on enemy
        int tempStart = LabelMap.Text.IndexOf("encountered a ") + 14;
        int tempEnd = LabelMap.Text.IndexOf(".<BR />", tempStart);
        int tempLength = tempEnd - tempStart;
        string enemyName = LabelMap.Text.Substring(tempStart, tempLength);
        
        tempStart = LabelMap.Text.IndexOf("Health: ") + 8;
        tempEnd = LabelMap.Text.IndexOf("/", tempStart);
        tempLength = tempEnd - tempStart;
        string enemyStat = LabelMap.Text.Substring(tempStart, tempLength);
        int enemyCurHealth = int.Parse(enemyStat);

        tempStart = tempEnd + 1;
        tempEnd = LabelMap.Text.IndexOf("<BR />", tempStart);
        tempLength = tempEnd - tempStart;
        enemyStat = LabelMap.Text.Substring(tempStart, tempLength);
        int enemyMaxHealth = int.Parse(enemyStat);

        tempStart = LabelMap.Text.IndexOf("Defense: ") + 9;
        tempEnd = LabelMap.Text.IndexOf("<BR />", tempStart);
        tempLength = tempEnd - tempStart;
        enemyStat = LabelMap.Text.Substring(tempStart, tempLength);
        int enemyDef = int.Parse(enemyStat);

        tempStart = LabelMap.Text.IndexOf("Offense: ") + 9;
        tempEnd = LabelMap.Text.IndexOf("<BR />", tempStart);
        tempLength = tempEnd - tempStart;
        enemyStat = LabelMap.Text.Substring(tempStart, tempLength);
        int enemyOff = int.Parse(enemyStat);

        tempStart = LabelMap.Text.IndexOf("Description: ") + 13;
        tempEnd = LabelMap.Text.IndexOf("<BR />", tempStart);
        tempLength = tempEnd - tempStart;
        string EnemyDescription = LabelMap.Text.Substring(tempStart, tempLength);

        tempStart = LabelMap.Text.IndexOf("Equipment: ") + 11;
        tempEnd = LabelMap.Text.IndexOf("<BR />", tempStart);
        tempLength = tempEnd - tempStart;
        string EnemyEquipment = LabelMap.Text.Substring(tempStart, tempLength);

        Random damageRand = new Random();
        double val = damageRand.NextDouble() * 2;

        int enemyBlock, userBlock, enemyHit, userHit;
        enemyBlock = (int)(val * enemyDef);
        val = damageRand.NextDouble() * 2;
        userBlock = (int)(val * userDefense);
        val = damageRand.NextDouble() * 2;

        enemyHit = (int)(val * enemyOff);
        val = damageRand.NextDouble() * 2;
        userHit = (int)(val * userOffense);

        int userDamage = 0;
        int enemyDamage = 0;

        if (userHit > enemyBlock)
        {
            enemyDamage = userHit - enemyBlock;
            enemyCurHealth -= enemyDamage;
            if (enemyCurHealth < 1)
            {
                enemyCurHealth = 0;
                lootEnemy(enemyName, EnemyEquipment);
                return;
            }
        }

        if (enemyHit > userBlock)
        {
            userDamage = enemyHit - userBlock;
            changeHealth(userDamage * -1);
            if (userHealthCur < 1)
            {
                // Your dead
                LabelMap.Text = "Your dead, sorry for your loss" +
            ".<BR /><BR />You were found by a fellow traveler and returned to town.";
                changeHealth(30);
                posX = 331;
                posY = 97;
                setPosY();
                setPosX();
            }
        }

        LabelMap.Text = "You have encountered a " + enemyName +
            ".<BR /><BR />You hit " + enemyName + " for " + enemyDamage.ToString() +
            " damage, and " + userDamage.ToString() + " damage is done to you." +
                "<BR /><BR />Health: " + enemyCurHealth.ToString() + "/" + enemyMaxHealth.ToString() +
                "<BR />Defense: " + enemyDef.ToString() +
                "<BR />Offense: " + enemyOff.ToString() +
                "<BR />Description: " + EnemyDescription +
                "<BR />Equipment: " + EnemyEquipment +
                "<BR /><BR />You can run or you can fight.";
    }

    protected void lootEnemy(string enemyName, string EnemyEquipment)
    {
        Random damageRand = new Random();
        int val = damageRand.Next(99);
        ButtonContinue.Visible = true;
        ButtonFight.Visible = false;
        ButtonRun.Visible = false;

        if (val < 30)
        {
            string[] lootable = EnemyEquipment.Split(',');
            val = damageRand.Next(lootable.Length);
            string enemyLoot = lootable[val];

            LabelMap.Text = "You have defeated " + enemyName +
                ".<BR /><BR />You have successfully looted " + enemyLoot + ".";


            // Determine if the looted item is armor, weapon, or misc


            // Armor
            SqlConnection thisConnection = new SqlConnection(
                @"Server=blue-mini\sqlexpress;Integrated Security=True;" +
                "Database=wastelandDB");
            thisConnection.Open();
            SqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = "select * from ItemArmor where ItemName = '" + enemyLoot + "'";
            SqlDataReader result = thisCommand.ExecuteReader();
            result.Read();

            // If the result isnt null add it to inventory
            if (!result.IsDBNull(0))
            {
                // Item is not armor
            }
            else
            {
                // Item is armor
            }
            thisConnection.Close();

        }
        else
        {
            LabelMap.Text = "You have defeated " + enemyName +
                ".<BR /><BR />You were unable to loot any items.";
        }
    }
    protected void ButtonContinue_Click(object sender, EventArgs e)
    {
        ButtonContinue.Visible = false;

        LoadMap();
        ShowMap(posX, posY);

        ButtonUp.Visible = true;
        ButtonDown.Visible = true;
        ButtonLeft.Visible = true;
        ButtonRight.Visible = true;
    }
}
