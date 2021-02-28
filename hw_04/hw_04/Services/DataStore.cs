using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hw_04.Models;

namespace hw_04.Services
{
    public class DataStore : IDataStore<Reminder>
    {
        readonly List<Reminder> Contacts;

        public DataStore()
        {
            Contacts = new List<Reminder>()
            {
                new Reminder { Id = Guid.NewGuid().ToString(), Title = "Get food", Date="2/27/21", Content="Get food for dinner." },
                new Reminder { Id = Guid.NewGuid().ToString(), Title = "Work on Mobile", Date="2/27/21",  Content="Work on mobile assignement."},
            };
        }

        public async Task<bool> AddItemAsync(Reminder contact)
        {
            Contacts.Add(contact);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Reminder contact)
        {
            var oldItem = Contacts.Where((Reminder arg) => arg.Id == contact.Id).FirstOrDefault();
            Contacts.Remove(oldItem);
            Contacts.Add(contact);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Contacts.Where((Reminder arg) => arg.Id == id).FirstOrDefault();
            Contacts.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Reminder> GetItemAsync(string id)
        {
            return await Task.FromResult(Contacts.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Reminder>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Contacts);
        }
    }
}
