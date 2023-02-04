using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace HW9_Olofintuyi
{
    public class Event
    {
        private string name;
        private int availableSeats;
        private List<Ticket> tickets;
        private List<int> seats;

        public Event(string name, int availableSeats)
        {
            Name = name;
            AvailableSeats = availableSeats;
            tickets = new List<Ticket>();
            seats = new List<int>();
        }
        public int AvailableSeats
        {
            get => availableSeats;
            set => availableSeats = value;
        }

        public string Name
        {
            get => name;
            set => name = value;

        }

         
        public List<Ticket> Tickets
        {
            get => tickets;
            
        }

        public List<int> Seats
        {
            get => seats;

        }
    }
}