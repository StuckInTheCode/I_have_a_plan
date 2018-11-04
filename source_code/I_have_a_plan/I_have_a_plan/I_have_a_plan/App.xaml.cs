using System;
using I_have_a_plan.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace I_have_a_plan
{
    
    public partial class App : Application
    { 

        public readonly int MAXCOUNT = 50;
        public App()
        {
            InitializeComponent();
            MAXCOUNT = 50;
            MainPage = new NavigationPage ( new MainAppPage());
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
