using RomanApp.Client.Mobile.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Utils
{
    public class ContentDialog
    {
        private ObservableCollection<ContentDialogButton> _buttons;

        private Grid _mainGrid;

        private TaskCompletionSource<object> _task;

        public ContentDialog()
        {
            _buttons = new ObservableCollection<ContentDialogButton>();
        }


        public void AddButton(ContentDialogButton button)
        {
            _buttons.Add(button);
        }

        public void Show()
        {
            CreateContent();

            var page = new ContentPage();
            page.Title = Title;
            page.Content = _mainGrid;

            Navigation.PushModalAsync(page);
        }

        public Task<object> Wait()
        {
            _task = new TaskCompletionSource<object>();
            return _task.Task;
        }

        private void CreateContent()
        {
            _mainGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) }
                },
            };

            Toolbar toolbar = new Toolbar(new ObservableCollection<ToolbarButton>(_buttons));

            toolbar.ButtonTapped += Toolbar_ButtonTapped;
            //toolbar.BackgroundColor = Color.FromHex("#001b00");
            //toolbar.ButtonsSize = 64;
            //toolbar.Padding = new Thickness(15);

            _mainGrid.Children.Add(toolbar, 0, 1);
            _mainGrid.Children.Add(Content, 0, 0);
        }

        

        //private void CreateButtons()
        //{
        //    int column = 0;
        //    foreach(var o in _buttons)
        //    {
        //        var button = new Button
        //        {
        //            Text = o.Text,
        //        };
        //        button.Clicked += async (s, e) =>
        //        {
        //            if (o.CloseDialog)
        //            {
        //                await Navigation.PopModalAsync();
        //            }
        //            _task.SetResult(o.Result);
        //        };

        //        o.Button = button;
        //        _toolbarGrid.Children.Add(button, column, 0);
                
        //        column++;
        //    }
        //}

        private async void Toolbar_ButtonTapped(object sender, EventArgs e)
        {
            ContentDialogButton button = (ContentDialogButton)sender;
            if (button.CloseDialog)
            {
                await Navigation.PopModalAsync();
            }
            _task.SetResult(button.Result);
        }

        #region Properties

        private INavigation Navigation
        {
            get
            {
                return Application.Current.MainPage.Navigation;
            }
        }

        public string Title
        {
            get;
            set;
        }

        public View Content
        {
            get;
            set;
        }

        #endregion

    }

    public class ContentDialogButton : ToolbarButton
    {
        #region Properties

        public object Result
        {
            get;
            set;
        }

        internal bool CloseDialog
        {
            get;
            set;
        }

        #endregion
    }
}
