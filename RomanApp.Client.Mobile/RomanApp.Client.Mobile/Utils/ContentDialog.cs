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

        public ContentDialog()
        {
            _buttons = new List<ContentDialogButton>();
        }


        public void AddButton(ContentDialogButton button)
        {
            _buttons.Add(button);
        }

        public Task<object> ShowAsync()
        {
            var task = new TaskCompletionSource<object>();

            CreateContent(task);

            var page = new ContentPage();
            page.Title = Title;
            page.Content = _mainGrid;

            Navigation.PushModalAsync(page);

            return task.Task;
        }

        private void CreateContent(TaskCompletionSource<object> task)
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
            CreateButtons(task);

            _mainGrid.Children.Add(Content, 0, 0);
        }

        private void CreateButtons(TaskCompletionSource<object> task)
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
                    await Navigation.PopModalAsync();
                    task.SetResult(o.Result);
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

        #endregion
    }
}
