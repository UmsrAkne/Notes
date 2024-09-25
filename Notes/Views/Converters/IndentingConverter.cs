using System;
using System.Globalization;
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
                return (int)value * 15.0;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}