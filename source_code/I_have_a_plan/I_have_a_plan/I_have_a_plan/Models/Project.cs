using System;
using System.Collections.Generic;
using System.Text;

namespace I_have_a_plan.Models
{
    public class Project
    {
        public string name { get; set; }
        public Int64 id;
        public List<Task> taskList;
        public Int32 taskCount;
        public string deadline { get; set; }
        public string beginning { get; set; }
        public Int32 percentageComplited;
        public string info;

        public Project()
        {
            taskList = new List<Task>();
            //Task task1 = new Task();
            //task1.id = 123;
            //task1.name = "123";
            
            //addTask(task1);
        }

        public void addTask(Task newTask)
        {
            taskList.Add(newTask);

        }
        public void editTask(Task newTask)
        {
            Task curTask = taskList.Find(x => x.id == newTask.id);
            curTask.name = newTask.name;
            curTask.daysFinished = newTask.daysFinished;
            curTask.daysAll = newTask.daysAll;

        }
        public void deleteTask(Task curTask)
        {
            taskList.Remove(curTask);
        }
        /// <summary>
        /// check is taskCount less than MAXCOUNT
        /// </summary>
        /// <returns>
        /// true  - condition is met
        /// false - taskCount is equal to MAXCOUNT
        /// </returns>
        public bool checkTaskCount()
        {
            if(taskCount < 50)
            return true;
            else
                return false;
        }
    }
}
