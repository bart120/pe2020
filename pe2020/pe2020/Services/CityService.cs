using pe2020.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pe2020.Services
{
    public class CityService
    {
        private readonly SQLiteAsyncConnection database;

        public CityService(string dbFile)
        {
            database = new SQLiteAsyncConnection(dbFile);
            database.CreateTableAsync<City>().Wait();
        }

        public Task<List<City>> GetCitiesAsync()
        {
            database.Table<City>().ToListAsync();
            return database.Table<City>().ToListAsync();
        }

        public Task<int> AddCityAsync(City city)
        {
            return database.InsertAsync(city);
        }
    }
}
