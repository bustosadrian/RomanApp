using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Utils
{
    public class ContentDialog
    {
        private List<ContentDialogButton> _buttons;

        private Grid _mainGrid;
        private Grid _toolbarGrid;

        private TaskCompletionSource<object> _task;

        public ContentDialog()
        {
            _buttons = new List<ContentDialogButton>();
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


            ColumnDefinitionCollection toolbarButtonsColumns = new ColumnDefinitionCollection();
            for(int i = 0; i < _buttons.Count; i++)
            {
                toolbarButtonsColumns.Add(new ColumnDefinition()
                {
                    Width  = new GridLength(2, GridUnitType.Star),
                });
            }
            _toolbarGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) }
                },
                ColumnDefinitions = toolbarButtonsColumns,
            };

            _mainGrid.Children.Add(_toolbarGrid, 0, 1);
            CreateButtons();

            _mainGrid.Children.Add(Content, 0, 0);
        }

        private void CreateButtons()
        {
            int column = 0;
            foreach(var o in _buttons)
            {
                var button = new Button
                {
                    Text = o.Text,
                };
                button.Clicked += async (s, e) =>
                {
                    if (o.CloseDialog)
                    {
                        await Navigation.PopModalAsync();
                    }
                    _task.SetResult(o.Result);
                };

                o.Button = button;
                _toolbarGrid.Children.Add(button, column, 0);
                
                column++;
            }
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

    public class ContentDialogButton
    {
        #region Properties

        public string Text
        {
            get;
            set;
        }

        public object Result
        {
            get;
            set;
        }

        internal Button Button
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
