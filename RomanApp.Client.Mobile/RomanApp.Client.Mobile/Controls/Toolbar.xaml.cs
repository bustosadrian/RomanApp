using RomanApp.Client.Mobile.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Toolbar : Grid
    {
        private Dictionary<IconButton, ToolbarButton> _buttons;

        public Toolbar()
        {
            _buttons = new Dictionary<IconButton, ToolbarButton>();

            InitializeComponent();
        }

        public Toolbar(ObservableCollection<ToolbarButton> buttons)
            : this()
        {
            InitializeComponent();

            Buttons = buttons;
        }

        private void Build()
        {
            _buttons = new Dictionary<IconButton, ToolbarButton>();

            RowDefinitions = new RowDefinitionCollection()
            {
                new RowDefinition { Height = new GridLength(2, GridUnitType.Star) }
            };

            ColumnDefinitionCollection columns = new ColumnDefinitionCollection();
            for (int i = 0; i < Buttons.Count; i++)
            {
                columns.Add(new ColumnDefinition()
                {
                    Width = new GridLength(2, GridUnitType.Star),
                });
            }
            ColumnDefinitions = columns;

            BuildButtons();
        }

        private void BuildButtons()
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                var o = Buttons[i];
                IconButton iconButton = new IconButton();
                iconButton.Value = o.Icon;
                iconButton.Tapped += Button_Tapped;
                iconButton.FontSize = ButtonsSize;
                iconButton.HorizontalOptions = LayoutOptions.Center;
                iconButton.VerticalOptions = LayoutOptions.Center;
                iconButton.TextColor = o.Color;

                _buttons.Add(iconButton, o);

                Children.Add(iconButton, i, 0);
            }
        }

        private void BuildBorder()
        {
            BoxView topLine = new BoxView()
            {
                VerticalOptions = LayoutOptions.Start,
                Color = BorderColor,
                HeightRequest = 2,
            };
            Children.Add(topLine, 0, 0);
        }

        private void Button_Tapped(object sender, EventArgs e)
        {
            foreach (KeyValuePair<IconButton, ToolbarButton> o in _buttons)
            {
                if(o.Key == sender)
                {
                    RaiseButtonTapped(o.Value);
                    break;
                }
            }
        }

        #region Events

        public event EventHandler<EventArgs> ButtonTapped;
        private void RaiseButtonTapped(ToolbarButton button)
        {
            ButtonTapped?.Invoke(button, new EventArgs());
        }

        #endregion

        #region Properties

        public static readonly BindableProperty ButtonsProperty = BindableProperty.Create(nameof(Buttons),
                typeof(ObservableCollection<ToolbarButton>), typeof(Toolbar),
                propertyChanged: OnButtonsChanged);

        public ObservableCollection<ToolbarButton> Buttons
        {
            get { return (ObservableCollection<ToolbarButton>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        private static void OnButtonsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Toolbar me = (Toolbar)bindable;
            me.Build();
        }

        private void Buttons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Build();
        }

        public static readonly BindableProperty ButtonsSizeProperty = BindableProperty.Create(nameof(ButtonsSize),
                typeof(double), typeof(Toolbar), (double)0, propertyChanged: OnButtonSizeChanged);

        public double ButtonsSize
        {
            get { return (double)GetValue(ButtonsSizeProperty); }
            set { SetValue(ButtonsSizeProperty, value); }
        }

        private static void OnButtonSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(newValue != null)
            {
                var me = (Toolbar)bindable;
                if(me._buttons != null)
                {
                    foreach (var o in me._buttons.Keys)
                    {
                        o.FontSize = (double)newValue;
                    }
                }
            }
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor),
                typeof(Color), typeof(Toolbar), Color.White);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        #endregion
    }

    public class ToolbarButton
    {
        #region Properties

        public Icons Icon
        {
            get;
            set;
        }

        public Color Color
        {
            get;
            set;
        }

        #endregion
    }
}