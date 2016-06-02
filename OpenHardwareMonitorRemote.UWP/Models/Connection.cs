using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using OpenHardwareMonitorRemote.UWP.Annotations;

namespace OpenHardwareMonitorRemote.UWP.Models
{
    public class Connection : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;

        [DataMember]
        public string Title
        {
            get { return _title; }
            set
            {
                if (Title == value) return;

                _title = value;
                OnPropertyChanged();
            }
        }

        private string _ip;

        [DataMember]
        public string Ip
        {
            get { return _ip; }
            set
            {
                if (Ip == value) return;

                _ip = value;
                OnPropertyChanged();
            }
        }

        private ushort _port;

        [DataMember]
        public ushort Port
        {
            get { return _port; }
            set
            {
                if (Port == value) return;

                _port = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
