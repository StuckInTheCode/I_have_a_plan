using System;
using System.Collections.Generic;
using System.Text;
using I_have_a_plan.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;

namespace I_have_a_plan.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TaskViewModel> Tasks { get; set; }
        ProjectViewModel lvm;
        static double test;
        public Task Task { get; private set; }

        public TaskViewModel()
        {
            Task = new Task();
            Task.name ="task";
            test = 0.5;
        }

        public ProjectViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return Task.name; }
            set
            {
                if (Task.name != value)
                {
                    Task.name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public Int32 PercentageFinished
        {
            get { return Task.convertDaysToPercentage(); }
            private set{}
        }

        public double Test
        {
            get { return test; }
            set
            {
                if (test != value)
                {
                    test = value;
                    OnPropertyChanged("Test");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
