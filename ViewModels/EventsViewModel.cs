using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsOn.Models;
using WhatsOn.Services;
using WhatsOn.Views;
using Xamarin.Forms;

namespace WhatsOn.ViewModels
{
    public class EventsViewModel: BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged1;
        public EventsViewModel()
        {
            Title = "Test EVents";
            getEvents();
        }

        private ObservableCollection<Event> events;
        public ObservableCollection<Event> Events { 
            get { 
                return events;
            } 
            set {            
                if(PropertyChanged1 != null)
                    PropertyChanged1(this, new PropertyChangedEventArgs(nameof(Events)));
            } 
        }
        public List<string> categoryList { get { 
            
                return getAllEvents().Select(x=> x.Category).Distinct().ToList();
            } set {
               categoryList = value;
            } 
        }

        public void getEvents()
        {
            events = getAllEvents();
        }

        public ObservableCollection<Event> getAllEvents()
        {
            return new ObservableCollection<Event>()
            {
                new Event { Id = 1, Name = "Little Paris", Description="Bonjour.",DateOfEvent = new DateTime(2023,04,03), Category="Explore", IconPath="https://www.planetware.com/wpimages/2020/02/france-in-pictures-beautiful-places-to-photograph-eiffel-tower.jpg" },
                new Event { Id = 2, Name = "LSB", Description="DRINK DRINK DRINK",DateOfEvent = new DateTime(2023,04,12), Category="Bar", IconPath="https://thumbs.dreamstime.com/b/bottles-famous-global-beer-brands-poznan-pol-mar-including-heineken-becks-bud-miller-corona-stella-artois-san-miguel-143170440.jpg" },
                new Event { Id = 3, Name = "BABLYON", Description="For Josh",DateOfEvent = new DateTime(2023,05,1), Category="Club", IconPath="https://s.inyourpocket.com/img/text/southafrica/johannesburg/babylon-drag-show.jpg"  },
                new Event { Id = 4, Name = "Party Bus", Description="Cheap on Daddy Dealz.",DateOfEvent = new DateTime(2023,04,22), Category="Bar",IconPath="https://www.npconline.co.za/wp-content/uploads/2019/08/Party-Bus-1.jpg" },
                new Event { Id = 5, Name = "Fifth item", Description="This is an item description." },
                new Event { Id = 6, Name = "Sixth item", Description="This is an item description." }
            };
        }

        public void refreshEvents()
        {
            List<long> existingIds = Events.Select(x=> x.Id).ToList();

            ObservableCollection<Event> allEvents = getAllEvents();
            
            foreach(Event e in allEvents) { 
                if(!existingIds.Contains(e.Id)) {
                    Events.Add(e);
                }
            }

        }
    }
}
