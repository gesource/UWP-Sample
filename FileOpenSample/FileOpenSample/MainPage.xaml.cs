using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace FileOpenSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// ファイルを開く
        /// </summary>
        private async void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.List,
                // 初期フォルダー
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop,
                // 開くボタンのラベルのテキスト
                CommitButtonText = "このファイルを開く",
                // すべてのファイルを選択可能
                FileTypeFilter = { "*" },
                // 選択可能なファイルの拡張子を指定する
                //FileTypeFilter = { ".txt", ".xlsx", },
            };
            // 選択されたファイルを取得する
            var file = await filePicker.PickSingleFileAsync();
            if (file != null)
            {
                ListView.ItemsSource = new[] { GetFileName(file) };
            }
        }

        /// <summary>
        /// 複数のファイルを開く
        /// </summary>
        private async void ButtonOpenFiles_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.List,
                // 初期フォルダー
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop,
                // 開くボタンのラベルのテキスト
                CommitButtonText = "このファイルを開く",
                // すべてのファイルを選択可能
                FileTypeFilter = { "*" },
                // 選択可能なファイルの拡張子を指定する
                //FileTypeFilter = { ".txt", ".xlsx", },
            };

            // 選択されたファイルを取得する(複数選択)
            var files = await filePicker.PickMultipleFilesAsync();

            // 選択されたファイルのパスをリストビューに表示する
            ListView.ItemsSource = files.Select(file => GetFileName(file));
        }

        /// <summary>
        /// フォルダーを開く
        /// </summary>
        private async void ButtonOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker
            {
                // フォルダーの選択ボタンのラベルのテキスト
                CommitButtonText = "このフォルダーを選択する",
                // 初期フォルダー
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop
            };
            // すべてのファイル
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder == null)
                return;

            // フォルダー内コンテンツの読み書きのアクセス権を追加する
            Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);

            // 選択されたファイルのパスをリストビューに表示する
            ListView.ItemsSource = await GetFileNmaeInFolderAsync(folder);
        }

        private void Border_DragOver(object sender, DragEventArgs e)
        {
            // コピーのアイコンに切り替える
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private async void Border_Drop(object sender, DragEventArgs e)
        {
            // ファイルの場合
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                // ドロップされた項目を取得する
                var items = await e.DataView.GetStorageItemsAsync();

                // ファイルのパスをリストビューに表示する
                var list = new List<string>();
                foreach (var item in items)
                {
                    if (item is StorageFolder)
                    {
                        // フォルダーのとき
                        list.AddRange(await GetFileNmaeInFolderAsync(item as StorageFolder));
                    }
                    else
                    {
                        // ファイルのとき
                        list.Add(GetFileName(item));
                    }
                }
                ListView.ItemsSource = list;
            }
        }

        /// <summary>
        /// リストビューに表示するファイル名を取得する
        /// </summary>
        private string GetFileName(IStorageItem file)
        {
            return $"File: {file.Path}";
        }

        /// <summary>
        /// リストビューに表示するフォルダー名とフォルダー内ファイル名を取得する
        /// </summary>
        private async Task<IEnumerable<string>> GetFileNmaeInFolderAsync(StorageFolder folder)
        {
            var result = new List<string>();
            result.Add($"Folder: {folder.Path} {folder.Name}");

            var files = await folder.GetFilesAsync();
            result.AddRange(files.Select(x => $">> {x.Path}").ToArray());

            return result.ToArray();
        }

    }
}
