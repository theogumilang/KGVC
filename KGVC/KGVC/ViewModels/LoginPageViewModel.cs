using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.Windows.Input;
using Xamarin.Forms;
using KGVC.Models;

namespace KGVC.ViewModels
{
    public class LoginPageViewModel
    {

        public ICommand LoginCommand { get; private set; }

        public LoginPageViewModel()
        {
            
            LoginCommand = new Command(OnLoginButtonClicked);
        }



        async void OnLoginButtonClicked(object sender)
        {
            try
            {
                var result = await App.AuthenticationClient.AcquireTokenAsync(
                    Constants.Scopes,
                    string.Empty,
                    UiOptions.SelectAccount,
                    string.Empty,
                    null,
                    Constants.Authority,
                    Constants.SignUpSignInPolicy);
                // await Navigation.PushAsync(new LogoutPage(result));
            }
            catch (MsalException ex)
            {
                if (ex.Message != null && ex.Message.Contains("AADB2C90118"))
                {
                    await OnForgotPassword();
                }
                if (ex.ErrorCode != "authentication_canceled")
                {
                    //  await DisplayAlert("An error has occurred", "Exception message: " + ex.Message, "Dismiss");
                }
            }
        }


        async Task OnForgotPassword()
        {
            try
            {
                await App.AuthenticationClient.AcquireTokenAsync(
                    Constants.Scopes,
                    string.Empty,
                    UiOptions.SelectAccount,
                    string.Empty,
                    null,
                    Constants.Authority,
                    Constants.ResetPasswordPolicy);
            }
            catch (MsalException)
            {
                // Do nothing - ErrorCode will be displayed in OnLoginButtonClicked
            }
        }


    }
}
