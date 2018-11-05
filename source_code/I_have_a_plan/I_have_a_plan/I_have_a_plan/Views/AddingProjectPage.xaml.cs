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
    public partial class AddingProjectPage : ContentPage
    {
        public ProjectViewModel ViewModel { get; private set; }
        public AddingProjectPage(ProjectViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
            //trying to use the messagingcenter to show the dialog
            MessagingCenter.Subscribe<MainAppViewModel>(this, "Not all field filled", (sender) =>
            {
                //get the message from viewmodel
                DisplayAlert(" ", "Not all field filled", "OK");
            });
        }
    }
}