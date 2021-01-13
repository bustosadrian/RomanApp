using RomanApp.Messages;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class HelpTopicConverter : IValueConverter
    {
        public HelpTopicConverter()
        {
            ForQuickSummary = false;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if(value is HelpTopic topic)
            {
                if (!ForQuickSummary)
                {
                    switch (topic)
                    {
                        case HelpTopic.Overview:
                            retval = RomanApp.Client.Mobile.Resx.Help.Overview_Help_Topic;
                            break;
                        case HelpTopic.Settings:
                            retval = RomanApp.Client.Mobile.Resx.Help.Sheet_Settings_Help_Topic;
                            break;
                        case HelpTopic.SheetOverview:
                            retval = RomanApp.Client.Mobile.Resx.Help.Sheet_Overview_Help_Topic;
                            break;
                        case HelpTopic.SheetInputOverview:
                            retval = RomanApp.Client.Mobile.Resx.Help.Sheet_Input_Help_Topic;
                            break;
                        case HelpTopic.SheetOutcomeOverview:
                            retval = RomanApp.Client.Mobile.Resx.Help.Sheet_Outcome_Help_Topic;
                            break;
                    }
                }
                else
                {
                    switch (topic)
                    {
                        case HelpTopic.Overview:
                            retval = RomanApp.Client.Mobile.Resx.Help.Overview_Help_Topic_Quick_Summary;
                            break;
                        case HelpTopic.Settings:
                            retval = RomanApp.Client.Mobile.Resx.Help.Sheet_Settings_Help_Topic_Quick_Summary;
                            break;
                        case HelpTopic.SheetOverview:
                            retval = RomanApp.Client.Mobile.Resx.Help.Sheet_Overview_Help_Topic_Quick_Summary;
                            break;
                        case HelpTopic.SheetInputOverview:
                            retval = RomanApp.Client.Mobile.Resx.Help.Sheet_Input_Help_Topic_Quick_Summary;
                            break;
                        case HelpTopic.SheetOutcomeOverview:
                            retval = RomanApp.Client.Mobile.Resx.Help.Sheet_Outcome_Help_Topic_Quick_Summary;
                            break;
                    }
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


        #region Properties

        public bool ForQuickSummary
        {
            get;
            set;
        }

        #endregion
    }
}
