using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.MVVMBsp.Converter
{
    public class ValidateEntriesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return (values[0] as string)?.Length > 0 & (string.IsNullOrEmpty(values[1].ToString()) ? System.Convert.ToInt32(values[1]) > 0 : false);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
