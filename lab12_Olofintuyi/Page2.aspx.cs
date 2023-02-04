using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab12_Olofintuyi
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

		protected string ConvertDateToLevel(DateTime dt)
		{
			TimeSpan ts = DateTime.Now - dt;
			int days = ts.Days;

			if (days < 6570)  // 18 years old
				return "Beginner";
			else if (days < 8030) // 22 years old
				return "Intermediate";
			else
				return "Advanced";
		}

		protected void gvPlayers_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			// Only color code if NOT in edit mode. The EditIndex property is the index of
			// the row being edited, or -1 if not being editted.
			if (gvPlayers.EditIndex == -1)
			{
				// Only attempt to color code if the row contains data. In other words,
				// the top row is the column headers and we are not interested in that.
				// Nor are we interested in the footer row.
				// Note that the event arg, "e" contains a reference to the current row.
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					// Obtain a reference to the label that contains the Level
					Label l = (Label)e.Row.FindControl("gvLblLevel");
					// If the Level is Beginner, color the row.
					if (l.Text.Equals("Beginner"))
					{
						//l.ForeColor = System.Drawing.Color.White;
						e.Row.BackColor = System.Drawing.Color.Blue;
						e.Row.ForeColor = System.Drawing.Color.White;
					}
				}
			}
		}

	}
}