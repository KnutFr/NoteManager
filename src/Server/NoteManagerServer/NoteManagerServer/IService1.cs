using NoteManagerServer.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NoteManagerServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Note> GetNotes();

        [OperationContract]
        List<Note> GetUserNotes(int idUser);

        [OperationContract]
        bool SetNote(int idNote, int idUser, string note, string title);

        [OperationContract]
        bool UpdateNote(int idNote, string title, string content);

        [OperationContract]
        bool DelNote(int idNote);

        [OperationContract]
        int GetMaxId();

        [OperationContract]
        Note GetNote(int idNote);

        [OperationContract]
        User GetUser(string login, string password);

        [OperationContract]
        bool AddUser(string login, string password, bool admin);

        [OperationContract]
        bool DelUser(int idUser);

        [OperationContract]
        bool ChangeDb(string ip, string dbname, string login, string pass);

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]

    public class User
    {
        [DataMember]
        public int idUser { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public Nullable<bool> Admin { get; set; }
    }
    [DataContract]

    public class Note
    {
        [DataMember, Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idNote { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public System.DateTime Creation { get; set; }
        [DataMember]
        public Nullable<System.DateTime> LastUpdate { get; set; }
        [DataMember]
        public int UserId { get; set; }
    }
}
