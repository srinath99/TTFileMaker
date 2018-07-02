using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TTFileMaker
{
    public class Aircraft : INotifyPropertyChanged
    {
        private string _callsign;
        private string _type;
        private string _engine;
        private string _rules;
        private string _dep;
        private string _arr;
        private string _cruise;
        private string _route;
        private string _remarks;
        private string _code;
        private string _mode;
        private string _latitude;
        private string _longitude;
        private string _altitude;
        private string _speed;
        private string _heading;

        public string Callsign
        {
            get { return _callsign; }
            set
            {
                _callsign = value;
                OnPropertyChanged(nameof(Callsign));
                
            }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Engine
        {
            get { return _engine; }
            set { _engine = value; }
        }

        public string Rules
        {
            get { return _rules; }
            set { _rules = value; }
        }

        public string Dep
        {
            get { return _dep; }
            set { _dep = value; }
        }

        public string Arr
        {
            get { return _arr; }
            set { _arr = value; }
        }

        public string Cruise
        {
            get { return _cruise; }
            set { _cruise = value; }
        }

        public string Route
        {
            get { return _route; }
            set { _route = value; }
        }

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public string Altitude
        {
            get { return _altitude; }
            set { _altitude = value; }
        }

        public string Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public string Heading
        {
            get { return _heading; }
            set { _heading = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class ViewModel
    {
        public ObservableCollection<Aircraft> Scenario = new ObservableCollection<Aircraft>();
        private int _currentAircraft = 0;

        private void generateScenario(string file)
        {
            
            string[] splitter = new string[] { "\r\n" };
            string[] planes = file.Split(splitter, StringSplitOptions.None);

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

        public ViewModel(string file)
        {
            generateScenario(file);
        }

        public Aircraft Current
        {
            get { return this.Scenario.Count > 0 ? this.Scenario[_currentAircraft] : null; }
        }

        public int Index
        {
            set { _currentAircraft = value; }
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
