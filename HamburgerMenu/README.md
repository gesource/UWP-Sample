# ハンバーガーメニューのサンプル

ハンバーガーメニューのサンプルアプリです。

![ハンバーガーメニューのサンプル](HamburgerMenu.gif)

## XAML

ToggleButtonのIsCheckedプロパティに、SplitViewのIsPaneOpenプロパティをバインドします。

    <StackPanel Orientation="Horizontal">
        <ToggleButton
            Width="48"
            Height="40"
            Content="&#xE700;"
            FontFamily="{StaticResource SymbolThemeFontFamily}"
            IsChecked="{Binding IsPaneOpen, ElementName=SplitView, Mode=TwoWay}" />
        <TextBlock Text="ハンバーガーメニューのサンプル" />
    </StackPanel>
    <SplitView x:Name="SplitView" Grid.Row="1">
        <SplitView.Pane>
            <ListView>
                <ListViewItem Content="メニュー1" />
                <ListViewItem Content="メニュー2" />
                <ListViewItem Content="メニュー3" />
            </ListView>
        </SplitView.Pane>
    </SplitView>

以上です。
