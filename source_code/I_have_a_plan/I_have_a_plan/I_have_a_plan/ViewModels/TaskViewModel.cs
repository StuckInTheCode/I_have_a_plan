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
        ProjectViewModel lvm;
        static double test;
        public Task Task { get; private set; }

        public TaskViewModel()
        {
            Task = new Task();
            Task.Name ="task";
            //Task.daysAll = lvm.getProjectDuration();
            test = 0;
        }

        public TaskViewModel(Task task)
        {
            Task = task;
        }
        public TaskViewModel(TaskViewModel taskViewModel)
        {
            Task = taskViewModel.Task;
            ViewModel = taskViewModel.ViewModel;
        }

        public ProjectViewModel ViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ViewModel");
                }
            }
        }

        public string Name
        {
            get { return Task.Name; }
            set
            {
                if (Task.Name != value)
                {
                    Task.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public Int32 PercentageFinished
        {
            get { return (int)(Task.percentageComplited*100); }
            set{
                if((int)(100*Task.percentageComplited )!= value )
                {
                    Task.percentageComplited = ((double)value)/100;
                    //Task.daysFinished = (int)(((double)(value / 100)) * Task.daysAll); 
                }

            }
        }

        public double Percentage
        {
            get { return Task.percentageComplited; }
            private set { }
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

        public string Info
        {
            get { return Task.Info; }
            set
            {
                if (Task.Info != value)
                {
                    Task.Info = value;
                    OnPropertyChanged("Info");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim()))|| (!string.IsNullOrEmpty(Info.Trim())));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
