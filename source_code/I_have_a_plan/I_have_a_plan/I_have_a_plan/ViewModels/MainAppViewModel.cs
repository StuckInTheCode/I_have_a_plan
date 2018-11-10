using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using I_have_a_plan.Views;
using I_have_a_plan.Models;

namespace I_have_a_plan.ViewModels
{
    public class MainAppViewModel : INotifyPropertyChanged
    {
        private ProjectManager projectManager;
        public ObservableCollection<ProjectViewModel> Projects { get ; set; }
        public ObservableCollection<TaskViewModel> Tasks { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public ICommand AddCommand { protected set; get; }
        public ICommand SaveCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        ProjectViewModel selectedProject;

        public ProjectViewModel SelectedProject
        {
            get { return selectedProject; }
            set
            {
                if (selectedProject != value)
                {
                    selectedProject = value;
                    OnPropertyChanged("SelectedProject");
                }
            }
        }

        public MainAppViewModel( ProjectManager manager)
        {
            projectManager = manager;
            Projects = new ObservableCollection<ProjectViewModel>();
            Tasks = new ObservableCollection<TaskViewModel>();
            selectedProject = new ProjectViewModel();
            InitializeProjectViewCollection();
            AddCommand = new Command(AddProject);
            SaveCommand = new Command(SaveProject);
            BackCommand = new Command(Back);
        }

        private void InitializeTaskViewCollection(Project project)
        {
            foreach (Task element in project.taskList)
            {
                TaskViewModel task = new TaskViewModel(element);
                Tasks.Add(task);
            }

        }

        public void InitializeProjectViewCollection()
        {
            if(projectManager.projectList != null)
                foreach (Project element in projectManager.projectList)
                {
                    ProjectViewModel projectElement = new ProjectViewModel(element);
                    Projects.Add(projectElement);
                    InitializeTaskViewCollection(element);
                }
        }

        private void AddProject()
        {
            if(Projects.Count == 50)
                MessagingCenter.Send<MainAppViewModel, string>(this, "saveProjectMessage", "Project count is maximum");
            else
                Navigation.PushAsync(new AddingProjectPage(new ProjectViewModel() { ListViewModel = this , Navigation = this.Navigation }));
            // set the navigation of the current page as the root of the new page
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
            }
            
        }

        private void toTheProject(object sender)
        {
            Navigation.PushAsync(( new ProjectPage(selectedProject)));
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
