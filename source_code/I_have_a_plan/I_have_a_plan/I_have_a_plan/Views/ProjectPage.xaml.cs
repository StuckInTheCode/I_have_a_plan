using I_have_a_plan.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_have_a_plan.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProjectPage : ContentPage
	{
        public ProjectViewModel ViewModel { get; private set; }

        public ProjectPage(ProjectViewModel vm)
        {
            ViewModel = vm;
            ViewModel.Navigation = this.Navigation;
            this.BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}