using System;
using I_have_a_plan.Views;
using I_have_a_plan.ViewModels;
using I_have_a_plan.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace I_have_a_plan
{
    
    public partial class App : Application
    {
        ProjectManager manager;
        NotificationScheduler scheduler;
        public App()
        {
            DependencyService.Register<ViewModels.Services.IMessageService, Views.Services.MessageService>();
            InitializeComponent();
            manager = new ProjectManager();
            scheduler = new NotificationScheduler();
            if (!scheduler.IsScheduleExist())
            {
                scheduler.SetSchedule();
            }
            scheduler.SetAllAlarm();            
            MainPage = new NavigationPage(new MainAppPage(new MainAppViewModel(manager)));
        }

        protected  override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            //scheduler.SetSchedule();
            // Handle when your app resumes
        }
    }
}
