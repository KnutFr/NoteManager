using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteManager.Models
{
    public class WebService : INotifyPropertyChanged
    {
        #region Fields & Properties

        private string ip;
        public string Ip
        {
            get { return ip; }
            set
            {
                ip = value;
                OnPropertyChanged("Ip");
            }
        }

        private string port;
        public string Port
        {
            get { return port; }
            set
            {
                port = value;
                OnPropertyChanged("Port");
            }
        }

        #endregion

        #region Constructors

        public WebService()
        {
        }

        public WebService(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
        }

        #endregion

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
