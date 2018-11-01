using System;
using System.Collections.Generic;
using System.Text;

namespace I_have_a_plan.Models
{
    public class Project
    {
        public string name;
        public Int64 id;
        public List<Task> taskList;
        public Int32 taskCount;
        public string deadline;
        public string beginning;
        public Int32 percentageComplited;
        public string info;

        public Project()
        {
            taskList = new List<Task>();
        }

        public void addTask(Task newTask)
        {
            taskList.Add(newTask);

        }
        public void editTask(Task newTask)
        {

        }
        public void deleteTask(Task curTask)
        {
            taskList.Remove(curTask);
        }
        public bool checkTaskCount()
        {
            return true;
        }
    }
}
