using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace pe2020.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var location = await Geolocation.GetLocationAsync();
                //await DisplayAlert("Ici", $"latitude: {location.Latitude}, longitude: {location.Longitude}", "OK");
                var placeMark = (await Geocoding.GetPlacemarksAsync(location)).FirstOrDefault().Locality;
                //await DisplayAlert("Ici", $"{placeMark}", "OK");
                MessagingCenter.Send(this, "UPDATE_LOCATION", placeMark);
            }
            catch (PermissionException e) { }
            catch (FeatureNotSupportedException e) { }
            catch (FeatureNotEnabledException e) { }
            catch (Exception e) { }
            
        }
    }
}