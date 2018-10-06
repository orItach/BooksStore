using BooksStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BooksStore.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        public Command LoadBooksCommand { get; set; }

        public BooksViewModel()
        {
            Title = "Libery";
            Books = new ObservableCollection<Book>();
            LoadBooksCommand = new Command(async () => await ExecuteLoadBooksCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task ExecuteLoadBooksCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Books.Clear();
                var items = await DataStore.GetBooksAsync(true);
                foreach (var item in items)
                {
                    Books.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
   
}
