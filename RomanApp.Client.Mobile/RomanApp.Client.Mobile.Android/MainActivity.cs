
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using RomanApp.Client.Mobile.Droid.Service;
using RomanApp.Client.Mobile.Services;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Droid
{
    [Activity(Label = "RomanApp", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Instance = this;

            DependencyService.Register<ISoundService, SoundService>();

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #region Properties

        public static MainActivity Instance 
        { 
            get; 
            private set; 
        }

        #endregion
    }
}