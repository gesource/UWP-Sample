using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace DataGridSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoSubPage01_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(SubPage01));
        private void GoSubPage02_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(SubPage02));
        private void GoSubPage03_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(SubPage03));
        private void GoSubPage04_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(SubPage04));
    }
}
