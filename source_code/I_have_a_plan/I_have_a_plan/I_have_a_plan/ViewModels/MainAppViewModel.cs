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
        public ObservableCollection<Project> Projects { get ; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public ICommand add { protected set; get; }
        public ICommand Go { protected set; get; }
        string Name2 { get; set; }
        Project selectedProject;
        public MainAppViewModel()
        {
            Projects = new ObservableCollection<Project>();
            Name2 = "123";
            Project project = new Project() ;// = projectObject as String;
            //if (friend != null && friend.IsValid)
            //{
            Projects.Add(project);
            OnPropertyChanged("Projects");
            //}
            //Back();
            Go = new Command(toTheProject);
            add = new Command(addProject);
        }

        private void addProject()
        {
            Project project = new Project();
            Projects.Add(project);
            OnPropertyChanged("Projects");
            
            //OnPropertyChanged("Name2");
            //throw new NotImplementedException();
        }
        private void toTheProject(object obj)
        {
            Navigation.PushAsync(new ProjectPage());
            //throw new NotImplementedException();
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
