using BooksStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksStore.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Libary : ContentPage
	{
        BooksViewModel viewModel;


        public Libary ()
		{
			InitializeComponent ();
            viewModel = new BooksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Books.Count == 0)
                viewModel.LoadBooksCommand.Execute(null);

            Grid grid = new Grid();
            int numberOfColumn = 3;
            for (int i = 0; i < numberOfColumn; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int rowIndex = 0;
            int columnIndex = 0;
            foreach (var book in viewModel.Books)
            {
                Label label = new Label
                {
                    Text = book.Name,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                grid.Children.Add(label, columnIndex, rowIndex);
                columnIndex++;
                if (columnIndex == numberOfColumn)
                {
                    grid.RowDefinitions.Add(new RowDefinition());
                    rowIndex++;
                    columnIndex = 0;
                }
            }
            Content = grid;
        }
    }
}