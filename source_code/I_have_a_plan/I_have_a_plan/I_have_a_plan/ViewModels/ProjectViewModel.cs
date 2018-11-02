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
        MainAppViewModel lvm;

        public Project Project { get; private set; }

        public ProjectViewModel()
        {
            Project = new Project();
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

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(Deadline.Trim())) ||
                    (!string.IsNullOrEmpty(Beginning.Trim())));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    
    }
}
