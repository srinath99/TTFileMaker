using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TTFileMaker.View_Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TTFileMaker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Editor : Page
    {

        private Windows.Storage.StorageFile _file;
        ViewModel viewModel;
        

 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                _file = (Windows.Storage.StorageFile)e.Parameter;
                viewModel = new ViewModel(_file);
            }
            else
            {
                viewModel = new ViewModel();
            }

            
            
            this.DataContext = viewModel;
        }

        public Editor()
        {
            this.InitializeComponent();            
        }

        private void Aircraft_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            placeholderText.Visibility = Visibility.Collapsed;
            aircraftGrid.Visibility = Visibility.Visible;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Write();
        }
    }


}
