using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        string fullPath = "";
        Windows.Storage.StorageFolder folder;

        private async void setPath_Click(object sender, RoutedEventArgs e)
        {
/*            await new MessageDialog("💁‍♂️ take 0 champ...").ShowAsync();*/

            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
            folderPicker.FileTypeFilter.Add("*");

            folder = await folderPicker.PickSingleFolderAsync();
            string folderName = folder.Name;

            if (folder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                    FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                await new MessageDialog("Folder Chosen.").ShowAsync();
                folderNameTextBlock.Text = "\"" + folderName + "\"" + " folder chosen.";
                fullPath = folder.Path;
            }
            else
            {
                await new MessageDialog("No Folder Chosen.").ShowAsync();
            }
        }

        System.Text.StringBuilder outputText = new System.Text.StringBuilder();

        /*        internal static async Task DeleteTempFiles(ObservableCollection<Windows.Storage.StorageFile> exceptionFiles, Windows.Storage.StorageFolder folder, string fileNameStartsWith)
                {
                    var files = (await folder.GetFilesAsync())
                        .Where(p => p.DisplayName.StartsWith(fileNameStartsWith)
                        && !exceptionFiles.Any(e => e.DisplayName == p.DisplayName));

                    foreach (var file in files)
                    {
                        await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
                    }
                }*/
        /*await FileHelper.DeleteTempFiles(Files, KnownFolders.PicturesLibrary, "\_tmpFile");*/

        /// <summary>
        /// This below code is responsible for deleting the language files other than "en" in Witcher 3 various dlc folders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void deleteFolder_Click(object sender, RoutedEventArgs e)
        {
            // ---------------------------------------------------------- Witcher 3 "dlc" folder ----------------------------------------------------------

            Windows.Storage.StorageFolder bobFolder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\bob\\content");
            Windows.Storage.StorageFolder dlc1Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc1\\content");
            Windows.Storage.StorageFolder dlc2Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc2\\content");
            Windows.Storage.StorageFolder dlc3Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc3\\content");
            Windows.Storage.StorageFolder dlc4Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc4\\content");
            Windows.Storage.StorageFolder dlc5Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc5\\content");
            Windows.Storage.StorageFolder dlc6Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc6\\content");
            Windows.Storage.StorageFolder dlc7Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc7\\content");
            Windows.Storage.StorageFolder dlc8Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc8\\content");
            Windows.Storage.StorageFolder dlc9Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc9\\content");
            Windows.Storage.StorageFolder dlc10Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc10\\content");
            Windows.Storage.StorageFolder dlc11Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc11\\content");
            Windows.Storage.StorageFolder dlc12Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc12\\content");
            Windows.Storage.StorageFolder dlc13Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc13\\content");
            Windows.Storage.StorageFolder dlc14Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc14\\content");
            Windows.Storage.StorageFolder dlc15Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc15\\content");
            Windows.Storage.StorageFolder dlc16Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc16\\content");
            Windows.Storage.StorageFolder dlc17Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc17\\content");
            Windows.Storage.StorageFolder dlc18Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc18\\content");
            Windows.Storage.StorageFolder dlc20Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\dlc20\\content");
            Windows.Storage.StorageFolder ep1Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\dlc\\ep1\\content");

            var bobFiles = (await bobFolder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in bobFiles)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc1Files = (await dlc1Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc1Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }


            var dlc2Files = (await dlc2Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc2Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc3Files = (await dlc3Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc3Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc4Files = (await dlc4Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc4Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc5Files = (await dlc5Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc5Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc6Files = (await dlc6Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc6Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc7Files = (await dlc7Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc7Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc8Files = (await dlc8Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc8Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc9Files = (await dlc9Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc9Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc10Files = (await dlc10Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc10Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc11Files = (await dlc11Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc11Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc12Files = (await dlc12Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc12Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc13Files = (await dlc13Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc13Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc14Files = (await dlc14Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc14Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc15Files = (await dlc15Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc15Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc16Files = (await dlc16Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc16Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc17Files = (await dlc17Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc17Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc18Files = (await dlc18Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc18Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var dlc20Files = (await dlc20Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in dlc20Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var ep1Files = (await ep1Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in ep1Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            // ---------------------------------------------------------- Witcher 3 "content" folder ----------------------------------------------------------

            Windows.Storage.StorageFolder content0Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content0");
            Windows.Storage.StorageFolder content1Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content1");
            Windows.Storage.StorageFolder content2Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content2");
            Windows.Storage.StorageFolder content3Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content3");
            Windows.Storage.StorageFolder content4Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content4");
            Windows.Storage.StorageFolder content5Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content5");
            Windows.Storage.StorageFolder content6Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content6");
            Windows.Storage.StorageFolder content7Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content7");
            Windows.Storage.StorageFolder content8Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content8");
            Windows.Storage.StorageFolder content9Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content9");
            Windows.Storage.StorageFolder content10Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content10");
            Windows.Storage.StorageFolder content11Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content11");
            Windows.Storage.StorageFolder content12Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Games\\TheWitcher3\\content\\content12");

            var content0Files = (await content0Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content0Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content1Files = (await content1Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content1Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content2Files = (await content2Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content2Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content3Files = (await content3Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content3Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content4Files = (await content4Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content4Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content5Files = (await content5Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content5Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content6Files = (await content6Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content6Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content7Files = (await content7Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content7Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content8Files = (await content8Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content8Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content9Files = (await content9Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content9Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content10Files = (await content10Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content10Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content11Files = (await content11Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content11Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            var content12Files = (await content12Folder.GetFilesAsync()).Where(p => p.DisplayName.StartsWith("ar") || p.DisplayName.StartsWith("br") || p.DisplayName.StartsWith("brpc")
            || p.DisplayName.StartsWith("cn") || p.DisplayName.StartsWith("cnpc") || p.DisplayName.StartsWith("cz") || p.DisplayName.StartsWith("de")
            || p.DisplayName.StartsWith("dep") || p.DisplayName.StartsWith("depc") || p.DisplayName.StartsWith("es") || p.DisplayName.StartsWith("esmx")
            || p.DisplayName.StartsWith("fr") || p.DisplayName.StartsWith("frpc") || p.DisplayName.StartsWith("hu") || p.DisplayName.StartsWith("it")
            || p.DisplayName.StartsWith("it") || p.DisplayName.StartsWith("jp") || p.DisplayName.StartsWith("jppc") || p.DisplayName.StartsWith("kr")
            || p.DisplayName.StartsWith("krpc") || p.DisplayName.StartsWith("pl") || p.DisplayName.StartsWith("plpc") || p.DisplayName.StartsWith("ru")
            || p.DisplayName.StartsWith("rupc") || p.DisplayName.StartsWith("tr") || p.DisplayName.StartsWith("zh"));

            foreach (var file in content12Files)
            {
                await file.DeleteAsync(Windows.Storage.StorageDeleteOption.Default);
            }

            await new MessageDialog("All non-en language files are deleted...").ShowAsync();

            /*Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync("sample.txt",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);*/

            /*            var myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Pictures);

                        Windows.Storage.StorageFolder newFolder = await myPictures.RequestAddFolderAsync();*/

            /*if (sampleFile != null)
            {
                await new MessageDialog("File created.").ShowAsync();
            }

            var success = await Windows.System.Launcher.LaunchFileAsync(sampleFile);*/

            /*            Windows.Storage.StorageFolder picturesFolder = Windows.Storage.KnownFolders.CameraRoll;

                        try
                        {
                            await picturesFolder.DeleteAsync(Windows.Storage.StorageDeleteOption.PermanentDelete);
                        }
                        catch (UnauthorizedAccessException ee)
                        {
                            System.Diagnostics.Debug.Write(ee);
                            exceptionTextBlock.Text = ee.ToString();
                        }*/

            /*            Windows.Storage.StorageFile newFile = await Windows.Storage.DownloadsFolder.CreateFileAsync("file.txt");*/

            /*Windows.Storage.StorageFolder witcher3Folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Users");

            IReadOnlyList<Windows.Storage.StorageFile> fileList = await witcher3Folder.GetFilesAsync();

            foreach (Windows.Storage.StorageFile file in fileList)
            {
                outputText.AppendLine(file.Name.ToString() + "\n");
            }*/

            /*            await Windows.Storage.StorageFolder.GetFolderFromPathAsync("C:\\Users\\user name");*/

            /*            await DeleteTempFiles(Windows.Storage.StorageFile.GetFileFromPathAsync, Windows.Storage.KnownFolders.PicturesLibrary, "\\wol");*/

            /*Windows.Storage.StorageFile testFile = await Windows.Storage.DownloadsFolder.CreateFileAsync("lol.txt", Windows.Storage);*/

            /*            fullPathTextBlock.Text = fullPath;

                        var content = fullPath + "\\temp";

                        var t = Task.Run(() => Directory.Delete(content));
                        t.Wait();*/

            /*            if (await folder.TryGetItemAsync("temp") != null)
                        {
                            await new MessageDialog("temp content folder.").ShowAsync();
                        }
                        else
                        {
                            await new MessageDialog("temp folder not found.").ShowAsync();
                        }*/

            /*            if (await folder.TryGetItemAsync("content") != null)
                        {
                            await new MessageDialog("Found content folder.").ShowAsync();
                        }
                        else
                        {
                            await new MessageDialog("content folder not found.").ShowAsync();
                        }*/
        }
    }
}
