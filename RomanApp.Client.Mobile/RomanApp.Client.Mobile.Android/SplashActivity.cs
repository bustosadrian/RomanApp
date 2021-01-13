
using Android.App;
using Android.Content;
using Android.OS;
using System.Threading.Tasks;

namespace RomanApp.Client.Mobile.Droid
{
    [Activity(
        Label = "RomanApp",
        Theme = "@style/Splash",
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SplashActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //Task startupWork = new Task(() => { SimulateStartup(); });
            //startupWork.Start();

        }

        public override void OnBackPressed()
        {

        }

        protected override void OnResume()
        {
            base.OnResume();
            RunOnUiThread(() =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            });
        }
    }
}