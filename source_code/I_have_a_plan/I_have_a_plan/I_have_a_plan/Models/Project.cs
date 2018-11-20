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
        public double percentageComplited;
        public string info;

        public Project()
        {
            //test project 
            Random rand = new Random();
            id = rand.Next();
            name = "Project";
            deadline = "01.12.2018";
            beginning = "01.09.2018";
            info = "Just test";
            taskList = new List<Task>();
            percentageComplited = 0;
        }

        //create a copy of the project
        public Project(Project copy)
        {
            name = copy.name;
            id = copy.id;
            taskList = copy.taskList;

            taskCount = copy.taskCount;
            deadline = copy.deadline;
            beginning = copy.beginning;

            percentageComplited = copy.percentageComplited;
            info = copy.info;
    }

        public void AddTask(Task newTask)
        {
            taskList.Add(newTask);
            taskCount++;

        }
        public void EditTask(Task newTask)
        {
            Task curTask = taskList.Find(x => x.Id == newTask.Id);
            curTask.Name = newTask.Name;
            curTask.DaysFinished = newTask.DaysFinished;
            curTask.DaysAll = newTask.DaysAll;
        }

        public void DeleteTask(Task curTask)
        {
            taskList.Remove(curTask);
            taskCount--;
        }

        /// <summary>
        /// check is taskCount less than MAXCOUNT
        /// </summary>
        /// <returns>
        /// true  - condition is met
        /// false - taskCount is equal to MAXCOUNT
        /// </returns>
        public bool CheckTaskCount()
        {
            if(taskCount < 50)
            return true;
            else
                return false;
        }
    }
}
