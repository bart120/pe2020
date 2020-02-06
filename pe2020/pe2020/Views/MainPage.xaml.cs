using pe2020.Models;
using pe2020.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pe2020
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {   
            InitializeComponent();

            MessagingCenter.Subscribe<FavoritesPage, City>(this, "SelectedCity", (page, value) =>
            {
                this.Tab.CurrentPage = this.Tab.Children[2];
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //this.Tab.CurrentPage = this.Tab.Children[1];
        }
    }
}
