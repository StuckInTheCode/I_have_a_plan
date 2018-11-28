using System;
using I_have_a_plan.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_have_a_plan.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainAppPage : ContentPage, IAnimatable
	{
        public MainAppViewModel ViewModel { get; private set; }

        public MainAppPage (MainAppViewModel mainAppView)
		{
			InitializeComponent ();
            ViewModel = mainAppView;
            mainAppView.Navigation = this.Navigation;
            BindingContext = ViewModel;
        }

        private void projectList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ProjectPage(ViewModel.SelectedProject));
        }

        private void btnChange_Clicked(object sender, EventArgs e)
        {
            //handler for the button on android, that showing projects or tasks
            if (taskList.IsVisible)
            {
                taskList.IsVisible = projectList.IsVisible;
                projectList.IsVisible = true;
                btnChange.Text = "Return tasks";
                this.Title = "Your Projects";
            }
            else
            {
                taskList.IsVisible = projectList.IsVisible;
                projectList.IsVisible = false;
                btnChange.Text = "Open projects";
                this.Title = "Your tasks";
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (popupLoadingView.IsVisible == false)
            {
                popupLoadingView.IsVisible = true;
                top.IsVisible = false;
            }
            else
            {
                popupLoadingView.IsVisible = false;
                top.IsVisible = true;
            }
        }
    }
}