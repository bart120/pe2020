using pe2020.Models;
using pe2020.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pe2020.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {
        FavoritesViewModel viewModel;

        public FavoritesPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new FavoritesViewModel();
            
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCityPage());
            //((FavoritesViewModel)this.BindingContext).Title = "test";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //if (viewModel.Cities.Count == 0)
                viewModel.RefreshCitiesCommand.Execute(null);
            viewModel.IsBusy = false;
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagingCenter.Send(this, "SelectedCity", e.Item as City);
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            if(this.favoritesPage.ToolbarItems.Count == 1 )
            {
                this.favoritesPage.ToolbarItems.Add(
                    new ToolbarItem("Suppr.", "", () => this.viewModel.DeleteCityCommand.Execute(null))
                );
            }
            else if(!viewModel.Cities.Any(x => x.Selected))
            {
                this.favoritesPage.ToolbarItems.Remove(this.favoritesPage.ToolbarItems[1]);
            }
        }
    }
}