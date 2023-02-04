using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW9_Olofintuyi
{
    public partial class summary : System.Web.UI.Page
    {
		private Event ev;
		
	
		protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				if (Session["event"] == null)
				{
					TextBox1.Text = "Didn't find an Event";
				}
				else
				{
					ev = (Event)Session["event"];
					Label1.Text = ev.Name;
					int count = 0;
					double price = 0;
					TextBox1.Text += "Name    Seat  Age     Price\n";
					TextBox1.Text += "----    ----  ---    ------\n";
					foreach (Ticket ticket in ev.Tickets)
					{
						TextBox1.Text += string.Format("{0,-20} {1,5} {2,10} {3,15:0.00} \n", ticket.Name, ticket.TicketNumber, ticket.Age, ticket.Price);
						count++;
						price += ticket.Price;
						//TextBox1.Text += ticket.Name + "       " +  ticket.TicketNumber + " "+  ticket.Age + " " + ticket.Price + "\n";
					}
					double priceAverage = price / count;
					TextBox1.Text += "----    ----  ---    ------\n";
					TextBox1.Text += string.Format("Tickets Sold: {0}\n", count);
					TextBox1.Text += string.Format("Tickets Available: {0}\n", ev.AvailableSeats);
					TextBox1.Text += string.Format("Total Tickets Prices: {0: 0.00}\n", price);
					TextBox1.Text += string.Format("Average Tickets Prices: {0: 0.00}\n", priceAverage);
					TextBox1.Text += "Available Seats: ";
					foreach (int seat in ev.Seats)
					{
						TextBox1.Text += string.Format("{0}, ", seat);
					}
					populateDropDown();
				}
			}
			else
			{

			}
			
				
			
		}

		protected void btnRemove_Click(object sender, EventArgs e)
		{
			for (int i = DropDownList1.Items.Count - 1; i >= 0; i--)
			{
				
				ListItem li = DropDownList1.Items[i];
				for (int j = 0; j < ev.Tickets.Count; j++) {
					Ticket t = ev.Tickets[j];
					if (li.Value==t.Name) {
						ev.Tickets.Remove(t);
							}
				}
			}
			
		}

		protected void btPurchaseMoreTickets_Click(object sender, EventArgs e)
		{
			Response.Redirect("default.aspx");
		}

		protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < RadioButtonList1.Items.Count; i++)
			{
				ListItem li = RadioButtonList1.Items[i];
				if (li.Selected)
				{
					if (li.Value == "Order Purchased")
					{
						
					}

					if (li.Value == "Name")
					{
						nameSort();
					}

					if (li.Value == "Seat")
					{
						seatSort();
					}
				}
			}

		}

		public void nameSort()
		{
			ev.Tickets.OrderBy(C=> C.Name).ThenBy(C=>C.TicketNumber).ThenBy(C => C.Price);
		}

		public void seatSort()
		{
			ev.Tickets.OrderBy(C => C.TicketNumber).ThenBy(C=>C.Name).ThenBy(C=>C.Price);
		}

		public void populateDropDown()
		{
			for (int i = 0; i < ev.Tickets.Count; i++)
			{
				Ticket t = ev.Tickets[i];
				ListItem li = new ListItem(t.Name, t.Name);
				DropDownList1.Items.Add(li);

			}
		}
	}

	
	
    }
