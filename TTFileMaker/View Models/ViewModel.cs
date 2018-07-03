using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTFileMaker.Models;

namespace TTFileMaker.View_Models
{
    class ViewModel
    {
        public ObservableCollection<Aircraft> Scenario = new ObservableCollection<Aircraft>();
        private async void generateScenario(Windows.Storage.StorageFile file)
        {
            string raw = await Read(file);

            string[] splitter = new string[] { "\r\n" };
            string[] planes = raw.Split(splitter, StringSplitOptions.None);

            for (int i = 0; i < planes.Length; ++i)
            {
                string[] data = planes[i].Split(':');

                if (data[0] != "")
                {
                    Aircraft plane = new Aircraft
                    {
                        Callsign = data[0],
                        Type = data[1],
                        Engine = data[2],
                        Rules = data[3],
                        Dep = data[4],
                        Arr = data[5],
                        Cruise = data[6],
                        Route = data[7],
                        Remarks = data[8],
                        Code = data[9],
                        Mode = data[10],
                        Latitude = data[11],
                        Longitude = data[12],
                        Altitude = data[13],
                        Speed = data[14],
                        Heading = data[15]
                    };
                    

                    Scenario.Add(plane);
                }
            }
        }

        public ViewModel()
        {

        }

        public ViewModel(Windows.Storage.StorageFile file)
        {
            generateScenario(file);      
        }

        private Aircraft _selectedItem;
        public Aircraft SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
            }
        }

        private string WriteLine(Aircraft plane)
        {
            string line = string.Empty;

            line += plane.Callsign + ":";
            line += plane.Type + ":";
            line += plane.Engine + ":";
            line += plane.Rules + ":";
            line += plane.Dep + ":";
            line += plane.Arr + ":";
            line += plane.Cruise + ":";
            line += plane.Route + ":";
            line += plane.Remarks + ":";
            line += plane.Code + ":";
            line += plane.Mode + ":";
            line += plane.Latitude + ":";
            line += plane.Longitude + ":";
            line += plane.Altitude + ":";
            line += plane.Speed + ":";
            line += plane.Heading + "\r\n";

            return line;
        }

        public async Task<string> Read(Windows.Storage.StorageFile file)
        {
            string rawFile = await Windows.Storage.FileIO.ReadTextAsync(file);

            return rawFile;
        }

        public async Task<int> Write(Windows.Storage.StorageFile file)
        {
            string content = string.Empty;

            foreach (Aircraft plane in Scenario)
            {
                content += WriteLine(plane);
            }

            if (file != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // write to file
                await Windows.Storage.FileIO.WriteTextAsync(file, content);
                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
        }
    }
}
