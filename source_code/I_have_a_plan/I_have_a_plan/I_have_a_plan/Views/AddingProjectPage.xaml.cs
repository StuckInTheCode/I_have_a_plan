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
        }
    }
}