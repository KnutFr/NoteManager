﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NoteManager.MyWebService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Note", Namespace="http://schemas.datacontract.org/2004/07/NoteManagerServer")]
    [System.SerializableAttribute()]
    public partial class Note : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> LastUpdateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idNoteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Creation {
            get {
                return this.CreationField;
            }
            set {
                if ((this.CreationField.Equals(value) != true)) {
                    this.CreationField = value;
                    this.RaisePropertyChanged("Creation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> LastUpdate {
            get {
                return this.LastUpdateField;
            }
            set {
                if ((this.LastUpdateField.Equals(value) != true)) {
                    this.LastUpdateField = value;
                    this.RaisePropertyChanged("LastUpdate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idNote {
            get {
                return this.idNoteField;
            }
            set {
                if ((this.idNoteField.Equals(value) != true)) {
                    this.idNoteField = value;
                    this.RaisePropertyChanged("idNote");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/NoteManagerServer")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> AdminField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idUserField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> Admin {
            get {
                return this.AdminField;
            }
            set {
                if ((this.AdminField.Equals(value) != true)) {
                    this.AdminField = value;
                    this.RaisePropertyChanged("Admin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idUser {
            get {
                return this.idUserField;
            }
            set {
                if ((this.idUserField.Equals(value) != true)) {
                    this.idUserField = value;
                    this.RaisePropertyChanged("idUser");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyWebService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetNotes", ReplyAction="http://tempuri.org/IService1/GetNotesResponse")]
        NoteManager.MyWebService.Note[] GetNotes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetNotes", ReplyAction="http://tempuri.org/IService1/GetNotesResponse")]
        System.Threading.Tasks.Task<NoteManager.MyWebService.Note[]> GetNotesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserNotes", ReplyAction="http://tempuri.org/IService1/GetUserNotesResponse")]
        NoteManager.MyWebService.Note[] GetUserNotes(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserNotes", ReplyAction="http://tempuri.org/IService1/GetUserNotesResponse")]
        System.Threading.Tasks.Task<NoteManager.MyWebService.Note[]> GetUserNotesAsync(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetNote", ReplyAction="http://tempuri.org/IService1/SetNoteResponse")]
        bool SetNote(int idNote, int idUser, string note, string title);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetNote", ReplyAction="http://tempuri.org/IService1/SetNoteResponse")]
        System.Threading.Tasks.Task<bool> SetNoteAsync(int idNote, int idUser, string note, string title);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateNote", ReplyAction="http://tempuri.org/IService1/UpdateNoteResponse")]
        bool UpdateNote(int idNote, string title, string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateNote", ReplyAction="http://tempuri.org/IService1/UpdateNoteResponse")]
        System.Threading.Tasks.Task<bool> UpdateNoteAsync(int idNote, string title, string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DelNote", ReplyAction="http://tempuri.org/IService1/DelNoteResponse")]
        bool DelNote(int idNote);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DelNote", ReplyAction="http://tempuri.org/IService1/DelNoteResponse")]
        System.Threading.Tasks.Task<bool> DelNoteAsync(int idNote);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMaxId", ReplyAction="http://tempuri.org/IService1/GetMaxIdResponse")]
        int GetMaxId();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMaxId", ReplyAction="http://tempuri.org/IService1/GetMaxIdResponse")]
        System.Threading.Tasks.Task<int> GetMaxIdAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetNote", ReplyAction="http://tempuri.org/IService1/GetNoteResponse")]
        NoteManager.MyWebService.Note GetNote(int idNote);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetNote", ReplyAction="http://tempuri.org/IService1/GetNoteResponse")]
        System.Threading.Tasks.Task<NoteManager.MyWebService.Note> GetNoteAsync(int idNote);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        NoteManager.MyWebService.User GetUser(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        System.Threading.Tasks.Task<NoteManager.MyWebService.User> GetUserAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddUser", ReplyAction="http://tempuri.org/IService1/AddUserResponse")]
        bool AddUser(string login, string password, bool admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddUser", ReplyAction="http://tempuri.org/IService1/AddUserResponse")]
        System.Threading.Tasks.Task<bool> AddUserAsync(string login, string password, bool admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DelUser", ReplyAction="http://tempuri.org/IService1/DelUserResponse")]
        bool DelUser(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DelUser", ReplyAction="http://tempuri.org/IService1/DelUserResponse")]
        System.Threading.Tasks.Task<bool> DelUserAsync(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ChangeDb", ReplyAction="http://tempuri.org/IService1/ChangeDbResponse")]
        bool ChangeDb(string ip, string dbname, string login, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ChangeDb", ReplyAction="http://tempuri.org/IService1/ChangeDbResponse")]
        System.Threading.Tasks.Task<bool> ChangeDbAsync(string ip, string dbname, string login, string pass);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : NoteManager.MyWebService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<NoteManager.MyWebService.IService1>, NoteManager.MyWebService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public NoteManager.MyWebService.Note[] GetNotes() {
            return base.Channel.GetNotes();
        }
        
        public System.Threading.Tasks.Task<NoteManager.MyWebService.Note[]> GetNotesAsync() {
            return base.Channel.GetNotesAsync();
        }
        
        public NoteManager.MyWebService.Note[] GetUserNotes(int idUser) {
            return base.Channel.GetUserNotes(idUser);
        }
        
        public System.Threading.Tasks.Task<NoteManager.MyWebService.Note[]> GetUserNotesAsync(int idUser) {
            return base.Channel.GetUserNotesAsync(idUser);
        }
        
        public bool SetNote(int idNote, int idUser, string note, string title) {
            return base.Channel.SetNote(idNote, idUser, note, title);
        }
        
        public System.Threading.Tasks.Task<bool> SetNoteAsync(int idNote, int idUser, string note, string title) {
            return base.Channel.SetNoteAsync(idNote, idUser, note, title);
        }
        
        public bool UpdateNote(int idNote, string title, string content) {
            return base.Channel.UpdateNote(idNote, title, content);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateNoteAsync(int idNote, string title, string content) {
            return base.Channel.UpdateNoteAsync(idNote, title, content);
        }
        
        public bool DelNote(int idNote) {
            return base.Channel.DelNote(idNote);
        }
        
        public System.Threading.Tasks.Task<bool> DelNoteAsync(int idNote) {
            return base.Channel.DelNoteAsync(idNote);
        }
        
        public int GetMaxId() {
            return base.Channel.GetMaxId();
        }
        
        public System.Threading.Tasks.Task<int> GetMaxIdAsync() {
            return base.Channel.GetMaxIdAsync();
        }
        
        public NoteManager.MyWebService.Note GetNote(int idNote) {
            return base.Channel.GetNote(idNote);
        }
        
        public System.Threading.Tasks.Task<NoteManager.MyWebService.Note> GetNoteAsync(int idNote) {
            return base.Channel.GetNoteAsync(idNote);
        }
        
        public NoteManager.MyWebService.User GetUser(string login, string password) {
            return base.Channel.GetUser(login, password);
        }
        
        public System.Threading.Tasks.Task<NoteManager.MyWebService.User> GetUserAsync(string login, string password) {
            return base.Channel.GetUserAsync(login, password);
        }
        
        public bool AddUser(string login, string password, bool admin) {
            return base.Channel.AddUser(login, password, admin);
        }
        
        public System.Threading.Tasks.Task<bool> AddUserAsync(string login, string password, bool admin) {
            return base.Channel.AddUserAsync(login, password, admin);
        }
        
        public bool DelUser(int idUser) {
            return base.Channel.DelUser(idUser);
        }
        
        public System.Threading.Tasks.Task<bool> DelUserAsync(int idUser) {
            return base.Channel.DelUserAsync(idUser);
        }
        
        public bool ChangeDb(string ip, string dbname, string login, string pass) {
            return base.Channel.ChangeDb(ip, dbname, login, pass);
        }
        
        public System.Threading.Tasks.Task<bool> ChangeDbAsync(string ip, string dbname, string login, string pass) {
            return base.Channel.ChangeDbAsync(ip, dbname, login, pass);
        }
    }
}
