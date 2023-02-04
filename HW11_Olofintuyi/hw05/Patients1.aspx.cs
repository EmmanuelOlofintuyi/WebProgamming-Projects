using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw05
{
	public partial class Patients1 : System.Web.UI.Page
	{
		string dbType = "Access_Patients";

		protected void Page_Load(object sender, EventArgs e)
		{
			txtMsg.Text = "";

			if (!Page.IsPostBack)
			{
				IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
				cmd.CommandText = getSQL();
				displayPatients(dbType, cmd);
			}
		}
		protected void btnAddPatient_Click(object sender, EventArgs e)
		{
			IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
			GenerateAddPatientSQL(cmd);
			displayPatients(dbType, cmd);
			Response.Redirect(Request.RawUrl);
		}

		protected void btnDeletePatient_Click(object sender, EventArgs e)
		{
			IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
			GenerateDeletePatientSQL(cmd);
			displayPatients(dbType, cmd);
			Response.Redirect(Request.RawUrl);
		}

		protected void btnUpdatePatient_Click(object sender, EventArgs e)
		{
			IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
			GenerateUpdatePatientSQL(cmd);
			displayPatients(dbType, cmd);
			Response.Redirect(Request.RawUrl);
		}

		private void displayPatients(string dbType, IDbCommand cmd)
		{
			try
			{

				cmd.Connection.Open();
				IDataReader dr = cmd.ExecuteReader();

				txtMsg.Text += "IDbConnection.State: " + cmd.Connection.State.ToString() + Environment.NewLine; ;
				txtMsg.Text += "IDataReader.IsClosed: " + dr.IsClosed + Environment.NewLine;
				txtMsg.Text += "cmd.CommandText: " + cmd.CommandText + Environment.NewLine + Environment.NewLine;

				txtPatients.Text = "";

				while (dr.Read())
				{
					int id = dr.GetInt32(0);
					String lname = dr.GetString(1);
					String fname = dr.GetString(2);
					String address = dr.GetString(3);

					String patient = String.Format("{0,2:0} {1,-10:0} {2,-8:0} {3,-40:0}", id, lname, fname, address);
					txtPatients.Text += patient + Environment.NewLine;
				}

				dr.Close();
				cmd.Connection.Close();

			}
			catch (Exception ex)
			{
				txtMsg.Text = "\r\nError reading data\r\n";
				txtMsg.Text += ex.ToString();
			}
		}

		private String getSQL()
		{


			String sql =
				"SELECT " +
					"Patients.PatientID, " +
					"Patients.LastName, " +
					"Patients.FirstName, " +
					"Patients.Address " +
				"FROM " +
					"Patients " +
				"ORDER BY " + "Patients.LastName Asc";

			return sql;

		}
		private void GenerateAddPatientSQL(IDbCommand cmd)
		{
			cmd.CommandText = "Insert Into " +
				"Patients " +
				"( LastName, FirstName, Address ) " +
				"Values " +
				"( @LastName, @FirstName, @Address )";

			// Clear parameters and add new ones.
			cmd.Parameters.Clear();
			addParameter("@LastName", txtAddLName.Text, cmd);
			addParameter("@FirstName", txtAddFName.Text, cmd);
			addParameter("@Address", txtAddAddress.Text, cmd);
		}

		private void GenerateDeletePatientSQL(IDbCommand cmd)
		{
			cmd.CommandText = "Delete From " +
				"Patients " +
				"Where " +
				"PatientID=@PatientID";

			cmd.Parameters.Clear();
			addParameter("@PatientID", txtDelID.Text, cmd);
		}
		private void GenerateUpdatePatientSQL(IDbCommand cmd)
		{
			cmd.CommandText = "UPDATE " +
					"Patients " +
					"Set " +
					"LastName=@LastName, " +
					"FirstName=@FirstName, " +
					"Address=@Address " +
					"Where " +
					 "PatientID=@PatientID";
			cmd.Parameters.Clear();
			addParameter("@LastName", txtUpdLName.Text, cmd);
			addParameter("@FirstName", txtUpdFName.Text, cmd);
			addParameter("@Address", txtUpdAddress.Text, cmd);
			addParameter("@PatientID", txtUpdID.Text, cmd);
		}
		private void addParameter(string paramName, string paramValue, IDbCommand cmd)
		{
			// Create a parameter.
			IDbDataParameter param = cmd.CreateParameter();
			// Name the parameter.
			param.ParameterName = paramName;
			// Assign a value to the parameter.
			param.Value = paramValue;
			// Add the parameter to the command.
			cmd.Parameters.Add(param);
		}
		private void clearInputFields()
		{
			txtAddLName.Text = "";
			txtAddFName.Text = "";
			txtAddAddress.Text = "";
			txtDelID.Text = "";
			txtUpdID.Text = "";
			txtUpdLName.Text = "";
			txtUpdFName.Text = "";
			txtUpdAddress.Text = "";
		}

	}
}