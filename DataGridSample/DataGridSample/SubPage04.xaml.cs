using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace DataGridSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class SubPage04 : Page
    {
        public Pref[] Prefs { get; } = new Pref[]
        {
                new Pref { RegionId = 1, Name = "東京都",  Population = 13784212 },
                new Pref { RegionId = 1, Name = "神奈川県",Population =  9179835 },
                new Pref { RegionId = 1, Name = "千葉県",  Population =  6268585 },
                new Pref { RegionId = 2, Name = "大阪府",  Population =  8824566 },
                new Pref { RegionId = 2, Name = "京都府",  Population =  2591779 },
                new Pref { RegionId = 2, Name = "奈良県",  Population =  1340070 },
        };

        public string[] ColorItems { get; } = new string[] { "null", "Red", "Green", "Blue", "Yellow", "White", "Black", "LightGray" };

        public SubPage04()
        {
            InitializeComponent();
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = Windows.UI.Core.AppViewBackButtonVisibility.Visible;

            GridLinesVisibilityComboBox.Loaded += (sender, e) => GridLinesVisibilityComboBox.SelectedIndex = 0;
            AlternatingRowBackgroundComboBox.Loaded += (sender, e) => AlternatingRowBackgroundComboBox.SelectedIndex = 0;
            AlternatingRowForegroundComboBox.Loaded += (sender, e) => AlternatingRowForegroundComboBox.SelectedIndex = 0;
            RowBackgroundComboBox.Loaded += (sender, e) => RowBackgroundComboBox.SelectedIndex = 0;
            RowForegroundComboBox.Loaded += (sender, e) => RowForegroundComboBox.SelectedIndex = 0;
            HeadersVisibilityComboBox.Loaded += (sender, e) => HeadersVisibilityComboBox.SelectedIndex = 0;
        }

        private void BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e) => Frame.GoBack();
        protected override void OnNavigatedFrom(NavigationEventArgs e) => Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= BackRequested;
        protected override void OnNavigatedTo(NavigationEventArgs e) => Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += BackRequested;
    }
}
