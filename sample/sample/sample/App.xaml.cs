using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Sample.Pages;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Sample
{
	public partial class App : Application
	{
        public string _token;

        public static App _instance;
        
        

        public static App Instance
        {
            get
            {
                return _instance;
            }
        }
        
        public App ()
		{
			InitializeComponent();

            _instance = this;

            var mainPage = new testevideopage();
            MainPage = mainPage;

        }

        protected override void OnStart ()
		{
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
