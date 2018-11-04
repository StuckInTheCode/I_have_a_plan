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
            this.BindingContext = ViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ViewModel.Tasks[0].Test++;
        }
    }
}