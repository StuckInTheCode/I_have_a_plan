using System;
using System.Collections.Generic;
using System.Text;

namespace I_have_a_plan.Models
{
    public enum NotificationType
    {
        Sound,
        SoundVibration,
        Vibration,
        NoSound
    }

    public class Options
    {
        public Int32 notificationPeriod;
        public NotificationType notificationType;
        public TimeSpan notificationStartTime;
        public TimeSpan notificationEndTime;

        public Options()
        {
            LoadOptions();
        }

        public async void SaveOptions()
        {
            JSONSerializer jSON = new JSONSerializer();
            if (App.Current.Properties.Count != 0)
            {
                App.Current.Properties["notificationPeriod"] = notificationPeriod;
                App.Current.Properties["notificationType"] = Newtonsoft.Json.JsonConvert.SerializeObject(notificationType);
                App.Current.Properties["notificationStartTime"] = Newtonsoft.Json.JsonConvert.SerializeObject(notificationStartTime);
                App.Current.Properties["notificationEndTime"] = Newtonsoft.Json.JsonConvert.SerializeObject(notificationEndTime);
            }
            else
            {
                App.Current.Properties.Add("notificationPeriod", notificationPeriod);
                App.Current.Properties.Add("notificationType", Newtonsoft.Json.JsonConvert.SerializeObject(notificationType));
                App.Current.Properties.Add("notificationStartTime", Newtonsoft.Json.JsonConvert.SerializeObject(notificationStartTime));
                App.Current.Properties.Add("notificationEndTime", Newtonsoft.Json.JsonConvert.SerializeObject(notificationEndTime));
            }
            await App.Current.SavePropertiesAsync();
        }

        public void LoadOptions()
        {
            if (App.Current.Properties.TryGetValue("notificationPeriod", out object obj))
            {
                notificationPeriod = (int)obj;
            }
            else
            {
                notificationPeriod = 0;
            }
            if (App.Current.Properties.TryGetValue("notificationType", out obj))
            {
                notificationType = Newtonsoft.Json.JsonConvert.DeserializeObject<NotificationType>(obj.ToString());
            }
            else
            {
                notificationType = NotificationType.Sound;
            }
            if (App.Current.Properties.TryGetValue("notificationStartTime", out obj))
            {
                notificationStartTime = Newtonsoft.Json.JsonConvert.DeserializeObject<TimeSpan>(obj.ToString());
            }
            else
            {
                notificationStartTime = new TimeSpan();
            }
            if (App.Current.Properties.TryGetValue("notificationEndTime", out obj))
            {
                notificationEndTime = Newtonsoft.Json.JsonConvert.DeserializeObject<TimeSpan>(obj.ToString());
            }
            else
            {
                notificationEndTime = new TimeSpan();
            }
        }

        public void SetNotificationType(string Time)
        {
            switch (Time)
            {
                case "Sound":
                    notificationType = NotificationType.Sound;
                    break;
                case "Sound and vibration":
                    notificationType = NotificationType.SoundVibration;
                    break;
                case "Vibration":
                    notificationType = NotificationType.Vibration;
                    break;
                case "No sound":
                    notificationType = NotificationType.NoSound;
                    break;
            }
        }

        public string GetNotificationType()
        {
            string type = "";

            switch (notificationType)
            {
                case NotificationType.Sound:
                    type = "Sound";
                    break;
                case NotificationType.SoundVibration:
                    type = "Sound and vibration";
                    break;
                case NotificationType.Vibration:
                    type = "Vibration";
                    break;
                case NotificationType.NoSound:
                    type = "No sound";
                    break;
                default:
                    type = "Vibration";
                    break;

            }
            return type;
        }
    }
}
