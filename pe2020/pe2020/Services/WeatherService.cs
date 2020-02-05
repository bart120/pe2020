using Newtonsoft.Json;
using pe2020.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pe2020.Services
{
    public class WeatherService : IRestDataService<WeatherData, string> 
    {
        static string API_KEY = "b40441c6c394a1074aa67f7cfd5de7d3";
        static string URL = $"https://api.openweathermap.org/data/2.5/weather?appid={API_KEY}&units=metric";

        private HttpClient httpClient;

        public WeatherService()
        {
            httpClient = new HttpClient();
        }

        public Task<bool> AddItemAsync(WeatherData item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(WeatherData item)
        {
            throw new NotImplementedException();
        }

        public async Task<WeatherData> GetItemNameAsync(string id)
        {
            WeatherData data = null;
            var response = await httpClient.GetAsync($"{URL}&q={id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<WeatherData>(content);
            }
            return data;
        }

      

        public async Task<IEnumerable<WeatherData>> GetItemsAsync()
        {
            throw new NotImplementedException();
            
        }

        public Task<bool> UpdateItemAsync(WeatherData item)
        {
            throw new NotImplementedException();
        }
    }
}
