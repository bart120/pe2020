using pe2020.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pe2020
{
    public partial class App : Application
    {
        static CityService cityService;
        public static CityService CityService
        {
            get
            {
                if (cityService == null)
                    cityService = new CityService( Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),  "cities.db3"));
                return cityService;
            }
        }

        public App()
        {
            InitializeComponent();
            DependencyService.Register<WeatherService>();
            MainPage = new MainPage();
        }



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
