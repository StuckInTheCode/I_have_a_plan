using System;

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
            Xamarin.Forms.Application current = Xamarin.Forms.Application.Current;
            if (current.Properties.Count == 0)
            {
                current.Properties.Add("notificationPeriod", notificationPeriod);
                current.Properties.Add("notificationType", Newtonsoft.Json.JsonConvert.SerializeObject(notificationType));
                current.Properties.Add("notificationStartTime", Newtonsoft.Json.JsonConvert.SerializeObject(notificationStartTime));
                current.Properties.Add("notificationEndTime", Newtonsoft.Json.JsonConvert.SerializeObject(notificationEndTime));
            }
            else
                AddOptions(current);
            await current.SavePropertiesAsync();
        }

        private void AddOptions(Xamarin.Forms.Application current)
        {
            current.Properties["notificationPeriod"] = notificationPeriod;
            //save objects as serialized instance
            current.Properties["notificationType"] = Newtonsoft.Json.JsonConvert.SerializeObject(notificationType);
            current.Properties["notificationStartTime"] = Newtonsoft.Json.JsonConvert.SerializeObject(notificationStartTime);
            current.Properties["notificationEndTime"] = Newtonsoft.Json.JsonConvert.SerializeObject(notificationEndTime);
        }

        public void LoadOptions()
        {
            if (Xamarin.Forms.Application.Current.Properties.TryGetValue("notificationPeriod", out object obj))
            {
                notificationPeriod = (int)obj;
            }
            else
            {
                notificationPeriod = 3;
            }
            if (Xamarin.Forms.Application.Current.Properties.TryGetValue("notificationType", out obj))
            {
                notificationType = Newtonsoft.Json.JsonConvert.DeserializeObject<NotificationType>(obj.ToString());
            }
            else
            {
                notificationType = NotificationType.Sound;
            }
            if (Xamarin.Forms.Application.Current.Properties.TryGetValue("notificationStartTime", out obj))
            {
                notificationStartTime = Newtonsoft.Json.JsonConvert.DeserializeObject<TimeSpan>(obj.ToString());
            }
            else
            {
                notificationStartTime = new TimeSpan();
            }
            if (Xamarin.Forms.Application.Current.Properties.TryGetValue("notificationEndTime", out obj))
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
