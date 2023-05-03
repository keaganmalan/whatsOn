using Android.Content;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsOn.Models;
using WhatsOn.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsOn.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventsPage : ContentPage
	{
		public EventsPage ()
		{
			InitializeComponent ();
		}
		public void ToggleFilterEvents(object sender, System.EventArgs e)
		{
            FilterEventsLayout.IsVisible = !FilterEventsLayout.IsVisible;
        }	
		
		public void toggleEventsStartDate(object sender, System.EventArgs e)
		{
            dtStartEventsFilter.IsVisible = !dtStartEventsFilter.IsVisible;
        }		
		
		public void toggleEventsEndDate(object sender, System.EventArgs e)
		{
            dtEndEventsFilter.IsVisible = !dtEndEventsFilter.IsVisible;
        }

		public void clearEventsFilter(object sender, System.EventArgs e)
		{
			filterName.Text = "";
			filterCategory.SelectedIndex = -1;

            chkStartDate.IsChecked = false; 
			chkEndDate.IsChecked = false;
			dtStartEventsFilter.Date = DateTime.Now; 
			dtEndEventsFilter.Date= DateTime.Now;

            var evm = ((EventsViewModel)(this.BindingContext));
            evm.refreshEvents();
        }
		public void filterEvents(object sender, System.EventArgs e)
		{
			string nameFilter = filterName.Text ??null;
			string categoryFilter = filterCategory.SelectedItem?.ToString() ?? "";

			bool filterStartDate = dtStartEventsFilter.IsVisible;
			bool filterEndDate = dtEndEventsFilter.IsVisible;

			DateTime startDate = dtStartEventsFilter.Date;
			DateTime endDate = dtEndEventsFilter.Date;

            var evm = ((EventsViewModel)(this.BindingContext));

			evm.refreshEvents();

			ObservableCollection<long> filteredEventIdsToKeep = new ObservableCollection<long>();

			foreach(Event currentEvent in evm.Events)
			{
				if(
					((!String.IsNullOrEmpty(nameFilter) && currentEvent.Name.ToLower().Contains(nameFilter)) 
					|| (currentEvent.Category == categoryFilter))
					&& (filterDateRange(filterStartDate,filterEndDate, startDate,endDate,currentEvent.DateOfEvent))
					) {
                    filteredEventIdsToKeep.Add(currentEvent.Id);
                }
			}

            List<Event> filteredEventsRemove = evm.Events.Where(x=> !filteredEventIdsToKeep.Contains(x.Id)).ToList();

            foreach (Event currentEvent in filteredEventsRemove)
            {
				evm.Events.Remove(currentEvent);
            }
        }

		public bool filterDateRange(bool filterStartDate, bool filterEndDate , DateTime startDate , DateTime endTime , DateTime DateOfEvent)
		{
			if (filterStartDate && filterEndDate)
				return DateOfEvent >= startDate && DateOfEvent <= endTime;
			else if (filterStartDate && DateOfEvent >= startDate)
				return true;
			else if (filterEndDate && DateOfEvent <= endTime)
				return true;
			else if (!filterStartDate && !filterEndDate)
				return true;

			return false;
		}

    }
}