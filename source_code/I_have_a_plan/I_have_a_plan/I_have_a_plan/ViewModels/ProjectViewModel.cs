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
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TaskViewModel> Tasks { get; set; }
        MainAppViewModel lvm;

        public Project Project { get; private set; }

        public ProjectViewModel()
        {
            Project = new Project();
            Tasks = new ObservableCollection<TaskViewModel>();
            TaskViewModel task = new TaskViewModel();
            Tasks.Add(task);
        }

        public MainAppViewModel ListViewModel
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
            get { return Project.name; }
            set
            {
                if (Project.name != value)
                {
                    Project.name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public double PercentageComplited
        {
            get { return Project.percentageComplited; }
            protected set
            {
                if (Project.percentageComplited != value)
                {
                    Project.percentageComplited = value;
                    OnPropertyChanged("PercentageComplited");
                }
            }
        }

        public string Deadline
        {
            get { return Project.deadline; }
            set
            {
                if (Project.deadline != value)
                {
                    Project.deadline = value;
                    OnPropertyChanged("Deadline");
                }
            }
        }
        public string Beginning
        {
            get { return Project.beginning; }
            set
            {
                if (Project.beginning != value)
                {
                    Project.beginning = value;
                    OnPropertyChanged("Beginning");
                }
            }
        }

        public string Info
        {
            get { return Project.info; }
            set
            {
                if (Project.info != value)
                {
                    Project.info = value;
                    OnPropertyChanged("Info");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name)) ||
                    (!string.IsNullOrEmpty(Deadline)) ||
                    (!string.IsNullOrEmpty(Beginning)));
            }
        }

        internal void Trim()
        {
            Name.Trim();
            Deadline.Trim();
            Beginning.Trim();
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    
    }
}
