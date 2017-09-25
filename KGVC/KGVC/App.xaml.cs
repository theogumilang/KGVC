using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KGVC.Models;
using KGVC.Views;
using Microsoft.Identity.Client;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace KGVC
{
    public partial class App : Application
    {

        public static PublicClientApplication AuthenticationClient { get; private set; }
        public App()
        {
            InitializeComponent();
            UnityContainer unityContainer = new UnityContainer();
            //  unityContainer.RegisterType<LoginService>();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));
            AuthenticationClient = new PublicClientApplication(Constants.ApplicationID);
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
