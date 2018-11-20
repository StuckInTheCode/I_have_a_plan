using I_have_a_plan.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_have_a_plan.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditingProjectPage : ContentPage
	{
        public EditingProjectViewModel viewModel { get; private set; }

        public EditingProjectPage (EditingProjectViewModel vm )
		{           
            InitializeComponent ();
            viewModel = vm;
            this.BindingContext = viewModel;
        }
        
        
	}
}