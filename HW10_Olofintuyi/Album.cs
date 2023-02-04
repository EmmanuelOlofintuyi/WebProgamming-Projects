using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace HW10_Olofintuyi
{
    public class Album
    {
        private string title;
        private string artist;
        private int year;

        public Album(string artist, string title, int year)
        {
            Artist = artist;
            Title = title;
            Year = year;
        }

        public string Artist
        {
            get => artist;
            set => artist = value;
           
        }

        public string Title
        {
            get => title;
            set => title = value;
            
        }

        public int Year
        {
            get => year;
            set => year = value;
            
        }
    }
}