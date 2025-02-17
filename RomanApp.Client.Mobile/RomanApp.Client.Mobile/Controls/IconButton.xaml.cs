﻿using RomanApp.Client.Mobile.Services;
using RomanApp.Client.Mobile.Utils;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconButton : Icon
    {

        private ISoundService _soundService;

        public IconButton()
        {
            InitializeComponent();

            _soundService = DependencyService.Get<ISoundService>();

            AddTapGesture();
        }

        private void AddTapGesture()
        {
            var gesture = new TapGestureRecognizer();
            gesture.Tapped += Gesture_Tapped;
            GestureRecognizers.Add(gesture);
        }

        private async void Gesture_Tapped(object sender, System.EventArgs e)
        {
            await this.ScaleTo(.75, 10);
            await this.ScaleTo(1, 10);

            _soundService?.Tap();
            RaiseTapped();
            if (Command != null)
            {
                Execute(Command, null);
            }
        }

        #region Events

        public event EventHandler<EventArgs> Tapped;
        private void RaiseTapped()
        {
            Tapped?.Invoke(this, new EventArgs());
        }

        #endregion

        #region Commands

        public void Execute(ICommand command, object parameter)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(parameter);
            }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(IconButton), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion

        #region Properties

        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon),
                typeof(Icons), typeof(IconButton), null);

        public Icons Icon
        {
            get { return (Icons)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size),
                typeof(double), typeof(IconButton), (double)24);

        public double Size
        {
            get { return (double)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        #endregion

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            var service = DependencyService.Get<ISoundService>();
            service?.Tap();
        }
    }
}