using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Models;

namespace BooksStore.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        List<Book> Books;
        List<MainCategory> MainCategories;

        public MockDataStore()
        {
            Books = new List<Book>();
            MainCategories = new List<MainCategory>();
            var mockBooks = new List<Book>
            {
                new Book { Name = "First item"},
                new Book { Name = "Second item" },
                new Book { Name = "Third item" },
                new Book { Name = "Fourth item" },
                new Book { Name = "Fifth item" },
                new Book { Name = "Sixth item" },
            };

            foreach (var item in mockBooks)
            {
                Books.Add(item);
            }

            var mockMainCategories = new List<MainCategory>
            {
                new MainCategory { Topic = "First item",
                    SubCategories = new List<SubCategory>{
                        new SubCategory { Topic = "SSecond item" },
                        new SubCategory { Topic = "SThird item" },
                        new SubCategory { Topic = "SFourth item" },
                        new SubCategory { Topic = "SFifth item" },
                        new SubCategory { Topic = "SSixth item" },
                } },
                new MainCategory { Topic = "Second item" ,SubCategories = new List<SubCategory>{
                new SubCategory { Topic = "SSecond item" },
                new SubCategory { Topic = "SThird item" },
                new SubCategory { Topic = "SFourth item" },
                new SubCategory { Topic = "SFifth item" },
                new SubCategory { Topic = "SSixth item" },
                } }
                //new MainCategory { Topic = "Third item" },
                //new MainCategory { Topic = "Fourth item" },
                //new MainCategory { Topic = "Fifth item" },
                //new MainCategory { Topic = "Sixth item" },
            };

            foreach (var item in mockMainCategories)
            {
                MainCategories.Add(item);
            }


            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        #region Books
        public async Task<IEnumerable<Book>> GetBooksAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Books);
        }

        #endregion

        #region Categories
        public async Task<IEnumerable<MainCategory>> GetMainCategoriesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(MainCategories);
        }
        #endregion

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}