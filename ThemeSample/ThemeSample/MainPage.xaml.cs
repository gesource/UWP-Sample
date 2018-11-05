﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace ThemeSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            ApplicationThemeText.Text = Application.Current.RequestedTheme.ToString();
            ThemePicker.SelectedIndex = (int)GetCurrentTheme();
            ThemePicker.SelectionChanged += ThemePicker_SelectionChanged;
        }

        private ElementTheme GetCurrentTheme()
        {
            return StackPanel.RequestedTheme;
        }

        private void ThemePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackPanel.RequestedTheme = (ElementTheme)ThemePicker.SelectedIndex;
        }
    }
}