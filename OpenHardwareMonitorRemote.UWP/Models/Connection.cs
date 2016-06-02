using System.ComponentModel;
using System.Runtime.CompilerServices;
using OpenHardwareMonitorRemote.UWP.Annotations;

namespace OpenHardwareMonitorRemote.UWP.Models
{
    public class Connection : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;
        
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

        public Connection Clone()
        {
            return new Connection
            {
                Title = Title,
                Ip = Ip,
                Port = Port
            };
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
