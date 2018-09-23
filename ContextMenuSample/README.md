# コンテキストメニューを表示するサンプル

ボタンを右クリックしたときにコンテキストメニューを表示するサンプルです。

![](ContextMenuSample.gif)

ボタンを右クリックすると、コンテキストメニューを表示します。  
コンテキストメニューからメニュー項目を選択すると、選択された項目を表示します。

## XAML

    <Button Content="このボタンを右クリックします。" RightTapped="Button_RightTapped">
        <FlyoutBase.AttachedFlyout>
            <MenuFlyout>
                <MenuFlyoutItem Click="MenuFlyoutItem_Click" Text="項目3" />
                <MenuFlyoutItem Click="MenuFlyoutItem_Click" Text="項目4" />
            </MenuFlyout>
        </FlyoutBase.AttachedFlyout>
    </Button>

コントロールを右クリックしたときにコンテキストメニューを表示したいので、RightTappedイベントを設定します。

メニュー項目がクリックされたことを知るために、MenuFlyoutItemのClickイベントを設定します。

## C#

### コンテキストメニューを表示する

コントロールの右クリックイベントで、コンテキストメニューを表示します。

    private void Button_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
    }

### メニューが選択されたときのイベント

メニューがクリックされたとき、Clickイベントが呼ばれます。

    private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
    {
        TextBlock.Text = $"「{((MenuFlyoutItem)sender).Text}」が選択されました";
    }

## Button.Flyoutについて

ボタンコントロールには、Flyoutを表示する機能があります。

        <Button Content="このボタンを右クリックします。" RightTapped="Button_RightTapped">
            <Button.Flyout>
                <MenuFlyout>
                    <MenuFlyoutItem Click="MenuFlyoutItem_Click" Text="項目1" />
                    <MenuFlyoutItem Click="MenuFlyoutItem_Click" Text="項目2" />
                </MenuFlyout>
            </Button.Flyout>
        </Button>

このように設定すると、左クリックしたときにFlayoutが表示されます。
