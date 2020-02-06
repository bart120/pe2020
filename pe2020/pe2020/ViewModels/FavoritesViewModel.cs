using pe2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pe2020.ViewModels
{
    public class FavoritesViewModel : BaseViewModel, INotifyPropertyChanged
    {
		public ObservableCollection<City> Cities { get; set; }


		public Command RefreshCitiesCommand { get; set; }

		public Command<City> DeleteCityCommand { get; set; }

		private bool isBusy = false;

		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}


		public FavoritesViewModel()
		{
			this.Title = "Villes favorites";
			this.RefreshCitiesCommand = new Command(async () => await ExecuteRefreshCities());
			this.DeleteCityCommand = new Command<City>(async (x) => await this.ExecuteDeleteCity(x));
			this.Cities = new ObservableCollection<City>();
			
			//App.CityService.AddCityAsync(new City { Name = "Paris", Condition = "10d" }).Wait();

			/*this.Cities = new ObservableCollection<City> {
				new City{ID = 1, Name = "Paris", Condition= "https://openweathermap.org/img/wn/10d@2x.png"},
				new City{ID = 2, Name = "Bordeaux", Condition= "https://openweathermap.org/img/wn/01d@2x.png"},
				new City{ID = 1, Name = "Paris", Condition= "https://openweathermap.org/img/wn/10d@2x.png"},
				new City{ID = 2, Name = "Bordeaux", Condition= "https://openweathermap.org/img/wn/01d@2x.png"},
				new City{ID = 1, Name = "Paris", Condition= "https://openweathermap.org/img/wn/10d@2x.png"},
				new City{ID = 2, Name = "Bordeaux", Condition= "https://openweathermap.org/img/wn/01d@2x.png"}
			};*/
			/*var task = App.CityService.GetCitiesAsync();
			task.Wait();
			var cities = task.Result;
			this.Cities = new ObservableCollection<City>(cities);*/
		}

		

		public async Task ExecuteRefreshCities()
		{
			if(IsBusy)
				return;
			IsBusy = true;
			this.Cities.Clear();
			(await App.CityService.GetCitiesAsync())?.ForEach(async (x) => {
				x.Weather = await service.GetItemNameAsync(x.Name);
				this.Cities.Add(x);
			});
			IsBusy = false;
			/*var result = await App.CityService.GetCitiesAsync();
			foreach (var item in result)
			{
				this.Cities.Add(item);
			}*/
			
		}

		public async Task ExecuteDeleteCity(City c)
		{
			await App.CityService.DeleteCityAsync(c.ID);
			//await ExecuteRefreshCities();
			this.Cities.Remove(c);
		}
	}

	/*public class CityWeather
	{
		public City City { get; set; }
		public WeatherData Wheater { get; set; }
	}*/
}
