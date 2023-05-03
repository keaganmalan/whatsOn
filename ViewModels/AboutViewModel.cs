using System;
using System.Collections.Generic;
using System.Windows.Input;
using WhatsOn.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WhatsOn.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            UsersName = "Jabu Mthembu";
            UsersPoints = "10" + " Points";
            getEvents();

        }
        public ICommand OpenWebCommand { get; }

        public string UsersName { get; }
        public string UsersPoints { get; }

        public List<Event> Events {get; set;}

        public void getEvents()
        {
            Events = new List<Event>()
            {
                new Event { Id = 1, Name = "Little Paris", Description="Bonjour.", IconPath="https://www.planetware.com/wpimages/2020/02/france-in-pictures-beautiful-places-to-photograph-eiffel-tower.jpg" },
                new Event { Id = 2, Name = "LSB", Description="DRINK DRINK DRINK", IconPath="https://thumbs.dreamstime.com/b/bottles-famous-global-beer-brands-poznan-pol-mar-including-heineken-becks-bud-miller-corona-stella-artois-san-miguel-143170440.jpg" },
                new Event { Id = 3, Name = "BABLYON", Description="For Josh", IconPath="https://s.inyourpocket.com/img/text/southafrica/johannesburg/babylon-drag-show.jpg"  },
                new Event { Id = 4, Name = "Party Bus", Description="Cheap on Daddy Dealz.",IconPath="https://www.npconline.co.za/wp-content/uploads/2019/08/Party-Bus-1.jpg" },
                new Event { Id = 5, Name = "Fifth item", Description="This is an item description." },
                new Event { Id = 6, Name = "Sixth item", Description="This is an item description." }
            };
        }
    }
}