using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace DataGridSample
{
    internal class IndexToGridLinesVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || (int)value < 0)
                return DataGridGridLinesVisibility.None;
            return (DataGridGridLinesVisibility)(int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    internal class IndexToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color[] colors = new Color[] { Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.White, Colors.Black, Colors.LightGray };
            int index = (int)value - 1;
            if (value == null || index < 0 || index >= colors.Length)
                return null;
            return new SolidColorBrush(colors[index]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    internal class IndexToDataGridHeadersVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || (int)value < 0)
                return DataGridHeadersVisibility.All;
            return (DataGridHeadersVisibility)(int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
