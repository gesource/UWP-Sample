using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace ColorPickerSample
{
    internal class ColorSpectrumShapeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return ColorSpectrumShape.Box;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
