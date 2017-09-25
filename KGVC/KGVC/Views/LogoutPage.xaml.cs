using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KGVC.Models;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KGVC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogoutPage : ContentPage
    {
        
        AuthenticationResult authenticationResult;

        public LogoutPage(AuthenticationResult result)
        {
            InitializeComponent();
            authenticationResult = result;
        }

        protected override void OnAppearing()
        {
            if (authenticationResult != null)
            {
                if (authenticationResult.User.Name != "unknown")
                {
                    messageLabel.Text = string.Format("Welcome {0}", authenticationResult.User.Name);
                }
                else
                {
                    messageLabel.Text = string.Format("UserId: {0}", authenticationResult.User.UniqueId);
                }
            }

            base.OnAppearing();
        }
        public async void ChangePasswordClicked(object sender, EventArgs e)
        {
            
            
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://graph.windows.net/me/changePassword?api-version=1.6");
            request.Headers.Authorization =
            
            new AuthenticationHeaderValue("Bearer", authenticationResult.Token);
            var response = await client.SendAsync(request);
            


            GraphModel.currentPassword = currentPassword.Text;
            GraphModel.newPassword = newPassword.Text;
            

            await DisplayAlert("Change Password", "Password Telah Diganti ", "OK");

            //currentPassword.Text = string.Format("currentPassword", GraphModel.currentPassword);
            //newPassword.Text = string.Format("newPassword", GraphModel.newPassword);




            //  request.Headers.Authorization =
            //  new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            //var response = await client.SendAsync(request);
            //var content = await response.Content.ReadAsStringAsync();


        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.AuthenticationClient.UserTokenCache.Clear(Constants.ApplicationID);
            await Navigation.PopAsync();
        }

       
    }
}