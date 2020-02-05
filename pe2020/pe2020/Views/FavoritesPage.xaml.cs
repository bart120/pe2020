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
            viewModel.RefreshCitiesCommand.Execute(null);
        }
    }
}