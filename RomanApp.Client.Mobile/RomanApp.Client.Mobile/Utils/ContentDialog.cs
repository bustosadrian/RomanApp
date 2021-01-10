using RomanApp.Client.Mobile.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Utils
{
    public class ContentDialog
    {
        private ObservableCollection<ContentDialogButton> _buttons;

        private Grid _mainGrid;

        private TaskCompletionSource<object> _task;

        private ContentDialogButton _backButton;

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

            var page = new DialogPage();
            page.Title = Title;
            page.Content = _mainGrid;
            if(_backButton != null)
            {
                page.BackPressed += Page_BackPressed;
            }

            Navigation.PushModalAsync(page);
        }

        private void Page_BackPressed(object sender, EventArgs e)
        {
            Action(_backButton);
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

            _backButton = _buttons.SingleOrDefault(x => x.IsBack);

            Toolbar toolbar = new Toolbar(new ObservableCollection<ToolbarButton>(_buttons));

            toolbar.ButtonTapped += Toolbar_ButtonTapped;

            _mainGrid.Children.Add(toolbar, 0, 1);
            _mainGrid.Children.Add(Content, 0, 0);
        }

        private void Toolbar_ButtonTapped(object sender, EventArgs e)
        {
            try
            {
                ContentDialogButton button = (ContentDialogButton)sender;
                Action(button);
            }
            catch (Exception ex)
            {
                RaiseOnError(ex);
            }
        }

        private async void Action(ContentDialogButton button)
        {
            if (button.CloseDialog)
            {
                await Navigation.PopModalAsync();
            }
            _task.SetResult(button.Result);
        }

        #region Events

        public event EventHandler<ErrorEventArgs> OnError;
        private void RaiseOnError(Exception e)
        {
            OnError?.Invoke(this, new ErrorEventArgs(e));
        }


        #endregion

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

        internal bool IsBack
        {
            get;
            set;
        }

        #endregion
    }

    public sealed class DialogPage : ContentPage
    {
        protected override bool OnBackButtonPressed()
        {
            RaiseBackPressed();
            return true;
        }

        #region Events

        public event EventHandler BackPressed;
        private void RaiseBackPressed()
        {
            BackPressed?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}
