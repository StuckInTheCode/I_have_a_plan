using System;
using System.Collections.Generic;
using System.Text;

namespace I_have_a_plan.Models
{
    public class Task
    {
        public string name { get; set; }
        public Int64 id { get; set; }
        public Int32 daysFinished { get; set; }
        public Int32 daysAll { get; set; }
        public Int32 convertDaysToPercentage()
        {
            return 1;
        }
    }
}
