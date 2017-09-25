using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KGVC.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KGVC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                // Look for existing user
                var result = await App.AuthenticationClient.AcquireTokenSilentAsync(Constants.Scopes);
                await Navigation.PushAsync(new LogoutPage(result));
            }
            catch
            {
                // Do nothing - the user isn't logged in
            }
            base.OnAppearing();
        }

    }
}