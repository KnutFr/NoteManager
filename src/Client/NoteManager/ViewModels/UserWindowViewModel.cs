using NoteManager.Helpers;
using NoteManager.Models;
using NoteManager.MyWebService;
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
    class UserWindowViewModel
    {
        #region Fields & Properties

        public Models.User User
        {
            get { return MainWindowViewModel.User; }
            set
            {
                MainWindowViewModel.User = value;
                MainWindowViewModel.OnStaticPropertyChanged("User");
            }
        }

        public string Login
        {
            get { return MainWindowViewModel.User.Login; }
            set
            {
                MainWindowViewModel.User.Login = value;
                MainWindowViewModel.OnStaticPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return MainWindowViewModel.User.Password; }
            set
            {
                MainWindowViewModel.User.Password = value;
                MainWindowViewModel.OnStaticPropertyChanged("Password");
            }
        }

        #endregion

        #region Constructor

        public UserWindowViewModel()
        {
            User = Serialization.DeserializeUser();
        }

        #endregion

        #region Commands

        public ICommand SaveUserConfCommand { get { return new DelegateCommand(OnSaveUserConf); } }

        #endregion

        #region Command handlers

        private void OnSaveUserConf()
        {
            Serialization.SerializeUser(MainWindowViewModel.User);
            MainWindowViewModel.ReloadNotes();
        }

        #endregion
    }
}
