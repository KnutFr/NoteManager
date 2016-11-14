using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteManager.Models
{
    public class Note : INotifyPropertyChanged
    {

        #region Fields & Properties
        
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set 
            { 
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set 
            { 
                content = value;
                OnPropertyChanged("Content");
            }
        }

        private DateTime creationDate;
        public DateTime CreationDate
        {
            get { return creationDate; }
            set
            { 
                creationDate = value;
                OnPropertyChanged("CreationDate");
            }
        }

        private DateTime editionDate;
        public DateTime EditionDate
        {
            get { return editionDate; }
            set 
            { 
                editionDate = value;
                OnPropertyChanged("EditionDate");
            }
        }

        #endregion

        #region Constructors 

        public Note(int id, string title, string content)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.creationDate = DateTime.Now;
            this.editionDate = this.creationDate;
        }

        public Note(int id, string title, string content, DateTime creationDate, DateTime editionDate)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.creationDate = creationDate;
            this.editionDate = editionDate;
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
