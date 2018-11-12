using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace DataGridSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class SubPage03 : Page
    {
        /// <summary>
        /// コンボボックスの選択肢
        /// </summary>
        public Region[] Regions { get; } = new Region[] 
        {
            new Region{ RegionId = 1, RegionName="関東地方" },
            new Region{ RegionId = 2, RegionName="近畿地方" },
        };

        public Pref[] Prefs { get; } = new Pref[]
        {
            new Pref { RegionId = 1, Name = "東京都",  Population = 13784212 },
            new Pref { RegionId = 1, Name = "神奈川県",Population =  9179835 },
            new Pref { RegionId = 1, Name = "千葉県",  Population =  6268585 },
            new Pref { RegionId = 2, Name = "大阪府",  Population =  8824566 },
            new Pref { RegionId = 2, Name = "京都府",  Population =  2591779 },
            new Pref { RegionId = 2, Name = "奈良県",  Population =  1340070 },
        };

        public SubPage03()
        {
            InitializeComponent();
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = Windows.UI.Core.AppViewBackButtonVisibility.Visible;
        }
        private void BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e) => Frame.GoBack();
        protected override void OnNavigatedFrom(NavigationEventArgs e) => Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= BackRequested;
        protected override void OnNavigatedTo(NavigationEventArgs e) => Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += BackRequested;
    }
}
