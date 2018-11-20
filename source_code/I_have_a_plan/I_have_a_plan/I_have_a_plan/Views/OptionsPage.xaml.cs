using I_have_a_plan.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_have_a_plan.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsPage : ContentPage
	{
		public OptionsPage (OptionsViewModel vm)
        { 
            BindingContext = vm;
            InitializeComponent();
        }
	}
}