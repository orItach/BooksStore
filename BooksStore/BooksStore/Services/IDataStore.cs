using BooksStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksStore.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);


        Task<IEnumerable<Book>> GetBooksAsync(bool forceRefresh = false);

        Task<IEnumerable<MainCategory>> GetMainCategoriesAsync(bool forceRefresh = false);
    }
}
