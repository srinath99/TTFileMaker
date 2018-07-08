using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TTFileMaker.Models
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
        private string _location;
        private string _altitude;
        private string _speed;
        private string _heading;

        public string Callsign
        {
            get { return _callsign; }
            set
            {
                _callsign = value;
                OnPropertyChanged("Callsign");
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Engine
        {
            get { return _engine; }
            set
            {
                _engine = value;
                OnPropertyChanged("Engine");

            }
        }

        public string Rules
        {
            get { return _rules; }
            set
            {
                _rules = value;
                OnPropertyChanged("Rules");
            }
        }

        public string Dep
        {
            get { return _dep; }
            set
            {
                _dep = value;
                OnPropertyChanged("Dep");
            }
        }

        public string Arr
        {
            get { return _arr; }
            set
            {
                _arr = value;
                OnPropertyChanged("Arr");
            }
        }

        public string Cruise
        {
            get { return _cruise; }
            set
            {
                _cruise = value;
                OnPropertyChanged("Cruise");

            }
        }

        public string Route
        {
            get { return _route; }
            set
            {
                _route = value;
                OnPropertyChanged("Route");

            }
        }

        public string Remarks
        {
            get { return _remarks; }
            set
            {
                _remarks = value;
                OnPropertyChanged("Remarks");
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        public string Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                OnPropertyChanged("Mode");
            }
        }

        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        public string Altitude
        {
            get { return _altitude; }
            set
            {
                _altitude = value;
                OnPropertyChanged("Altitude");
            }
        }

        public string Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public string Heading
        {
            get { return _heading; }
            set
            {
                _heading = value;
                OnPropertyChanged("Heading");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Aircraft(string Callsign)
        {
            this.Callsign = Callsign;
        }

        public Aircraft()
        {

        }

        public void Clear()
        {
            Callsign = "";
            Type = "";
            Engine = "";
            Rules = "";
            Dep = "";
            Arr = "";
            Cruise = "";
            Route = "";
            Remarks = "";
            Code = "";
            Mode = "";
            Location = "";
            Altitude = "";
            Speed = "";
            Heading = "";
        }
    }
}
