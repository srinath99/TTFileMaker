using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TTFileMaker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Windows.Storage.StorageFile file;
        Windows.Storage.StorageFolder folder;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".air");

            file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.txtFile.Text = file.Name;                
            }


        }


        private async void btnFolder_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FolderPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            folder = await picker.PickSingleFolderAsync();
        }

        private async void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (txtChosenFolder.Text != "" ^ txtFile.Text != "")
            {
                if (folder == null)
                {
                    folder = await file.GetParentAsync();
                }

                if (file == null)
                {
                    file = await folder.CreateFileAsync(txtChosenFolder.Text + ".air", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                }

                string rawFile = await Windows.Storage.FileIO.ReadTextAsync(file);
                this.Frame.Navigate(typeof(Editor), rawFile);
            }
        }
    }
}
