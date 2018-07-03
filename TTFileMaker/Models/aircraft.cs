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
}
