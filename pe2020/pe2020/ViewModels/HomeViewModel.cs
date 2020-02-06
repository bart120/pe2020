using pe2020.Models;
using pe2020.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace pe2020.ViewModels
{
    public class HomeViewModel: BaseViewModel
    {
        private City city;

        public City City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }



        public HomeViewModel()
        {
            /*MessagingCenter.Subscribe<HomePage, string>(this, "UPDATE_LOCATION", async (sender, location) =>
            {
                City city = new City();
                city.Name = location;
                city.Weather = await service.GetItemNameAsync(x.Name);
                this.City = city;
            });*/
        }

        public async Task LoadGeoAsync()
        {
            this.IsBusy = true;
            try
            {
                var location = await Geolocation.GetLocationAsync();
                //await DisplayAlert("Ici", $"latitude: {location.Latitude}, longitude: {location.Longitude}", "OK");
                var placeMark = (await Geocoding.GetPlacemarksAsync(location)).FirstOrDefault().Locality;
                City city = new City();
                city.Name = placeMark;
                city.Weather = await service.GetItemNameAsync(city.Name);
                this.City = city;

            }
            catch (PermissionException e) { }
            catch (FeatureNotSupportedException e) { }
            catch (FeatureNotEnabledException e) { }
            catch (Exception e) { }
            finally { this.IsBusy = false; }
        }
    }
}
