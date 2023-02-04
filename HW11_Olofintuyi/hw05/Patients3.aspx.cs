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
	public partial class Patients3 : System.Web.UI.Page
	{
		string dbType = "Access_Patients";

		protected void Page_Load(object sender, EventArgs e)
		{
			txtVisitAndPreCharges.Text = "";

			if (!Page.IsPostBack)
			{
				ddPatients.Items.Insert(0, new ListItem("Select", "select"));
				ddPatients.Items[0].Selected = true;
				ddPatients_SelectedIndexChanged(sender, e);
			}
		}
		protected void ddPatients_SelectedIndexChanged(object sender, EventArgs e)
		{
			IDbCommand cmd = ConnectionFactory.GetCommand(dbType);

			cmd.CommandText = getSQL();
			cmd.Parameters.Clear();
			addParameter("@PatientID", ddPatients.SelectedValue, cmd);
			displayPatients(dbType, cmd);
		}
		private String getSQL()
		{
			String sql = "";
			if (ddPatients.SelectedValue.Equals("select"))
			{
				sql =
					   "SELECT " +
					   "Visits.VisitDate, " +
					   "Visits.Charge, " +

					   "Visits.VisitID, " +
					   "Prescriptions.DrugName, " +
					   "Patients.LastName, " +
						"Visits.PatientID " +

				   "FROM " +
					   "((Visits " +
				   "INNER JOIN " +
				   "Patients " +
				   "ON " +
				   "Visits.PatientID = Patients.PatientID) " +
					   "INNER JOIN " +
				   "Prescriptions " +
				   "ON " +
				   "Visits.VisitID = Prescriptions.VisitID) " +
				   "ORDER BY " +
				   "Visits.VisitDate Asc";
			}
			else
			{
				sql = "SELECT " +
					   "Visits.VisitDate, " +
					   "Visits.Charge, " +

					   "Visits.VisitID, " +
					   "Prescriptions.DrugName, " +
					   "Patients.LastName, " +
						"Visits.PatientID " +

				   "FROM " +
					   "((Visits " +
				   "INNER JOIN " +
				   "Patients " +
				   "ON " +
				   "Visits.PatientID = Patients.PatientID) " +
					   "INNER JOIN " +
				   "Prescriptions " +
				   "ON " +
				   "Visits.VisitID = Prescriptions.VisitID) " +

				   "ORDER BY " +
				   "Visits.VisitDate Asc";
			}

			return sql;
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
		private void displayPatients(string dbType, IDbCommand cmd)
		{
			try
			{

				cmd.Connection.Open();
				IDataReader dr = cmd.ExecuteReader();

				txtVisitAndPreCharges.Text += "IDbConnection.State: " + cmd.Connection.State.ToString() + Environment.NewLine; ;
				txtVisitAndPreCharges.Text += "IDataReader.IsClosed: " + dr.IsClosed + Environment.NewLine;
				txtVisitAndPreCharges.Text += "cmd.CommandText: " + cmd.CommandText + Environment.NewLine + Environment.NewLine;

				txtVisitAndPreCharges.Text = "";

				while (dr.Read())
				{
					if (ddPatients.SelectedValue.Equals("select"))
					{
						DateTime dtDate = (DateTime)dr.GetValue(0);
						string date = dtDate.ToString("MM/dd/yyyy");
						String prescription = dr.GetString(3);
						int visitID = dr.GetInt32(2);
						decimal charge = dr.GetDecimal(1);
						String lname = dr.GetString(4);
						int PatientID = dr.GetInt32(5);
						if (!ddPatients.Items.Contains(new ListItem(lname, "" + PatientID)))
						{
							ddPatients.Items.Add(new ListItem(lname, "" + PatientID));
						}
						string visit = String.Format("{0,10:0}  {1,5:$0,0.00} {2,5:0}", date, charge, visitID);
						txtVisitAndPreCharges.Text += visit + Environment.NewLine;
					}
					else
					{
						String patientId = ddPatients.SelectedValue;
						String dbPatientId = Convert.ToString(dr.GetInt32(5));
						if (patientId.Equals(dbPatientId))
						{
							DateTime dtDate = (DateTime)dr.GetValue(0);
							string date = dtDate.ToString("MM/dd/yyyy");
							String prescription = dr.GetString(3);
							int visitID = dr.GetInt32(2);
							decimal charge = dr.GetDecimal(1);
							String lname = dr.GetString(4);
							int PatientID = dr.GetInt32(5);
							if (!ddPatients.Items.Contains(new ListItem(lname, "" + PatientID)))
							{
								ddPatients.Items.Add(new ListItem(lname, "" + PatientID));
							}
							string visit = String.Format("{0,10:0}  {1,5:$0,0.00} {2,5:0}", date, charge, visitID);
							txtVisitAndPreCharges.Text += visit + Environment.NewLine;
						}
					}
				}

				dr.Close();
				cmd.Connection.Close();
			}

			catch (Exception ex)
			{
				txtVisitAndPreCharges.Text = "\r\nError reading data\r\n";
				txtVisitAndPreCharges.Text = cmd.CommandText;
				txtVisitAndPreCharges.Text += ex.ToString();
			}


		}
	}
}
