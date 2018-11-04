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
        public ObservableCollection<ProjectViewModel> Projects { get ; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public ICommand AddCommand { protected set; get; }
        public ICommand SaveCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        //public ICommand ProjectCommand { protected set; get; }
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
            ProjectViewModel project = new ProjectViewModel() ;// = projectObject as String;
            Projects.Add(project);
            AddCommand = new Command(AddProject);
            SaveCommand = new Command(SaveProject);
            BackCommand = new Command(Back);
            //ProjectCommand = new Command(toTheProject);
        }

        private void AddProject()
        {
            Navigation.PushAsync(new AddingProjectPage(new ProjectViewModel() { ListViewModel = this }));
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
            //else
            //{
            //
            //}
            
        }
        //private void toTheProject(object obj)
        //{
        //    Navigation.PushAsync(new ProjectPage(obj as ProjectViewModel));
        //}

        private void toTheProject(object sender)
        {
            Navigation.PushAsync(new ProjectPage(selectedProject));
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
