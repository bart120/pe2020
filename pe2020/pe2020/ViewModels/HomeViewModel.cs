using pe2020.Models;
using pe2020.Views;
using System;
using System.Collections.Generic;
using System.Text;
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


        public HomeViewModel()
        {
            MessagingCenter.Subscribe<HomePage, string>(this, "UPDATE_LOCATION", async (sender, location) =>
            {
                City city = new City();
                city.Name = location;
                city.Weather = await service.GetItemNameAsync(x.Name);
                this.City = city;
            });
        }


    }
}
