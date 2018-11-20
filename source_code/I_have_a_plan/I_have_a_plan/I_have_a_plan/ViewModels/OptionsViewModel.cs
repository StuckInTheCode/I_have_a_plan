using I_have_a_plan.Models;
using System;
using System.Collections.Generic;

namespace I_have_a_plan.ViewModels
{
    public class OptionsViewModel
    {
        private Options Options;

        public OptionsViewModel()
        {
            Options = new Options();
            TypeList = new List<string>();
            PeriodList = new List<string>();
            TypeList.AddRange(new string[] { "Sound", "Sound and vibration", "Vibration", "No sound" });
            PeriodList.AddRange(new string[] { "1 hour", "2 hours", "3 hours",
                "4 hours", "5 hours", "6 hours", "7 hours", "8 hours", "9 hours",
                "10 hours", "11 hours", "12 hours", "13 hours", "14 hours", "15 hours",
                "16 hours", "17 hours", "18 hours", "19 hours", "20 hours", "21 hours",
                "22 hours", "23 hours", "24 hours" });
        }

        public OptionsViewModel(Options options)
        {
            Options = options;
        }

        public List<string> TypeList { get; }

        public List<string> PeriodList { get; }

        public TimeSpan StartTime
        {
            get
            {
               return  Options.notificationStartTime;
            }
            set
            {
                if(Options.notificationStartTime != value)
                {
                    Options.notificationStartTime = value;
                    Options.SaveOptions();
                }
            }
        }
        public TimeSpan EndTime
        {
            get
            {
                return Options.notificationEndTime;
            }
            set
            {
                if (Options.notificationEndTime != value)
                {
                    Options.notificationEndTime = value;
                    Options.SaveOptions();
                }
            }
        }

        public string Type
        {
            get
            {
                return Options.GetNotificationType();
            }
            set
            {
                if (Options.GetNotificationType() != value && value != null)
                {
                    Options.SetNotificationType(value);
                    Options.SaveOptions();
                }
            }
        }

        public string Period
        {
            get
            {
                return PeriodList[Options.notificationPeriod--];
            }
            set
            {
                var result = PeriodList.FindIndex(x=> x==value);
                if (Options.notificationPeriod != result)
                {
                    Options.notificationPeriod = result;
                    Options.SaveOptions();
                }
            }
        }
    }
}
