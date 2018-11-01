using System;
using System.Collections.Generic;
using System.Text;

namespace I_have_a_plan.Models
{
    public class ProjectManager
    {
        private List<Project> projectList;
        private Int32 projectCount;
        public ProjectManager()
        {
            projectList = new List<Project>();
        }

        public void addProject(Project newProject)
        {
            projectList.Add(newProject);

        }
        public void editProject(Project curProject)
        {

        }
        public void deleteProject(Project curProject)
        {
            projectList.Remove(curProject);
        }
        public bool checkProjectCount()
        {
            return true;
        }
        public bool checkProjectTaskCount()
        {
            return true;
        }
    }
}
