﻿using System;
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
            string percentageString = (string)value;
            int percentage = 180;

            int.TryParse(percentageString.Substring(0, percentageString.Length - 2),out percentage);

            return percentage;
        }
    }
}