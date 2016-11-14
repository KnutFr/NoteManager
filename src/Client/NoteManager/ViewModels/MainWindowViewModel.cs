using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NoteManager.Helpers;
using NoteManager.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using NoteManager.Utils;
using NoteManager.MyWebService;
using System.ServiceModel;
using System.Net;

namespace NoteManager.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields & Properties

        private static ObservableCollection<Models.Note> notes;

        public static ObservableCollection<Models.Note> Notes
        {
            get { return notes; }
            set 
            { 
                notes = value;
                OnStaticPropertyChanged("Notes");
            }
        }

        private static Models.Note selectedNote;

        public static Models.Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value;
                OnStaticPropertyChanged("SelectedNote");
            }
        }

        private static Database database;

        public static Database Database
        {
            get { return database; }
            set
            {
                database = value;
                OnStaticPropertyChanged("Database");
            }
        }

        private static Models.User user;

        public static Models.User User
        {
            get { return user; }
            set
            {
                user = value;
                OnStaticPropertyChanged("User");
            }
        }

        private static Models.WebService webService;

        public static Models.WebService WebService
        {
            get { return webService; }
            set
            {
                webService = value;
                OnStaticPropertyChanged("WebService");
            }
        }

        public static bool IsConnected = false;

        private static Service1Client webServiceClient = new Service1Client();

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            notes = new ObservableCollection<Models.Note>();
            database = Serialization.DeserializeDatabase();
            user = Serialization.DeserializeUser();
            webService = Serialization.DeserializeWebService();

            if (SwitchService())
            {
                IsConnected = true;
                ReloadNotes();
            }
            else
                IsConnected = false;
        }
        #endregion

        #region Commands

        public ICommand AddItemCommand { get { return new DelegateCommand(OnAddItem); } }

        public ICommand DeleteItemCommand { get { return new DelegateCommand(OnDeleteItem); } }

        public ICommand LoadItemsCommand { get { return new DelegateCommand(ReloadNotes); } }

        public ICommand UpdateNoteCommand { get { return new DelegateCommand(OnUpdateNote); } }

        #endregion

        #region Command handlers

        private void OnAddItem()
        {
            if (!IsConnected)
                return;

            try
            {
                MyWebService.User myUser = webServiceClient.GetUser(user.Login, user.Password);
                Models.Note note = new Models.Note(webServiceClient.GetMaxId() + 1, "Title", "");
                webServiceClient.SetNote(webServiceClient.GetMaxId() + 1, myUser.idUser, "Title", "");
                notes.Add(note);
                selectedNote = notes[notes.IndexOf(note)];
            }
            catch (System.ServiceModel.EndpointNotFoundException e)
            {
                MessageBox.Show("Impossible de se connecter au serveur distant. Veuillez reconfigurer les informations du web service !",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnDeleteItem()
        {
            if (!IsConnected)
                return;

            if (selectedNote != null)
            {
                webServiceClient.DelNote(selectedNote.Id);
                notes.Remove(selectedNote);
            }
        }


        private void OnUpdateNote()
        {
            if (!IsConnected)
                return;

            if (selectedNote != null)
            {
                selectedNote.EditionDate = DateTime.Now;
                webServiceClient.UpdateNote(selectedNote.Id, selectedNote.Title.Trim(), selectedNote.Content.Trim());
            }
        }

        public static void ReloadNotes()
        {
            if (!IsConnected)
                return;

            try
            {
                notes.Clear();
                MyWebService.User myUser = webServiceClient.GetUser(user.Login, user.Password);

                if (myUser != null)
                {
                    if (myUser.Admin == true)
                    {
                        foreach (MyWebService.Note note in webServiceClient.GetNotes())
                        {
                            notes.Add(new Models.Note(note.idNote, note.Title, note.Content, note.Creation, (DateTime)note.LastUpdate));
                        }
                    }
                    else
                    {
                        foreach (MyWebService.Note note in webServiceClient.GetUserNotes(myUser.idUser))
                        {
                            notes.Add(new Models.Note(note.idNote, note.Title, note.Content, note.Creation, (DateTime)note.LastUpdate));
                        }
                    }
                }
                else
                    MessageBox.Show("Veuillez vous identifier pour accéder à vos notes.", "Veuillez vous identifier",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.ServiceModel.EndpointNotFoundException e)
            {
                MessageBox.Show("Impossible de se connecter au serveur distant. Veuillez reconfigurer les informations du web service !",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
     
        }
        public static bool SwitchService()
        {
            string myNewServiceUrl = "http://" + webService.Ip + ":" + webService.Port + "/Service1.svc";
            if (IsAddressAvailable(myNewServiceUrl))
            {
                if(webServiceClient.State == System.ServiceModel.CommunicationState.Opened)   
                    webServiceClient.Close();

                var myBinding = new BasicHttpBinding();
                myBinding.Security.Mode = BasicHttpSecurityMode.None;
                var myEndpointAddress = new EndpointAddress(myNewServiceUrl);
                webServiceClient = new Service1Client(myBinding, myEndpointAddress);
                
                return true;
            }
            return false;
        }

        public static bool IsAddressAvailable(string address)
        {
                System.Net.WebClient client = new WebClient();
                try
                {
                    client.DownloadData(address);
                }
                catch (System.Net.WebException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                } 
            
            return true;
        }
        #endregion

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public static event PropertyChangedEventHandler StaticPropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static void OnStaticPropertyChanged(string propertyName)
        {
            if (StaticPropertyChanged != null)
                StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}