using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pe2020.Services
{
    public interface IRestDataService<T, U>
    {
        Task<IEnumerable<T>> GetItemsAsync();

        Task<bool> AddItemAsync(T item);

        Task<bool> UpdateItemAsync(T item);

        Task<bool> DeleteItemAsync(T item);

        Task<T> GetItemNameAsync(U id);
    }
}
