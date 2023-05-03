using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsOn.Models;

namespace WhatsOn.Services
{
    public class MockDataStore : IDataStore<Event>
    {
        readonly List<Event> items;

        public MockDataStore()
        {
            items = new List<Event>()
            {
                new Event { Id = 1, Name = "First item", Description="This is an item description." },
                new Event { Id =2, Name = "Second item", Description="This is an item description." },
                new Event { Id = 3, Name = "Third item", Description="This is an item description." },
                new Event { Id =4, Name = "Fourth item", Description="This is an item description." },
                new Event { Id = 5, Name = "Fifth item", Description="This is an item description." },
                new Event { Id = 6, Name = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Event item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Event item)
        {
            var oldItem = items.Where((Event arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(long id)
        {
            var oldItem = items.Where((Event arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Event> GetItemAsync(long id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}