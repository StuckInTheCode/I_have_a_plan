using System;
using Plugin.LocalNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(I_have_a_plan.Droid.LocalToastNotification))]
namespace I_have_a_plan.Droid
{
    public class LocalToastNotification : ILocalToastNotification
    {
        public void CancelMessage(int id)
        {
            CrossLocalNotifications.Current.Cancel(id);
        }

        public void ShowMessage(string name, string message, int id = 0)
        {
            CrossLocalNotifications.Current.Show(name, message, id);
        }

        public void ShowScheduledMessage(string name, string message, int id, bool silent, DateTime time)
        {
            CrossLocalNotifications.Current.Show(name, message, id, time);
        }
    }
}