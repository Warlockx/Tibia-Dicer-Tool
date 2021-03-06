﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Dice_Tool.Converters
{
    public class DecimalConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double currentValue = (double)value/1000;          
                
            return $"{currentValue.ToString("N3")} gp";            
        }


        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueString = value.ToString().Replace(" gp", "").Replace(',', '.');            

            double currentValue = 0;

            if (valueString.Length < 3)
                return currentValue;

            Double.TryParse(valueString, out currentValue);

            return currentValue;

        
         
        }
    }
}
