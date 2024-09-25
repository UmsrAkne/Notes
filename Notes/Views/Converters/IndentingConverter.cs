using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Notes.Views.Converters
{
    /// <summary>
    /// Scrap オブジェクトの IndentCount をインデント（実際にはボーダーの長さ）に変換するためのコンバーターです。
    /// </summary>
    public class IndentingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var leftIndent = (int)value * 15.0;
                return new Thickness(leftIndent, 0, 0, 0);
            }

            return default(Thickness);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}