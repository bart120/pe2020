using pe2020.Models;
using pe2020.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pe2020.ViewModels
{
    public class AddCityViewModel : BaseViewModel
    {
        public IRestDataService<WeatherData, string> service => DependencyService.Get<IRestDataService<WeatherData, string>>();

        private INavigation navigation;

        public City City { get; set; }
        public Command AddCommand { get; set; }
        public AddCityViewModel()
        {
            this.AddCommand = new Command(async () => await ExecuteAddCommand());
            this.City = new City();
        }

        public AddCityViewModel(INavigation nav) : this()
        {
            this.navigation = nav;
        }

        private async Task ExecuteAddCommand()
        {

            var data = await service.GetItemNameAsync(this.City.Name);
            this.City.Condition = data.Weather[0].Icon;

            int id = await App.CityService.AddCityAsync(this.City);
            //this.BackToPage?.Invoke();
            var page = await this.navigation.PopAsync();
        }

        //public event Action BackToPage;
    }
}
