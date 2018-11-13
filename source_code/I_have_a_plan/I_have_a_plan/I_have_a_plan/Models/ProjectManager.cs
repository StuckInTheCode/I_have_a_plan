using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace I_have_a_plan.Models
{
    public class ProjectManager: IAsyncInitialization
    {
        public  List<Project> projectList { get; set; }
        private  Int32 projectCount;
        public ProjectManager()
        {
            JSONSerializer JSON = new JSONSerializer();
            projectCount = 0;
            projectList = JSON.LoadProjectsFromJson();
            projectCount = projectList.Count;
            //Initialization = InitializeAsync();

        }
        public System.Threading.Tasks.Task Initialization { get; private set; }

        private async System.Threading.Tasks.Task InitializeAsync()
        {
            // Asynchronously initialize this instance.
            JSONSerializer JSON = new JSONSerializer();
            List<Project> list = await JSON.LoadProjectsFromJsonAsync();
            projectList = list;
            projectCount = projectList.Count;
        }

        public async System.Threading.Tasks.Task AddProjectAsync(Project newProject)
        {
            projectList.Add(newProject);
            JSONSerializer JSON = new JSONSerializer();
            await JSON.SaveProjectsToJsonAsync(projectList);

        }

        public async System.Threading.Tasks.Task EditProjectAsync(Project curProject)
        {
            Project editProject = projectList.Find(x => x.id == curProject.id);
            editProject.name = curProject.name;
            editProject.beginning = curProject.beginning;
            editProject.deadline = curProject.deadline;
            JSONSerializer JSON = new JSONSerializer();
            await JSON.SaveProjectsToJsonAsync(projectList);

        }
        public async System.Threading.Tasks.Task DeleteProjectAsync(Project curProject)
        {
            projectList.Remove(curProject);
            JSONSerializer JSON = new JSONSerializer();
            await JSON.SaveProjectsToJsonAsync(projectList);
        }

        public async System.Threading.Tasks.Task AddTaskToTheProject(Task curTask, Project curProject)
        {
            Project editProject = projectList.Find(x => x.id == curProject.id);
            editProject.addTask(curTask);
            //taskList.Add(curProject, curTask);
            JSONSerializer JSON = new JSONSerializer();
            await JSON.SaveProjectsToJsonAsync(projectList);
        }

        /// <summary>
        /// Compares the value of the current number of projects 
        /// with the maximum possible
        /// </summary>
        /// <returns>
        /// true if count of projects is equal to maximum
        /// </returns>
        public bool CheckProjectCount()
        {
            if(projectCount==50)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compares the value of the current number of project tasks
        /// with the maximum possible
        /// </summary>
        /// <param name="curProject"> 
        /// Checked project 
        /// </param>
        /// <returns>
        /// true if count of the  task is equal to maximum
        /// </returns>
        public bool CheckProjectTaskCount(Project curProject)
        {
            return curProject.checkTaskCount();
        }
    }
}
