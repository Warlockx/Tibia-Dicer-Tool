using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Dice_Tool.Converters
{
    public class PercentageConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value} %";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string percentageString = value.ToString().Replace(" %","");
            int percentage = 180;

            if (percentageString.Length < 2)
                return percentage;

            int.TryParse(percentageString,out percentage);

            return percentage == 0 ? 180 : percentage;
        }
    }
}
