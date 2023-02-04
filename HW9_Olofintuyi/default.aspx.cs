using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW9_Olofintuyi
{
    public partial class _default : System.Web.UI.Page
    {
        private Event ev;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //e = (Event)Session["e"];
                ev = (Event)Session["event"];
                ListBox1.DataTextField = "Text";
                ListBox1.DataValueField = "Value";
                ListBox1.DataBind();

            }
            else
            {
                ev =(Event)Session["event"];
                //populateListBox1();
            }

        }

        protected void btnMakeEvent_Click(object sender, EventArgs e)
        {

            int firstSeat = int.Parse(supplyFirstSeatNumber.Text);
            int lastSeat = int.Parse(supplyLastSeatNumber.Text);
            int numberOfSeats = lastSeat - firstSeat;
            
            Event ev = new Event(supplyEventName.Text, numberOfSeats);
            Session.Add("event", ev);
            populateListBox(firstSeat, lastSeat);
            lblSeatNumber.Text = numberOfSeats.ToString();
            txtNameTicketHolder.Focus();
            


        }

        protected void btnStartOver_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            
            
            if(ev == null)
            {
                return;
            }
            int age = Convert.ToInt32(txtAgeTicketHolder.Text);
            double price = 10;
            if (age<=12)
            {
                price = 5;
            }

          

            int seatnumber = 0;
            for (int i = ListBox1.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = ListBox1.Items[i];
                if (li.Selected)
                {
                    seatnumber = Convert.ToInt32(li.Value);
                    ListBox1.Items.Remove(li);
                    --ev.AvailableSeats;
                    ev.Seats.Remove(seatnumber);
                }
            }
            Ticket t = new Ticket( txtNameTicketHolder.Text, age, seatnumber, price);
            ev.Tickets.Add(t);
            

            Session.Add("event", ev);

            txtNameTicketHolder.Text = "";
            txtNameTicketHolder.Focus();
            txtAgeTicketHolder.Text = "";

            
           

            }

        protected void btnEventSummary_Click(object sender, EventArgs e)
        {
            addSeats();

            Response.Redirect("summary.aspx");
        }

        public void populateListBox(int a, int b)
        {
            int seatNumber = a;
            
            int evetSize = b - a;
            
            for (int i = 0; i<=evetSize; i++){
                ListItem li = new ListItem(seatNumber.ToString(), seatNumber.ToString());
                ListBox1.Items.Add(li);
                seatNumber+=1;

            }

        }

        //public void populateListBox1()
        //{

        //    int seatNumber = 0;
        //    for (int i = 0; i <= ev.Seats.Count; i++)
        //    {
        //        seatNumber = ev.Seats[i];
        //        ListItem li = new ListItem(seatNumber.ToString(), seatNumber.ToString());
        //        ListBox1.Items.Add(li);
                

        //    }

        //}

        public void addSeats()
        {
            int sn = 0;
            for (int i = ListBox1.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = ListBox1.Items[i];
                sn = Convert.ToInt32(li.Value);
                ev.Seats.Add(sn);

            }
        }

        //public void removeSeats()
        //{
        //    for (int i = ListBox1.Items.Count - 1; i >= 0; i--)
        //    {
        //        ListItem li = ListBox1.Items[i];
        //        foreach (Ticket ticket in ev.Tickets)
        //        {
        //            if(ticket.TicketNumber== Convert.ToInt32(li.Value))
        //            {
        //                ev.Seats.Remove(ticket.TicketNumber);
        //            }

        //        }
        //    }
        //}
    }
}