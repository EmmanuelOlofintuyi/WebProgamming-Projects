using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw05
{
	public partial class Patients2 : System.Web.UI.Page
	{
		string dbType = "Access_Patients";

		protected void Page_Load(object sender, EventArgs e)
		{
			txtPatientsAboveAvg.Text = "";

			if (!Page.IsPostBack)
			{
				IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
				cmd.CommandText = getSQL();
				displayPatients(dbType, cmd);
			}
		}
		private void displayPatients(string dbType, IDbCommand cmd)
		{
			try
			{

				cmd.Connection.Open();
				IDataReader dr = cmd.ExecuteReader();

				txtPatientsAboveAvg.Text += "IDbConnection.State: " + cmd.Connection.State.ToString() + Environment.NewLine; ;
				txtPatientsAboveAvg.Text += "IDataReader.IsClosed: " + dr.IsClosed + Environment.NewLine;
				txtPatientsAboveAvg.Text += "cmd.CommandText: " + cmd.CommandText + Environment.NewLine + Environment.NewLine;

				txtPatientsAboveAvg.Text = "";

				while (dr.Read())
				{
					DateTime dtDate = (DateTime)dr.GetValue(0);
					string date = dtDate.ToString("MM/dd/yyyy");
					String lname = dr.GetString(1);
					decimal charge = dr.GetDecimal(2);


					string visit = String.Format("{0,10:0} {1,-14:0} {2,9:$0,0.00}", date, lname, charge);
					txtPatientsAboveAvg.Text += visit + Environment.NewLine;
				}

				dr.Close();
				cmd.Connection.Close();

			}
			catch (Exception ex)
			{
				txtPatientsAboveAvg.Text = "\r\nError reading data\r\n";
				txtPatientsAboveAvg.Text = cmd.CommandText;
				txtPatientsAboveAvg.Text += ex.ToString();
			}
		}
		private String getSQL()
		{
			String sql =
					"SELECT " +
					"Visits.VisitDate, " +
					"Patients.LastName, " +
					"Visits.Charge " +


				"FROM " +
					"Visits " +
				"INNER JOIN " +
				"Patients " +
				"ON " +
				"Visits.PatientID = Patients.PatientID " +
				"ORDER BY " +
				"Visits.VisitDate Asc";

			return sql;
		}


	}
}

