using BooksStore.Models;
using BooksStore.Services;
using BooksStore.ViewModels;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preference : ContentPage
    {
        MainCategoriesViewModel mainCategoriesViewModel;

        ItemsViewModel ItemsViewModel;
        public ObservableCollection<Item> Items { get; set; }

        public Preference()
        {
            Debug.WriteLine("Hello");
            try
            {
                InitializeComponent();

                mainCategoriesViewModel = new MainCategoriesViewModel();

                mainCategoriesViewModel.LoadBooksCommand.Execute(null);

                ItemsViewModel = new ItemsViewModel();
                ItemsViewModel.LoadItemsCommand.Execute(null);
                Items = ItemsViewModel.Items;

                //MyListView.ItemsSource = mainCategoriesViewModel.MainCategories;
                //BindingContext = mainCategoriesViewModel;
                
                //sInnerStack.Children.Add(label)
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                if (mainCategoriesViewModel.MainCategories.Count == 0)
                    mainCategoriesViewModel.LoadBooksCommand.Execute(null);

                //MockDataStore mockData = new MockDataStore();
                //Items = mockData.GetItemsAsync();



                //ListView MainCategoriesList = new ListView();

                //Content = MainCategoriesList;

                //var stack = new StackLayout();
                //MainCategoriesList.BindingContext = stack;

                StackLayout allPreferencesStack;
                ScrollView allPreferences = new ScrollView
                {
                    Orientation = ScrollOrientation.Vertical,
                    Content = allPreferencesStack = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                    }
                };
                foreach (var mainCategory in mainCategoriesViewModel.MainCategories)
                {
                    StackLayout currentStack;
                    allPreferencesStack.Children.Add(new ScrollView
                    {
                        Orientation = ScrollOrientation.Horizontal,
                        HeightRequest = 150,
                        Content = currentStack = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                        }
                    });

                    //stack.Children.Add(new ScrollView { Orientation = ScrollOrientation.Horizontal });
                    foreach (var subCategory in mainCategory.SubCategories)
                    {

                        Label label = new Label
                        {
                            Text = subCategory.Topic,
                            WidthRequest = 150,
                            HeightRequest = 150
                            //VerticalOptions = LayoutOptions.Center,
                            //HorizontalOptions = LayoutOptions.Center
                        };
                        currentStack.Children.Add(label);
                    }
                }
                int x = 6;
                Content = allPreferences;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            //Grid grid = new Grid();
            //int numberOfColumn = 3;
            //for (int i = 0; i < numberOfColumn; i++)
            //{
            //    grid.ColumnDefinitions.Add(new ColumnDefinition());
            //}
            //
            //int rowIndex = 0;
            //int columnIndex = 0;
            //foreach (var book in mainCategoriesViewModel.MainCategories)
            //{
            //    Label label = new Label
            //    {
            //        Text = book.Name,
            //        VerticalOptions = LayoutOptions.Center,
            //        HorizontalOptions = LayoutOptions.Center
            //    };
            //    grid.Children.Add(label, columnIndex, rowIndex);
            //    columnIndex++;
            //    if (columnIndex == numberOfColumn)
            //    {
            //        grid.RowDefinitions.Add(new RowDefinition());
            //        rowIndex++;
            //        columnIndex = 0;
            //    }
            //
            //
            //
            //    //for (int columnIndex = 0; columnIndex < numberOfColumn; columnIndex++)
            //    //{
            //    //    Label label = new Label
            //    //    {
            //    //        Text = book.Name,
            //    //        VerticalOptions = LayoutOptions.Center,
            //    //        HorizontalOptions = LayoutOptions.Center
            //    //    };
            //    //    grid.Children.Add(label, columnIndex, rowIndex);
            //    //}
            //    //grid.RowDefinitions.Add(new RowDefinition());
            //    //rowIndex++;
            //}
            //Content = grid;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
