using System;
using System.Collections.Generic;
using System.Text;

namespace I_have_a_plan.Models
{
    public class Task
    {
        public string Name { get; set; }
        public Int64 Id { get; set; }
        public string Info { get; set; }
        public Int32 DaysFinished { get; set; }
        public Int32 DaysAll { get; set; }
        public double percentageComplited;

        public Int32 ConvertDaysToPercentage()
        {
            percentageComplited = (double) DaysFinished / DaysAll;
            return (int)percentageComplited*100;
        }
    }
}
