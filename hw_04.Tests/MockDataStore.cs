using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hw_04.Models;
using hw_04.Services;

namespace hw_04.Tests
{
    class MockDataStore: IDataStore<Reminder>
    {
        readonly List<Reminder> contacts;

        public MockDataStore()
        {
            contacts = new List<Reminder>()
            {
                new Reminder { Id = Guid.NewGuid().ToString(), Title = "Max", Date="43543453", Content="School" },
                new Reminder { Id = Guid.NewGuid().ToString(), Title = "Hector", Date="3453453",  Content="Personal"},
            };
        }

        public async Task<bool> AddItemAsync(Reminder contact)
        {
            contacts.Add(contact);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Reminder contact)
        {
            var oldItem = contacts.Where((Reminder arg) => arg.Id == contact.Id).FirstOrDefault();
            contacts.Remove(oldItem);
            contacts.Add(contact);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = contacts.Where((Reminder arg) => arg.Id == id).FirstOrDefault();
            contacts.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Reminder> GetItemAsync(string id)
        {
            return await Task.FromResult(contacts.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Reminder>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(contacts);
        }
    }
}
