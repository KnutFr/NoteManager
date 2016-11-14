using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NoteManagerServer.DB
{
    public class DbManager
    {
        private static DbManager instance;

        private DbManager() { }

        public static DbManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbManager();
                    instance.Ip = "WIN-8T6KQTO70I8\\SQLEXPRESS";
                    instance.DbName = "NoteManager";
                    instance.Login = "sa";
                    instance.Pass = "Admin127";
                }
                return instance;
            }
        }

        public string Ip { get; set; }
        public string DbName { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        private string connexionString;
        public string ConnexionString
        {
            get
            {
                string providerName = "System.Data.SqlClient";
                string serverName = Ip;
                string databaseName = DbName;

                // Initialize the connection string builder for the
                // underlying provider.
                SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

                // Set the properties for the data source.
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.IntegratedSecurity = true;

                // Build the SqlConnection connection string.
                string providerString = sqlBuilder.ToString();

                // Initialize the EntityConnectionStringBuilder.
                EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

                //Set the provider name.
                entityBuilder.Provider = providerName;

                // Set the provider-specific connection string.
                entityBuilder.ProviderConnectionString = providerString;

                // Set the Metadata location.
                entityBuilder.Metadata = @"res://*/DB.db.csdl|res://*/DB.db.ssdl|res://*/DB.db.msl";
                return entityBuilder.ToString();
            }
            set 
            {
                connexionString = value;
            }
        }

        public string ChangeCredentials(string Ip, string DbName, string Login, string Pass)
        {
            instance.Ip = Ip;
            instance.DbName = DbName;
            instance.Login = Login;
            instance.Pass = Pass;
            return instance.ConnexionString;
        }

    }
}