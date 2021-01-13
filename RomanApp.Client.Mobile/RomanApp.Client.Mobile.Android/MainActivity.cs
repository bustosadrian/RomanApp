
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using RomanApp.Client.Mobile.Droid.Service;
using RomanApp.Client.Mobile.Services;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Droid
{
    [Activity(
        Label = "RomanApp", 
        Theme = "@style/MainTheme", 
        MainLauncher = false, 
        NoHistory = true,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            Instance = this;

            DependencyService.Register<ISoundService, SoundService>();
            DependencyService.Register<IAppService, AppService>();

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