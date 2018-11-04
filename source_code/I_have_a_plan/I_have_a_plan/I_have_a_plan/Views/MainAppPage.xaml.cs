using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I_have_a_plan.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_have_a_plan.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainAppPage : ContentPage
	{
        public MainAppViewModel ViewModel { get; private set; }
        public MainAppPage ()
		{
			InitializeComponent ();
            ViewModel = new MainAppViewModel() { Navigation = this.Navigation };
            BindingContext = ViewModel;

        }

        private void showAlert(object sender, EventArgs e) {
            DisplayAlert("Alert", "You have been alerted", "OK");
        }

        private void projectList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ProjectPage(ViewModel.SelectedProject));
        }
    }
}