using System;
using System.Collections.Generic;
using System.Text;
using Plugin.LocalNotifications;

namespace I_have_a_plan.Models
{
    class NotificationScheduler
    {
        //private string schedule;

        private readonly Dictionary<Int32, DateTime> notifications;

        public NotificationScheduler()
        {
            notifications = LoadSchedule();
        }

        void SetAlarm(string message, int id, DateTime time)
        {
            CrossLocalNotifications.Current.Show("I have a plan!", message, id,time);
        }

        void RemoveAlarms()
        {
            foreach(KeyValuePair<Int32,DateTime> element in notifications)
            {
                CrossLocalNotifications.Current.Cancel(element.Key);
            }

        }

        Dictionary<Int32, DateTime> LoadSchedule()
        {
            JSONSerializer serializer = new JSONSerializer();
            return serializer.LoadScheduleFromJson();

        }

        public void SetSchedule()
        {
            RemoveAlarms();

            var properties = new Options();
            var period = properties.notificationPeriod;
            var day = DateTime.Today;
            var endOfDay = day + properties.notificationEndTime;
            day += properties.notificationStartTime;

            while(day < endOfDay)
            {
                notifications.Add(notifications.Count, day);
                day += new TimeSpan(period, 0, 0);
            }
        }

        public void SetAllAlarm()
        {
            foreach (KeyValuePair<Int32, DateTime> element in notifications)
            {

                SetAlarm("You have some task to do today. Click to show more...", element.Key, element.Value);
            }
        }

        public bool IsScheduleExist()
        {
            if (notifications.Count != 0)
                return true;
            else
                return false;
        }

    }
}
