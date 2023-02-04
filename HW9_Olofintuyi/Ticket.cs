using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace HW9_Olofintuyi
{
    public class Ticket
    {
        private int ticketHolderAge;
        private string ticketHolderName;
        private double price;
        private int ticketNumber;

        public Ticket(string name, int age, int ticketNumber, double price)
        {
            Age = age;
            Name = name;
            TicketNumber = ticketNumber;
            Price = price;
        }
        public string Name
        {
            get => ticketHolderName;
            set => ticketHolderName = value;


        }

        public int Age
        {
            get => ticketHolderAge;
            set => ticketHolderAge = value;
            
        }

        public int TicketNumber
        {
            get => ticketNumber;
            set => ticketNumber = value;
        }

        public double Price
        {
            get => price;
            set => price = value;
            
        }

        
    }
}