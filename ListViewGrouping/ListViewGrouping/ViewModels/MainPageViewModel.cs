using Prism.Commands;
using Prism.Windows.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace ListViewGrouping.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string region;
        public string Region
        {
            get { return region; }
            set { SetProperty(ref region, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public DelegateCommand AddPrefCommand { get; }

        public CollectionViewSource ListViewItems { get; private set; } = new CollectionViewSource();
        private ObservableCollection<Pref> listViewItems { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model"></param>
        /// <param name="navigationService"></param>
        public MainPageViewModel()
        {
            AddPrefCommand = new DelegateCommand(() =>
            {
                listViewItems.Add(new Pref { Region = Region, Name = Name });
                ListViewItems.Source = listViewItems.GroupBy(pref => pref.Region);
                RaisePropertyChanged("ListViewItems");
            },
            () => !string.IsNullOrEmpty(Region) && !string.IsNullOrEmpty(Name))
            .ObservesProperty(() => Region)
            .ObservesProperty(() => Name);

            listViewItems = new ObservableCollection<Pref>
            {
                new Pref { Region = "関東地方", Name = "東京都" },
                new Pref { Region = "関東地方", Name = "神奈川県" },
                new Pref { Region = "関東地方", Name = "千葉県" },
                new Pref { Region = "近畿地方", Name = "大阪府" },
                new Pref { Region = "近畿地方", Name = "京都府" },
                new Pref { Region = "近畿地方", Name = "奈良県" }
            };
            ListViewItems.IsSourceGrouped = true;
            ListViewItems.Source = listViewItems.GroupBy(pref => pref.Region);
        }
    }
}
