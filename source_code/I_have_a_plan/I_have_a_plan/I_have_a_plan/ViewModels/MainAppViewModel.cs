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
        //private readonly IDialogService dialogService;
        //try to realize the dialog showing inteface to the viewModel classes

        public ObservableCollection<ProjectViewModel> Projects { get ; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public ICommand AddCommand { protected set; get; }
        public ICommand SaveCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        String name2 { get; set;}
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
        public MainAppViewModel()
        {
            Projects = new ObservableCollection<ProjectViewModel>();
            selectedProject = new ProjectViewModel();
            ProjectViewModel project = new ProjectViewModel() ;
            Projects.Add(project);
            AddCommand = new Command(AddProject);
            SaveCommand = new Command(SaveProject);
            BackCommand = new Command(Back);
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
        private void SaveProject(object projectObject)
        {

            ProjectViewModel project = projectObject as ProjectViewModel;
            
            if (project != null && project.IsValid)
            {
                project.Trim();
                Projects.Add(project);
                Back();
            }
            else
            {
                //send messagee to the subscribers
                MessagingCenter.Send<MainAppViewModel>(this, "Not all field filled");

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
