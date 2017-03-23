using System;
using System.Globalization;
using System.Windows.Data;
using Shared.Enums;

namespace Shared.Converter
{
    public class DrinkTypeEnumDescriptionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value.ToString()))  // This is for databinding
                return String.Empty;
            return (StringToEnum<DrinkType>(value.ToString())).GetDescription(); // <-- The extention method
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value.ToString())) // This is for databinding
                return String.Empty;
            return StringToEnum<DrinkType>(value.ToString());
        }

        public static T StringToEnum<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
    }
}