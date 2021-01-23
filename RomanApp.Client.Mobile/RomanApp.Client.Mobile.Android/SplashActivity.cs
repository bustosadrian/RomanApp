
using Android.App;
using Android.Content;
using Android.OS;

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

            if (!Bootstrap.Instance.IsLoaded)
            {
                Bootstrap.Instance.OnClientLoaded -= Bootstrap_OnClientLoaded;
                Bootstrap.Instance.OnClientLoaded += Bootstrap_OnClientLoaded;
                Bootstrap.Instance.Load();
            }
            else
            {
                MoveForward();
            }
        }

        private void Bootstrap_OnClientLoaded(object sender, ClientLoadedEventArgs e)
        {
            Bootstrap.Instance.OnClientLoaded -= Bootstrap_OnClientLoaded;
            MoveForward();
        }

        protected void MoveForward()
        {
            RunOnUiThread(() =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            });
        }
    }
}