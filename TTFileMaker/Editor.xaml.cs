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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TTFileMaker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Editor : Page
    {

        private string _file;
        ViewModel viewModel;


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _file = (string) e.Parameter;
            viewModel = new ViewModel(_file);
            this.DataContext = viewModel;
        }

        public Editor()
        {
            this.InitializeComponent();            
        }

        private void Aircraft_ItemClick(object sender, ItemClickEventArgs e)
        {
            var plane = (Aircraft)e.ClickedItem;

            txtCallsign.Text = plane.Callsign;
            txtType.Text = plane.Type;
            txtRules.Text = plane.Rules;
            txtDepart.Text = plane.Dep;
            txtArrive.Text = plane.Arr;
            txtEngine.Text = plane.Engine;
            txtCruise.Text = plane.Cruise;
            txtMode.Text = plane.Mode;
            txtCode.Text = plane.Code;
            txtRoute.Text = plane.Route;
            txtRemarks.Text = plane.Remarks;
        }
    }
}
