using NoteManager.Helpers;
using NoteManager.Models;
using NoteManager.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteManager.ViewModels
{
    class DatabaseWindowViewModel
    {
        #region Fields & Properties

        public Database Database
        {
            get { return MainWindowViewModel.Database; }
            set
            {
                MainWindowViewModel.Database = value;
                MainWindowViewModel.OnStaticPropertyChanged("Database");
            }
        }

        public string Ip
        {
            get { return MainWindowViewModel.Database.Ip; }
            set
            {
                MainWindowViewModel.Database.Ip = value;
                MainWindowViewModel.OnStaticPropertyChanged("Ip");
            }
        }

        public string Name
        {
            get { return MainWindowViewModel.Database.Name; }
            set
            {
                MainWindowViewModel.Database.Name = value;
                MainWindowViewModel.OnStaticPropertyChanged("Name");
            }
        }

        public string Login
        {
            get { return MainWindowViewModel.Database.Login; }
            set
            {
                MainWindowViewModel.Database.Login = value;
                MainWindowViewModel.OnStaticPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return MainWindowViewModel.Database.Password; }
            set
            {
                MainWindowViewModel.Database.Password = value;
                MainWindowViewModel.OnStaticPropertyChanged("Password");
            }
        }

        #endregion

        #region Constructor

        public DatabaseWindowViewModel()
        {
            Database = Serialization.DeserializeDatabase();
        }

        #endregion

        #region Commands

        public ICommand SaveDatabaseConfCommand { get { return new DelegateCommand(OnSaveDatabaseConf); } }

        #endregion

        #region Command handlers

        private void OnSaveDatabaseConf()
        {
            Serialization.SerializeDatabase(MainWindowViewModel.Database);
        }

        #endregion
    }
}
