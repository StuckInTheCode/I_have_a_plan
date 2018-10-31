using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using I_have_a_plan.Views;

namespace I_have_a_plan.ViewModels
{
    public class MainAppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        public ICommand Go { protected set; get; }
        public MainAppViewModel()
        {
            Go = new Command(toTheProject);
        }

        private void toTheProject(object obj)
        {
            Navigation.PushAsync(new ProjectPage());
            //throw new NotImplementedException();
        }
    }
}
