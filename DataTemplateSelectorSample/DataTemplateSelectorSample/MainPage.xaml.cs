using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace DataTemplateSelectorSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Person> Items { get; } = new ObservableCollection<Person>
        {
            new Person{ Name="Alice", Age=18 },
            new Person{ Name="Bob", Age=19 },
            new Person{ Name="Carol", Age=20 },
            new Person{ Name="Dave", Age=21 },
        };

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
