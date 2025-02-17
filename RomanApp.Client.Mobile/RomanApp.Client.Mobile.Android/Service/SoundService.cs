﻿using Android.App;
using Android.Views;
using RomanApp.Client.Mobile.Services;

namespace RomanApp.Client.Mobile.Droid.Service
{
    public class SoundService : ISoundService
    {
        public void Tap()
        {
            var activity = MainActivity.Instance;
            var view = activity.FindViewById<View>(
                Android.Resource.Id.Content);
            view.PlaySoundEffect(SoundEffects.Click);
        }
    }
}