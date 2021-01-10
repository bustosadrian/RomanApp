
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using RomanApp.Client.Mobile.Droid.Platform;
using RomanApp.Client.Mobile.Platform;
using RomanApp.Client.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NavigablePage), typeof(NavigationPageRenderer))]
namespace RomanApp.Client.Mobile.Droid.Platform
{
    public class NavigationPageRenderer : PageRenderer
    {
        public NavigationPageRenderer(Context context)
            : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);
            var context = (Activity)Context;
            var toolbar = context.FindViewById<Android.Support.V7.Widget.Toolbar>(Droid.Resource.Id.toolbar);

            Toolbar.NavigationClick += Toolbar_NavigationClick;
        }

        private void Toolbar_NavigationClick(object sender, Android.Support.V7.Widget.Toolbar.NavigationClickEventArgs e)
        {
            Toolbar.NavigationClick -= Toolbar_NavigationClick;
            var ar  = (BindableObject)Element;
            var vm = (BusViewModel)ar.BindingContext;
            vm.GoBack();
        }

        #region Controls

        private Toolbar Toolbar
        {
            get
            {
                return ((Activity)Context).FindViewById<Toolbar>(Droid.Resource.Id.toolbar);
            }
        }

        #endregion
    }

}