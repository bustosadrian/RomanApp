
using RomanApp.Client.Mobile.Services;
using RomanApp.Client.Mobile.Utils;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShapeButton : Grid
    {
        private ISoundService _soundService;

        public ShapeButton()
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
            await Shape.ScaleTo(.75, 10);
            await Shape.ScaleTo(1, 10);

            _soundService.Click();
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

        public static readonly BindableProperty FillProperty = BindableProperty.Create(nameof(Fill),
        typeof(Color), typeof(ShapeButton), Color.White);
        public Color Fill
        {
            get { return (Color)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly BindableProperty StrokeProperty = BindableProperty.Create(nameof(Stroke),
        typeof(Color), typeof(ShapeButton), Color.White);
        public Color Stroke
        {
            get { return (Color)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon),
                typeof(Icons), typeof(ShapeButton), null);
        public Icons Icon
        {
            get { return (Icons)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        #endregion
    }
}