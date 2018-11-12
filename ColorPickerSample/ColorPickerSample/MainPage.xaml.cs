using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace ColorPickerSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Dictionary<ColorSpectrumShape, string> ColorSpectrumShapeItems { get; } = new Dictionary<ColorSpectrumShape, string>
        {
            [ColorSpectrumShape.Box] = "ColorSpectrumShape.Box",
            [ColorSpectrumShape.Ring] = "ColorSpectrumShape.Ring",
        };

        public MainPage()
        {
            InitializeComponent();
            ColorSpectrumShapeCombBox.Loaded += (sender, e) => ColorSpectrumShapeCombBox.SelectedIndex = 0;
            ThemePicker.SelectedIndex = (int)Grid.RequestedTheme;
            ThemePicker.SelectionChanged += (sender, e) => Grid.RequestedTheme = (ElementTheme)ThemePicker.SelectedIndex;
        }
    }
}
