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
    class WebServiceWindowViewModel
    {
        #region Fields & Properties

        public Models.WebService WebService
        {
            get { return MainWindowViewModel.WebService; }
            set
            {
                MainWindowViewModel.WebService = value;
                MainWindowViewModel.OnStaticPropertyChanged("WebService");
            }
        }

        public string Ip
        {
            get { return MainWindowViewModel.WebService.Ip; }
            set
            {
                MainWindowViewModel.WebService.Ip = value;
                MainWindowViewModel.OnStaticPropertyChanged("Ip");
            }
        }

        public string Port
        {
            get { return MainWindowViewModel.WebService.Port; }
            set
            {
                MainWindowViewModel.WebService.Port = value;
                MainWindowViewModel.OnStaticPropertyChanged("Port");
            }
        }

        #endregion

        #region Constructor

        public WebServiceWindowViewModel()
        {
            WebService = Serialization.DeserializeWebService();
        }

        #endregion

        #region Commands

        public ICommand SaveWebServiceConfCommand { get { return new DelegateCommand(OnSaveWebServiceConf); } }

        #endregion

        #region Command handlers

        private void OnSaveWebServiceConf()
        {
            Serialization.SerializeWebService(MainWindowViewModel.WebService);
            if (MainWindowViewModel.SwitchService())
            {
                MainWindowViewModel.IsConnected = true;
                MainWindowViewModel.ReloadNotes();
            }
            else
                MainWindowViewModel.IsConnected = false;
        }

        #endregion
    }
}
