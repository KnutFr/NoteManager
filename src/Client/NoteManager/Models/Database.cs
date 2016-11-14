using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteManager.Models
{
    public class Database : INotifyPropertyChanged
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

        private string name;
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        #endregion

        #region Constructors

        public Database()
        {
        }

        public Database(string ip, string name, string login, string password)
        {
            this.ip = ip;
            this.name = name;
            this.login = login;
            this.password = password;
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
