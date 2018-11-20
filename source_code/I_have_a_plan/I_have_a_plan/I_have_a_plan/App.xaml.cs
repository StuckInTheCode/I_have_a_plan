using I_have_a_plan.Models;
using I_have_a_plan.ViewModels;
using I_have_a_plan.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace I_have_a_plan
{

    public partial class App : Application
    {
        private ProjectManager manager;
        public App()
        {
            DependencyService.Register<ViewModels.Services.IMessageService, Views.Services.MessageService>();
            InitializeComponent();
            manager = new ProjectManager();
            MainPage = new NavigationPage(new MainAppPage(new MainAppViewModel(manager)));
        }

        protected  override void OnStart()
        {
            NotificationScheduler scheduler = new NotificationScheduler();
            if (!scheduler.IsScheduleExist())
            {
                scheduler.SetSchedule();
            }
            scheduler.SetAllAlarm();
            scheduler.SetAlarm("hello", -1, DateTime.Now.AddMinutes(1));
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
