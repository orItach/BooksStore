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
    public class MainCategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<MainCategory> MainCategories { get; set; }
        public Command LoadBooksCommand { get; set; }

        public MainCategoriesViewModel()
        {
            Title = "Preferences";
            MainCategories = new ObservableCollection<MainCategory>();
            LoadBooksCommand = new Command(async () => await ExecuteLoadMainCategoriesCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task ExecuteLoadMainCategoriesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                MainCategories.Clear();
                var items = await DataStore.GetMainCategoriesAsync(true);
                foreach (var item in items)
                {
                    MainCategories.Add(item);
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
