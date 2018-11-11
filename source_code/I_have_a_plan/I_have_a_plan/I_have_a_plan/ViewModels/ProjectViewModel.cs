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
        public ICommand AddCommand { protected set; get; }
        public ICommand SaveTaskCommand { protected set; get; }
        private Services.IMessageService MessageService;
        MainAppViewModel lvm;

        public Project Project { get; private set; }

        public ProjectViewModel()
        {
            MessageService = DependencyService.Get<Services.IMessageService>();
            Project = new Project();
            Tasks = new ObservableCollection<TaskViewModel>();
            //test task
            TaskViewModel task = new TaskViewModel();
            Tasks.Add(task);
            EditCommand = new Command(EditProject);
            SaveCommand = new Command(SaveChanges);
            AddCommand = new Command(AddTask);
            SaveTaskCommand = new Command(SaveTask);
        }

        public ProjectViewModel(Project project)
        {
            MessageService = DependencyService.Get<Services.IMessageService>();
            Project = project;
            Tasks = new ObservableCollection<TaskViewModel>();
            TaskViewModel task = new TaskViewModel();
            Tasks.Add(task);
            EditCommand = new Command(EditProject);
            SaveCommand = new Command(SaveChanges);
            AddCommand = new Command(AddTask);
            SaveTaskCommand = new Command(SaveTask);
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
        private double PercentageComplited
        {
            get { return Project.percentageComplited; }
            set
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
                if (Project.deadline != value && IsDateValid())
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
                if (Project.beginning != value && IsDateValid())
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

        public void EditProject()
        {
            Navigation.PushAsync(new EditingProjectPage(new EditingProjectViewModel() { ViewModel = this , Project = new Project( this.Project)}));
            //Navigation.PushAsync(new EditingProjectPage(new ProjectViewModel() { ListViewModel = this, Project = new Project(this.Project) }));
        }

        private void AddTask()
        {
            Navigation.PushAsync(new AddingTaskPage(new TaskViewModel() { ViewModel = this }));
        }

        public void SaveChanges(object projectObject)
        {
            EditingProjectViewModel viewModel = projectObject as EditingProjectViewModel;
            if (viewModel.IsValid)
            {
                Name = viewModel.Name;
                Beginning = viewModel.Beginning;
                Deadline = viewModel.Deadline;
                Navigation.PopAsync();
            }
            else
            MessageService.ShowAsync("Please fill the empty fields");
        }

        public void SaveTask(object taskObject)
        {
            TaskViewModel viewModel = taskObject as TaskViewModel;
            //if (viewModel.IsValid)
            //{
            Task task = new Task();
            task.name = viewModel.Name;
            Project.addTask(task);
            Tasks.Add(viewModel);
            Navigation.PopAsync();
            //}
            //else
            //    MessageService.ShowAsync("Please fill the empty fields");
        }

        private bool IsDateValid()
        {
            DateTime currentDate = DateTime.Now;

            int day, month, year;
            double percentage;
            // calculate the duration of the project
            Int32.TryParse(Project.beginning.Substring(0, 2), out day);
            Int32.TryParse(Project.beginning.Substring(3, 2), out month);
            Int32.TryParse(Project.beginning.Substring(6, 4), out year);
            DateTime beginningDate = new DateTime(year, month, day);
            Int32.TryParse(Project.deadline.Substring(0, 2), out day);
            Int32.TryParse(Project.deadline.Substring(3, 2), out month);
            Int32.TryParse(Project.deadline.Substring(6, 4), out year);
            DateTime deadlineDate = new DateTime(year, month, day);
            //convert days until project finish to the persentage
            try
            {
                percentage = (currentDate.Subtract(beginningDate).TotalDays / deadlineDate.Subtract(beginningDate).TotalDays);
                PercentageComplited = percentage;
                return true;
            }
            catch(ArgumentOutOfRangeException e)
            {
                MessageService.ShowAsync("Deadline cant be earlier than beginning");
                return false;
            }
        }


        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    
    }
}
