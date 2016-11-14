using NoteManager.ViewModel;
using NoteManagerServer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NoteManagerServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        UsersRepository UsersRepo = new UsersRepository();
        NotesRepository NotesRepo = new NotesRepository();

        public List<Note> GetNotes()
        {
            return NotesRepo.GetAll();
        }

        public List<Note> GetUserNotes(int idUser)
        {
            return NotesRepo.GetUserNote(idUser);
        }

        public bool SetNote(int idNote, int idUser, string note, string title)
        {
            NotesRepo.AddNote(idNote, idUser, title, note);
            return true;
        }

        public bool UpdateNote(int idNote, string title, string content)
        {
            NotesRepo.EditNote(idNote, title, content);
            return true;
        }

        public bool DelNote(int idNote)
        {
            NotesRepo.DeleteNote(idNote);
            return true;
        }

        public Note GetNote(int idNote)
        {
            return NotesRepo.GetNote(idNote);
        }

        public User GetUser(string login, string password)
        {
            if (UsersRepo.Authenticate(login, password) == true)
                return UsersRepo.GetUser(login);
            else
                return null;
        }

        public bool AddUser(string login, string password, bool admin)
        {
            UsersRepo.AddUser(login, password, admin);
            return true;
        }

        public bool DelUser(int idUser)
        {
            UsersRepo.DeleteUser(idUser);
            return true;
        }

        public bool ChangeDb(string ip, string dbname, string login, string pass)
        {
            DbManager.Instance.ChangeCredentials(ip, dbname, login, pass);
            return true;
        }

        public int GetMaxId()
        {
            return NotesRepo.GetMaxId(); 
        }

    }
}
