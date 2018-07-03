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

        public MainPage()
        {
            this.InitializeComponent();
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
                this.txtFile.Text = file.Name;                
            }


        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {

            if ((bool)rbnNew.IsChecked)
            {
                //Navigate to the editor page with an empty file
                Frame.Navigate(typeof(Editor), null);
            }
            else if ((bool)rbnExisting.IsChecked)
            {
                //Navigate to the editor page with the existing file
                Frame.Navigate(typeof(Editor), file);
            }
            
        }

        private void rbnNew_Checked(object sender, RoutedEventArgs e)
        {
            txtFile.Text = string.Empty;
        }

    }
}
