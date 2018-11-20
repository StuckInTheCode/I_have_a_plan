using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace I_have_a_plan.Droid
{
    [Activity(Label = "I_have_a_plan", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            var not = Application.ApplicationContext.GetSystemService(Context.NotificationService) as NotificationManager;
            
            var alarmManager = Application.Context.GetSystemService(Context.AlarmService) as AlarmManager;
        }
    }
}