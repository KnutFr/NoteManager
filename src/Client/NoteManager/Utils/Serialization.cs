using NoteManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteManager.Utils
{
    public class Serialization
    {
        #region Database methods

        public static void SerializeDatabase(Database obj)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Database));
            using (StreamWriter wr = new StreamWriter("../../Resources/database.xml"))
            {
                xs.Serialize(wr, obj);
            }
        }

        public static Database DeserializeDatabase()
        {
            Database database;

            XmlSerializer xs = new XmlSerializer(typeof(Database));
            using (StreamReader rd = new StreamReader("../../Resources/database.xml"))
            {
                try
                {
                    database = xs.Deserialize(rd) as Database;
                }
                catch (InvalidOperationException)
                {
                    return new Database("", "", "", "");
                }
            }

            return database;
        }

        #endregion

        #region User methods

        public static void SerializeUser(User obj)
        {
            XmlSerializer xs = new XmlSerializer(typeof(User));
            using (StreamWriter wr = new StreamWriter("../../Resources/user.xml"))
            {
                try
                {
                    xs.Serialize(wr, obj);
                }
                catch (InvalidOperationException) { }
            }
        }

        public static User DeserializeUser()
        {
            User user;

            XmlSerializer xs = new XmlSerializer(typeof(User));
            using (StreamReader rd = new StreamReader("../../Resources/user.xml"))
            {
                try
                {
                    user = xs.Deserialize(rd) as User;
                }
                catch (InvalidOperationException)
                {
                    return new User("", "");
                }
            }

            return user;
        }

        #endregion

        #region Web service methods

        public static void SerializeWebService(WebService obj)
        {
            XmlSerializer xs = new XmlSerializer(typeof(WebService));
            using (StreamWriter wr = new StreamWriter("../../Resources/webservice.xml"))
            {
                try
                {
                    xs.Serialize(wr, obj);
                }
                catch (InvalidOperationException) { }
            }
        }

        public static WebService DeserializeWebService()
        {
            WebService webservice;

            XmlSerializer xs = new XmlSerializer(typeof(WebService));
            using (StreamReader rd = new StreamReader("../../Resources/webservice.xml"))
            {
                try
                {
                    webservice = xs.Deserialize(rd) as WebService;
                }
                catch (InvalidOperationException)
                {
                    return new WebService("127.0.0.1", "1234");
                }
            }

            return webservice;
        }

        #endregion
    }
}
