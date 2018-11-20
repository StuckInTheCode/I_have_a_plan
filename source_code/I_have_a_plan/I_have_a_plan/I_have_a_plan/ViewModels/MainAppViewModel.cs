using I_have_a_plan.Models;
using I_have_a_plan.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace I_have_a_plan.ViewModels
{
    public class MainAppViewModel : INotifyPropertyChanged
    {
        public ProjectManager projectManager;
        public ObservableCollection<ProjectViewModel> Projects { get; set; }
        public ObservableCollection<TaskViewModel> Tasks { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public ICommand AddCommand { protected set; get; }
        public ICommand SaveCommand { protected set; get; }
        public ICommand DeleteCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        public ICommand OptionsCommand { protected set; get; }

        ProjectViewModel selectedProject;

        public ProjectViewModel SelectedProject
        {
            get { return selectedProject; }
            set
            {
                if (selectedProject != value)
                {
                    selectedProject = value;
                    //set ManagedViewModel to this
                    selectedProject.ListViewModel = this;
                    OnPropertyChanged("SelectedProject");
                }
            }
        }

        public MainAppViewModel(ProjectManager manager)
        {
            projectManager = manager;

            InitializeProjectViewCollection();
            Projects.CollectionChanged += Projects_CollectionChanged;
            AddCommand = new Command(AddProject);
            SaveCommand = new Command(SaveProject);
            BackCommand = new Command(Back);
            DeleteCommand = new Command(DeleteProject);
            OptionsCommand = new Command(ToTheOptions);
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if taskList was edit, then update it
            if (e.PropertyName == "TaskList")
            {
                ProjectViewModel collection = sender as ProjectViewModel;
                //add new tasks
                foreach (TaskViewModel t in collection.Tasks)
                {
                    if (!Tasks.Contains(t))
                    {
                        Tasks.Add(t);
                    }
                }
                //remove deleted tasks
                for (int i = 0; i < Tasks.Count; i++)
                {
                    ProjectViewModel curProject = Tasks[i].ViewModel;
                    if (curProject.Equals(collection))
                        if (!collection.Tasks.Contains(Tasks[i]))
                        {
                            Tasks.RemoveAt(i);
                        }
                }
            }
        }

        private void Projects_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            if (e.NewItems != null)
            {
                foreach (ProjectViewModel newItem in e.NewItems)
                {
                    foreach (TaskViewModel newTask in newItem.Tasks)
                    {
                        Tasks.Add(newTask);
                    }
                    //Add listener for each item on PropertyChanged event
                    newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (ProjectViewModel removingItem in e.OldItems)
                {
                    //Remove listener 
                    removingItem.PropertyChanged -= this.OnItemPropertyChanged;
                    foreach (TaskViewModel item in removingItem.Tasks)
                    {
                        //remove projects task from the main task list
                        Tasks.Remove(item);
                    }
                }
            }
        }

        private void InitializeTaskViewCollection()
        {
            Tasks = new ObservableCollection<TaskViewModel>();
            foreach (Project project in projectManager.projectList)
            {
                foreach (Task task in project.taskList)
                {
                    TaskViewModel taskViewModel = new TaskViewModel(task);
                    Tasks.Add(taskViewModel);
                }
            }
        }

        public void InitializeProjectViewCollection()
        {
            Projects = new ObservableCollection<ProjectViewModel>();
            Tasks = new ObservableCollection<TaskViewModel>();
            if (projectManager.projectList != null)
                foreach (Project element in projectManager.projectList)
                {
                    ProjectViewModel projectElement = new ProjectViewModel(element);
                    projectElement.PropertyChanged += this.OnItemPropertyChanged;
                    Projects.Add(projectElement);
                    foreach (TaskViewModel task in projectElement.Tasks)
                    {
                        //add tasks from current project to the collection
                        Tasks.Add(task);
                    }
                }
        }

        private void AddProject()
        {
            if (Projects.Count == 50)
                MessagingCenter.Send<MainAppViewModel, string>(this, "saveProjectMessage", "Project count is maximum");
            else
                // set the navigation of the current page as the root of the new page
                Navigation.PushAsync(new AddingProjectPage(new ProjectViewModel() { ListViewModel = this, Navigation = this.Navigation }));

        }

        private async void DeleteProject(object projectObject)
        {
            Services.IMessageService MessageService = DependencyService.Get<Services.IMessageService>();
            if (await MessageService.ShowDialog("Are you sure?"))
            {
                await Navigation.PopAsync();
                ProjectViewModel project = projectObject as ProjectViewModel;
                await projectManager.DeleteProjectAsync(project.Project);
                Projects.Remove(project);
            }
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private async void SaveProject(object projectObject)
        {

            ProjectViewModel project = projectObject as ProjectViewModel;

            if (project != null && project.IsValid)
            {
                project.Trim();
                await projectManager.AddProjectAsync(project.Project);
                Projects.Add(project);
                Back();
            }
            else
            {
                //show nessage about problem
                Services.IMessageService MessageService = DependencyService.Get<Services.IMessageService>();
                await MessageService.ShowAsync("Please fill empty fields");
            }

        }

        private void ToTheProject(object sender)
        {
            Navigation.PushAsync((new ProjectPage(selectedProject)));
        }

        private void ToTheOptions(object sender)
        {
            Navigation.PushAsync((new OptionsPage(new OptionsViewModel())));
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
