# ListViewのグループ化のサンプル

ListViewでデータをグループ化して表示するUWPアプリケーションです。

![](ListViewGrouping.png)

## グループ化して表示するには

### XAMLファイル

XAMLファイルでは、ListViewのGroupStyleの設定が必要です。

    <ListView ItemsSource="{x:Bind ViewModel.ListViewItems.View, Mode=OneWay}">
        <ListView.GroupStyle>
            <GroupStyle>
                <GroupStyle.HeaderTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Key}" />
                    </DataTemplate>
                </GroupStyle.HeaderTemplate>
            </GroupStyle>
        </ListView.GroupStyle>
        <ListView.ItemTemplate>
            <DataTemplate x:DataType="ViewModels:Pref">
                <StackPanel>
                    <TextBlock Text="{x:Bind Name}" />
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>

### csファイル

CollectionViewSourceのIsSourceGroupedをtrueに設定します。

ObservableCollectionをLINQのGroupByを使ってグループ化し、CollectionViewSourceのSourceプロパティに設定します。

        public CollectionViewSource ListViewItems { get; private set; } = new CollectionViewSource();
        private ObservableCollection<Pref> listViewItems { get; set; }

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
