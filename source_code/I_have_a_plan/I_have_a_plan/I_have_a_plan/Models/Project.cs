﻿using System;
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
            Task task1 = new Task();
            task1.id = 123;
            task1.name = "123";
            DateTime currentDate = DateTime.Now;

            int day, month, year;
            // calculate the duration of the project
            Int32.TryParse(beginning.Substring(0, 2), out day);
            Int32.TryParse(beginning.Substring(3, 2), out month);
            Int32.TryParse(beginning.Substring(6, 4), out year);
            DateTime beginningDate = new DateTime(year, month, day);
            Int32.TryParse(deadline.Substring(0, 2), out day);
            Int32.TryParse(deadline.Substring(3, 2), out month);
            Int32.TryParse(deadline.Substring(6, 4), out year);
            DateTime deadlineDate = new DateTime(year, month, day);
            //convert days until project finish to the persentage
            percentageComplited = (currentDate.Subtract(beginningDate).TotalDays / deadlineDate.Subtract(beginningDate).TotalDays);
            addTask(task1);
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

        public void addTask(Task newTask)
        {
            taskList.Add(newTask);
            taskCount++;

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
            taskCount--;
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
