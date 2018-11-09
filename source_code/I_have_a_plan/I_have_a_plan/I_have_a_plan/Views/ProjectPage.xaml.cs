using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using I_have_a_plan.ViewModels;

namespace I_have_a_plan.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProjectPage : ContentPage
	{
        public ProjectViewModel ViewModel { get; private set; }
        public ProjectPage(ProjectViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            ViewModel.Navigation = this.Navigation;
            this.BindingContext = ViewModel;
            MessagingCenter.Subscribe<ProjectViewModel>(this, "Project cant have empty fields", (sender) => {
                // do something whenever the "Hi" message is sent
                // using the 'arg' parameter which is a string
                DisplayAlert(" ", "Project cant have empty fields", "OK");
            });
        }
    }
}