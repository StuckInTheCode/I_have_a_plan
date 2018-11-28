using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(I_have_a_plan.UWP.LocalToastNotification))]
namespace I_have_a_plan.UWP
{
    public class LocalToastNotification : ILocalToastNotification
    {
        public void CancelMessage(int id)
        {
            ScheduledToastNotification toast = ToastNotificationManager.CreateToastNotifier().GetScheduledToastNotifications().ToList<ScheduledToastNotification>().Find(x => x.Id == id.ToString());
            ToastNotificationManager.CreateToastNotifier().RemoveFromSchedule(toast);
        }

        public void ShowMessage(string name, string message, int id = 0)
        {
            ToastContent toastContent = new ToastContent
            {
                Launch = "app-defined-string",
                //basic toast template
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = name,
                                HintMaxLines = 1
                            },

                            new AdaptiveText()
                            {
                                Text = message
                            }
                        }
                    }
                },

            };
            XmlDocument doc = toastContent.GetXml();
            ToastNotification toast = new ToastNotification(doc);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void ShowScheduledMessage(string name, string message, int id, bool silent, DateTime time)
        {
            //Dont set the past time notification
            if (time < DateTime.Now)
                return;
            //Toast template
            ToastContent toastContent = new ToastContent
            {
                Launch = "app-defined-string",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = name,
                                HintMaxLines = 1
                            },

                            new AdaptiveText()
                            {
                                Text = message
                            },

                            //new AdaptiveText()
                            //{
                            //    Text = "10:00 AM - 10:30 AM"
                            //}
                        }
                    }
                },

                Actions = new ToastActionsCustom()
                {
                },

                Audio = new ToastAudio()
                {
                    Src = new Uri("ms-appx:///Assets/NewMessage.mp3"),
                    Silent = silent
                }

            };
            XmlDocument doc = toastContent.GetXml();
            ScheduledToastNotification toast = new ScheduledToastNotification(doc, time)
            {
                Id = id.ToString()
            };
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
        }
    }
}
