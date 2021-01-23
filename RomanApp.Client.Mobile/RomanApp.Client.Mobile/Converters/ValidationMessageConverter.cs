using Reedoo.NET.Messages.Output.Validation;
using RomanApp.Commons.Utils;
using RomanApp.Messages.Output.Validation;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class ValidationMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if (value is ValidationError error)
            {
                if (error is AmountValidationError amountError)
                {
                    switch (amountError.Reason)
                    {
                        case FailuireReason.NumberFormat:
                            retval = Resx.ValidationMessages.sheet_add_edit_amount_format;
                            break;
                        case FailuireReason.OutOfRangeZero:
                            retval = Resx.ValidationMessages.sheet_add_edit_guest_amount_range;
                            break;
                        case FailuireReason.OutOfRangeGreaterZero:
                            retval = Resx.ValidationMessages.sheet_add_edit_expense_amount_range;
                            break;
                    }
                }
                else
                {
                    retval = RomanApp.Client.Mobile.Resx.ValidationMessages.ResourceManager.GetString(error.Message);
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
