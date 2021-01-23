using Reedoo.NET.XAML;
using RomanApp.Client.Mobile.Platform;
using RomanApp.Client.Mobile.ViewModels.Help;
using RomanApp.Client.Mobile.Views.Help.Topics;
using RomanApp.Client.ViewModel;
using RomanApp.Commons;
using RomanApp.Messages;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Help
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ClientView(StatesKeys.HELP, typeof(HelpViewModel))]
    public partial class HelpView : NavigablePage
    {
        public HelpView()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            ((BusViewModel)BindingContext).GoBack();

            return true;
        }
    }

    public class HelpTopicTemplateConverter : IValueConverter
    {
        private HelpTopics _helpTopics;

        public HelpTopicTemplateConverter()
        {
            _helpTopics = new HelpTopics();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ControlTemplate retval = null;

            if(value is HelpTopic topic)
            {
                switch (topic)
                {
                    case HelpTopic.Overview:
                        retval = (ControlTemplate)_helpTopics["template_help_overview"];
                        break;
                    case HelpTopic.SheetOverview:
                        retval = (ControlTemplate)_helpTopics["template_help_sheet_overview"];
                        break;
                    case HelpTopic.SheetInputOverview:
                        retval = (ControlTemplate)_helpTopics["template_help_sheet_input"];
                        break;
                    case HelpTopic.SheetOutcomeOverview:
                        retval = (ControlTemplate)_helpTopics["template_help_sheet_outcome"];
                        break;
                    case HelpTopic.Settings:
                        retval = (ControlTemplate)_helpTopics["template_help_settings"];
                        break;
                    case HelpTopic.Troubleshooting:
                        retval = (ControlTemplate)_helpTopics["template_help_troubleshooting"];
                        break;
                    default:
                        retval = (ControlTemplate)_helpTopics["template_help_no_help"];
                        break;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}