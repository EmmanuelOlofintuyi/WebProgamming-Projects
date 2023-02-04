using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW10_Olofintuyi
{
    public partial class AlbumService : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GetArtistSuggestions();
            GetTitleSuggestions();
            GetYearSuggestions();
        }

        

        void GetArtistSuggestions()
        {
            // Get the request query 
            string strQuery = Request.QueryString["q"].ToString();

            //Create the string to be sent back in the response. 
            

            List<Album> albums = getAlbums();
            List<Album> albumMatches = new List<Album>();

            for (int i = 0; i < albums.Count; i++)
            {
                // Make sure input is smaller than the current name from the list.
                if (strQuery.Length <= albums[i].Artist.Length) { 
                    // See if the current name begins with the input string. 
                    if (albums[i].Artist.ToLower().Substring(0, strQuery.Length) == strQuery.ToLower())
                    {
                        // Add name and title as an xml element.
                        Album a = new Album(albums[i].Title, albums[i].Artist, albums[i].Year);
                        albumMatches.Add(a);
                    }
            }
                // Send the response
                string json = JsonConvert.SerializeObject(albumMatches);
                // Send the response
                Response.Write(json);
                // End the page lifecycle and send immediately.
                Response.End();


            }
        }

        void GetTitleSuggestions()
        {
            // Get the request query 
            string strQuery = Request.QueryString["q"].ToString();

            //Create the string to be sent back in the response. 

            List<Album> albums = getAlbums();
            List<Album> albumMatches = new List<Album>();

            for (int i = 0; i < albums.Count; i++)
            {
                // Make sure input is smaller than the current name from the list.
                if (strQuery.Length <= albums[i].Title.Length)
                {
                    // See if the current name begins with the input string. 
                    if (albums[i].Title.ToLower().Substring(0, strQuery.Length) == strQuery.ToLower())
                    {
                        // Add name and title as an xml element.
                        Album a = new Album(albums[i].Title, albums[i].Artist, albums[i].Year);
                        albumMatches.Add(a);
                    }
                }
                // Send the response
                string json = JsonConvert.SerializeObject(albumMatches);
                // Send the response
                Response.Write(json);
                // End the page lifecycle and send immediately.
                Response.End();


            }
        }

        void GetYearSuggestions()
        {
            // Get the request query 
            string strQuery = Request.QueryString["q"].ToString();

            //Create the string to be sent back in the response. 

            List<Album> albums = getAlbums();
            List<Album> albumMatches = new List<Album>();

            for (int i = 0; i < albums.Count; i++)
            {
                string year = albums[i].Year.ToString();
                // Make sure input is smaller than the current name from the list.
                if (strQuery.Length <= year.Length)
                {
                    // See if the current name begins with the input string. 
                    if (year.ToLower().Substring(0, strQuery.Length) == strQuery.ToLower())
                    {
                        // Add name and title as an xml element.
                        Album a = new Album(albums[i].Title, albums[i].Artist, albums[i].Year);
                        albumMatches.Add(a);
                    }
                }
                string json = JsonConvert.SerializeObject(albumMatches);
                // Send the response
                Response.Write(json);
                // End the page lifecycle and send immediately.
                Response.End();


            }
        }
        private List<Album> getAlbums()
        {
            List<Album> albums = new List<Album>();
            //An arbitrary array of names that are used as suggestions. 
            string[] titles = { "Ace", "Blood on the Tracks", "I Saw the Light", "Have You Seen Me Lately",
        "Old Memories", "Hot Dawg", "Pickin' the Blues", "Dave's Picks Volume 4",
        "High, Low and In Between", "Find Your Angel" };
            string[] artists = { "Bob Weir", "Bob Dylan", "Bill Monroe", "Carly Simon",
        "Del McCoury", "David Grisman", "Doc Watson", "Grateful Dead",
        "Townes Van Zandt", "Verlon Thompson" };
            int[] years = { 1972, 1975, 1959, 1990,
        2012, 1978, 1985, 2012,
        1971, 2014 };

            for (int i = 0; i < titles.Length; i++)
            {
                albums.Add(new Album(titles[i], artists[i], years[i]));
            }
            return albums;

        }
    }
}