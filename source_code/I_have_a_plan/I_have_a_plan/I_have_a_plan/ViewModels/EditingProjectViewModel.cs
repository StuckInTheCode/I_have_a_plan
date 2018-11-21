using System;
using System.Collections.Generic;
using System.Text;
using I_have_a_plan.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using I_have_a_plan.Views;
namespace I_have_a_plan.ViewModels
{
    public class EditingProjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ProjectViewModel pvm;
        public Project project { get; private set; }

        public EditingProjectViewModel()
        {
        }

        public ProjectViewModel ViewModel
        {
            get { return pvm; }
            set
            {
                if (pvm != value)
                {
                    pvm = value;
                    OnPropertyChanged("ViewModel");
                }
            }
        }

        public Project Project
        {
            get { return project; }
            set
            {
                if (project != value)
                {
                    project = value;
                    OnPropertyChanged("Project");
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    
}
}
