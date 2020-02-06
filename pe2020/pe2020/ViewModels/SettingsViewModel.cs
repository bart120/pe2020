using pe2020.Models;
using pe2020.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace pe2020.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
		private City city;

		public City City
		{
			get { return city; }
			set { SetProperty(ref city, value); }
		}

		public SettingsViewModel()
		{
			MessagingCenter.Subscribe<FavoritesPage, City>(this, "SelectedCity", (page, value) =>
			{
				this.City = value;
			});
		}

	}
}
