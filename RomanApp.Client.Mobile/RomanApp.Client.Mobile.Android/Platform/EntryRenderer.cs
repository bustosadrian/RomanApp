using Android.Content;
using Android.Graphics;
using Android.Text.Method;
using Android.Widget;
using Java.Util;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(RomanApp.Client.Mobile.Droid.Platform.EntryRenderer))]
namespace RomanApp.Client.Mobile.Droid.Platform
{
    public class EntryRenderer : Xamarin.Forms.Platform.Android.EntryRenderer
    {
        public EntryRenderer(Context context)
            : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (this.Control.InputType.HasFlag(Android.Text.InputTypes.ClassNumber))
                {
                    this.Control.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagDecimal;
                    //this.Control.KeyListener = DigitsKeyListener.GetInstance(new Locale(CultureInfo.CurrentCulture.TwoLetterISOLanguageName), false, true);
                }

            }
        }

        //private EditText _native = null;

        //protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.NewElement == null)
        //        return;

        //    _native = Control as EditText;
        //    _native.InputType = Android.Text.InputTypes.ClassNumber;
        //    if (e.NewElement.FontFamily != null)
        //    {
        //        var font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, e.NewElement.FontFamily);
        //        _native.Typeface = font;
        //    }
        //}

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);
        //    if (_native == null)
        //        return;

        //}
    }
}