using I_have_a_plan.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_have_a_plan.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditingTaskPage : ContentPage
	{
        public TaskViewModel viewModel { get; private set; }

        public EditingTaskPage(TaskViewModel vm)
		{
			InitializeComponent ();
            viewModel = vm;
            this.BindingContext = viewModel;
        }
	}
}