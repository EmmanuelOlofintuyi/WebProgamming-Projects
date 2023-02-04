using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw05
{
	public partial class Default : System.Web.UI.Page
	{
		string dbType = "Access_Property";
		List<Property> listProperties = new List<Property>();
		double totalPrice = 0;
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!Page.IsPostBack)
			{ DisplayProperties(1); }

		}
		private void BuildStatistic(List<Property> listProperties, double totalPrice)
		{
			double priceAvg = totalPrice / listProperties.Count;
			lblAveragePrice.Text = "$" + Math.Round(priceAvg, 2);
			lblNumProperties.Text = "" + listProperties.Count;
			int aboveAvg = 0;
			foreach (Property p in listProperties)
			{
				if (p.ListPrice > priceAvg)
				{
					aboveAvg++;
				}
				lblNumAboveAvgPrice.Text = "" + aboveAvg;
			}
		}
		private String getSQL(int s)
		{
			string sql =
			"SELECT " +
				"Properties.ListPrice, " +
				"Properties.sqFeet, " +
				"Properties.Beds, " +
				"Properties.Baths, " +
				"Properties.YearBuilt " +

			"FROM " +
				"Properties " +
				"ORDER BY ";
			if (s == 0)
			{
				sql += "Properties.sqFeet ASC";
				return sql;
			}

			sql += "Properties.ListPrice ASC";

			return sql;
		}
		private void DisplayProperties(int s)
		{
			try
			{
				IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
				cmd.CommandText = getSQL(s);
				cmd.Connection.Open();
				IDataReader dr = cmd.ExecuteReader();


				while (dr.Read())
				{
					double price = dr.GetDouble(0);
					double sqFeet = dr.GetDouble(1);
					double beds = dr.GetDouble(2);
					double baths = dr.GetDouble(3);
					double year = dr.GetDouble(4);
					Property p = new Property(price, sqFeet, beds, baths, year);

					listProperties.Add(p);
					totalPrice += price;
					txtProperties.Text += String.Format("{0,8:$0,0}  {1,5:0}   {2,2:0}    {3,2:0}    {4,4:0}      {5,6:$0.00}", p.ListPrice, p.SqFeet, p.Beds, p.Baths, p.YearBuilt, p.PricePerSqFoot);

				}
				BuildStatistic(listProperties, totalPrice);
				txtMsg.Text += "Attempting to read from: Access" + " database" + Environment.NewLine;
				txtMsg.Text += "IDbConnection.State: " + cmd.Connection.State.ToString() + Environment.NewLine; ;
				txtMsg.Text += "IDataReader.IsClosed: " + dr.IsClosed + Environment.NewLine;
				txtMsg.Text += "cmd.CommandText: " + cmd.CommandText + Environment.NewLine + Environment.NewLine;



				dr.Close();
				cmd.Connection.Close();

			}
			catch (Exception ex)
			{
				txtMsg.Text = "\r\nError in SelectedIndexChanged\r\n";
				txtMsg.Text += ex.ToString();
			}
		}
		protected void rblSortType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (rblSortType.SelectedValue.Equals("Sq. Feet"))
			{
				txtProperties.Text = "";
				DisplayProperties(0);
			}
			else
			{
				txtProperties.Text = "";
				DisplayProperties(1);
			}
		}

	}
}