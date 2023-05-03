using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace WhatsOn.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string IconPath { get; set; }

        public DateTime DateOfEvent { get; set; }

        //public Pin Pin { get; set; }

        //Filter by Name , Categoyr (bars , clubs) , Date of event 

        public Event()
        {

        }
    }
}
