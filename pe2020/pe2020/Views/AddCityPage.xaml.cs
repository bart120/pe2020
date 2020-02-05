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
    public partial class AddCityPage : ContentPage
    {
        private AddCityViewModel viewModel;

        public AddCityPage()
        { 
            InitializeComponent();
            this.BindingContext = viewModel = new AddCityViewModel(Navigation);
            //viewModel.BackToPage += async () => await ViewModel_BackToPage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.cityName.Focus();
        }

        /*private async Task ViewModel_BackToPage()
        {
            await this.Navigation.PopAsync();
        }*/
    }
}