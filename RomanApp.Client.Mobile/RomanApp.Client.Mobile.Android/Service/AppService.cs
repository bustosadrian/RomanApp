using Android.App;
using RomanApp.Client.Mobile.Services;

namespace RomanApp.Client.Mobile.Droid.Service
{
    public class AppService : IAppService
    {
        public void Quit()
        {
            var activity = MainActivity.Instance;
            activity.Finish();
        }
    }
}