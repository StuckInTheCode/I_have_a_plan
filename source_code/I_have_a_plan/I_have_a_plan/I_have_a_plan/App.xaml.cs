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
        public App()
        {

            DependencyService.Register<ViewModels.Services.IMessageService, Views.Services.MessageService>();
            InitializeComponent();
            MainPage = new LoadingPage();
            manager = new ProjectManager();
            //System.Threading.Tasks.Task.Run(async () => { await manager.Initialization; });
            //manager.projectList = new List<Project>();
            //JSONSerializer JSON = new JSONSerializer();
            //System.Threading.Tasks.Task.Run(async () => { manager.projectList = await JSON.LoadProjectsFromJsonAsync(); }).Wait();
            
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
            // Handle when your app resumes
        }
    }
}
