using NoteManagerServer;
using NoteManagerServer.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteManager.ViewModel
{
    class NotesRepository
    {
        private NoteManagerEntities em = new NoteManagerEntities();
        List<Note> myList = new List<Note>();

        /// <summary>
        /// Return all users notes
        /// </summary>
        /// <returns>List of all users notes</returns>
        public List<Note> GetAll()
        {
            var q = (from note in em.Notes
                     select note);
            foreach (var note in q)
            {
                myList.Add(this.TranslateNotesEntityToNote(note));
            }

            return myList;
        }

        /// <summary>
        /// Return specific users note
        /// </summary>
        /// <param name="CurrentUser">User object</param>
        /// <returns>Specific user note</returns>
        public List<Note> GetUserNote(int idUser)
        {
            Users currentUser = em.Users.Find(idUser);
            if (currentUser != null)
            {
                var q = from note in em.Notes
                        where note.Users.idUser == currentUser.idUser
                        select note;
                foreach (var note in q)
                {
                    myList.Add(this.TranslateNotesEntityToNote(note));
                }
            }
            else
                throw new Exception("Invalid user ID");
            return myList;
        }

        public Note GetNote(int idNote)
        {
            return this.TranslateNotesEntityToNote(em.Notes.Find(idNote));
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="idNote">Note ID</param>
        /// <param name="CurrentUser">Current user</param>
        /// <param name="Title">note's title</param>
        /// <param name="Content">note's content</param>
        /// <returns>Return created note</returns>
        public Notes AddNote(int idNote, int idUser, string Title, string Content)
        {
            Notes myNote = new Notes();
            Users CurrentUser = em.Users.Find(idUser);
            myNote.Title = Title;
            myNote.Content = Content;
            myNote.Users = CurrentUser;
            myNote.Creation = DateTime.Now;
            myNote.idNote = idNote;
            em.Notes.Add(myNote);
            UpdateDB();
            return myNote;
        }

        /// <summary>
        /// Update note
        /// </summary>
        /// <param name="idNote">note id</param>
        /// <param name="Title">new title</param>
        /// <param name="Content">new content</param>
        /// <returns>Edited note</returns>
        public Notes EditNote(int idNote, string Title, string Content)
        {
            Notes CurrentNote = em.Notes.Find(idNote);
            if (CurrentNote != null)
            {
                CurrentNote.Title = Title;
                CurrentNote.Content = Content;
                CurrentNote.LastUpdate = DateTime.Now;
                UpdateDB();
            }
            return CurrentNote;
        }

        /// <summary>
        /// Delete a note
        /// </summary>
        /// <param name="idNote">note id</param>
        public void DeleteNote(int idNote)
        {
            em.Notes.Remove(em.Notes.Find(idNote));
            this.UpdateDB();
        }

        /// <summary>
        /// Return max note ID
        /// </summary>
        /// <returns>Int max note id</returns>
         public int GetMaxId()
         {
             if (em.Notes.OrderByDescending(n => n.idNote).FirstOrDefault() != null)
                 return em.Notes.OrderByDescending(n => n.idNote).FirstOrDefault().idNote;
             else
                 return 0;
         }

        /// <summary>
        /// Update database
        /// </summary>
        private void UpdateDB()
        {
            try
            {
                em.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// EF Note to WebService Note
        /// </summary>
        /// <param name="noteEntity">EF Note</param>
        /// <returns>WebService Note</returns>
         private Note TranslateNotesEntityToNote( Notes noteEntity)
       {
             Note note = new Note();
             note.Content = noteEntity.Content;
             note.Creation = noteEntity.Creation;
             note.Title = noteEntity.Title;
             note.UserId = noteEntity.UserId;
             if (noteEntity.LastUpdate != null)
                note.LastUpdate = noteEntity.LastUpdate;
             else
                 note.LastUpdate = DateTime.Now;
             note.idNote = noteEntity.idNote;
             return note;
       }

    }
}
