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
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TaskViewModel> Tasks { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand EditCommand { protected set; get; }
        public ICommand SaveCommand { protected set; get; }
        MainAppViewModel lvm;

        public Project Project { get; private set; }

        public ProjectViewModel()
        {
            Project = new Project();
            Tasks = new ObservableCollection<TaskViewModel>();
            //test task
            TaskViewModel task = new TaskViewModel();
            Tasks.Add(task);
            EditCommand = new Command(EditProject);
            SaveCommand = new Command(SaveChanges);
        }

        public ProjectViewModel(Project project)
        {
            Project = project;
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

        private void EditProject()
        {
            Navigation.PushAsync(new EditingProjectPage(new EditingProjectViewModel() { ViewModel = this , Project = new Project( this.Project)}));

        }
        private void SaveChanges (object projectObject)
        {
            EditingProjectViewModel viewModel = projectObject as EditingProjectViewModel;
            Name = viewModel.Name;
            Beginning = viewModel.Beginning;
            Deadline = viewModel.Deadline;
            MessagingCenter.Send<ProjectViewModel>(this, "Project cant have empty fields");
            Navigation.PopAsync();

        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    
    }
}
