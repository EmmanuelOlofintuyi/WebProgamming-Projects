using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab09_Olofintuyi
{
    public partial class page3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!Page.IsPostBack)
			{
				displayData();
			}

		}

		/// <summary>
		/// Displays the data from the Players table in a GridView.
		/// </summary>
		private void displayData()
		{
			IDbCommand cmd = getCommand();
			cmd.CommandText = getSelectSql();
			try
			{
				// Open the connection.
				cmd.Connection.Open();
				// Load data into the reader
				IDataReader dr = cmd.ExecuteReader();
				// Link the Gridview to the reader
				gvPlayers.DataSource = dr;
				// Bind the reader to GridView, i.e. put the data into the GridView.
				gvPlayers.DataBind();
				dr.Close();
				cmd.Connection.Close();
			}
			catch (Exception ex)
			{
				txtMsg.Text += ex.ToString();
			}
		}

		/// <summary>
		/// Returns a Command object that is connected to a Connection object. The Connection
		/// object has its ConnectionString property set to the value in web.config.
		/// </summary>
		/// <returns>Command object</returns>
		private IDbCommand getCommand()
		{
			IDbConnection con = new System.Data.OleDb.OleDbConnection();
			IDbCommand cmd = new System.Data.OleDb.OleDbCommand();
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["playerConnectionString"].ConnectionString;
			con.ConnectionString = connectionString;
			cmd.Connection = con;
			return cmd;
		}
		/// <summary>
		/// Returns a SQL statement that selects all the data from the Players table
		/// sorted on last name, then first name.
		/// </summary>
		/// <returns>Select SQL statement</returns>
		private string getSelectSql()
		{
			string sql =
				"SELECT " +
					"Players.PlayerID, " +
					"Players.TeamID, " +
					"Players.LName, " +
					"Players.FName, " +
					"Players.PNumber, " +
					"Players.BDate " +
				"FROM " +
					"Players " +
				"ORDER BY " +
					"Players.LName Asc, " +
					"Players.FName Asc";
			return sql;
		}

		protected void btnInsert_Click(object sender, EventArgs e)
		{
			// Create the Command object
			IDbCommand cmd = getCommand();
			// Set the Insert SQL statement into the Command
			cmd.CommandText = getInsertSql();
			// Display the SQL statement
			txtMsg.Text = "INSERT Sql statement:\n" + cmd.CommandText + "\n";
			try
			{
				// Open the connection.
				cmd.Connection.Open();
				// Inserts the row into the Players table and returns how many rows are affected.
				// If successful, this will be 1, as 1 row has been added. If not successfull,
				// then 0 will be returned.
				int rowsAffected = cmd.ExecuteNonQuery();
				txtMsg.Text += "Rows affected=" + rowsAffected + "\n";
				cmd.Connection.Close();
				// Display the updated GridView, which includes the row that was added.
				displayData();
				clearTextBoxes();
			}
			catch (Exception ex)
			{
				txtMsg.Text += ex.ToString();
			}

		}

		/// <summary>
		/// Returns a SQL statement that inserts a row into the Players table, using the 
		/// values from the text boxes for the field values in the table.
		/// </summary>
		/// <returns>Insert SQL statement</returns>
		private string getInsertSql()
		{
			string sql =
				"INSERT INTO Players " +
					"(TeamID, LName, FName, PNumber, BDate) " +
					"VALUES ( " +
					txtTeamID.Text + ", " +
					"'" + txtLName.Text + "', " +
					"'" + txtFName.Text + "', " +
					txtPNum.Text + ", " +
					"'" + txtBDate.Text + "'" +
					")";
			return sql;
		}
		/// <summary>
		/// Clear the text boxes.
		/// </summary>
		private void clearTextBoxes()
		{
			txtTeamID.Text = String.Empty;
			txtLName.Text = String.Empty;
			txtFName.Text = String.Empty;
			txtPNum.Text = String.Empty;
			txtBDate.Text = String.Empty;
		}

	}
}