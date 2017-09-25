using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KGVC.Models;
using Microsoft.Identity.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KGVC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePassword : ContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        public  void ChangePasswordClicked()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://graph.windows.net/me/changePassword?api-version=1.6");
            //request.Headers.Authorization =
              //new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            //var response = await client.SendAsync(request);
            //var content = await response.Content.ReadAsStringAsync();
        }


    }
}