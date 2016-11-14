using NoteManager.Helpers;
using NoteManager.Models;
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
    class SearchWindowViewModel
    {
        #region Fields & Properties

        private ObservableCollection<Note> notes;

        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public Note SelectedNote
        {
            get { return MainWindowViewModel.SelectedNote; }
            set
            {
                MainWindowViewModel.SelectedNote = value;
                MainWindowViewModel.OnStaticPropertyChanged("SelectedNote");
            }
        }

        #endregion

        #region Constructor

        public SearchWindowViewModel()
        {
            notes = new ObservableCollection<Note>(MainWindowViewModel.Notes);
        }

        #endregion
    }
}
