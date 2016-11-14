using NoteManagerServer;
using NoteManagerServer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NoteManager.ViewModel
{
    class UsersRepository
    {
        private NoteManagerEntities em = new NoteManagerEntities();
        List<NoteManagerServer.User> myList = new List<NoteManagerServer.User>();

        /// <summary>
        /// Return all users 
        /// </summary>
        /// <returns></returns>
        public List<NoteManagerServer.User> GetAll()
        {
            var q = from user in em.Users
                    select user;
            foreach (var user in q)
            {
                myList.Add(TranslateUsersEntityToUser(user));
            }
            return myList;
        }

        /// <summary>
        /// Return user by login
        /// </summary>
        /// <param name="login">specified login</param>
        /// <returns></returns>
        public NoteManagerServer.User GetUser(string login)
        {
            myList = GetAll();
            foreach (NoteManagerServer.User myUser in myList)
                if (myUser.Username.Trim() == login)
                    return myUser;
            return null;
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="Username">username</param>
        /// <param name="Password">plain text password</param>
        /// <param name="Admin">isAdmin boolean</param>
        /// <returns>Created user</returns>
        public User AddUser(string Username, string Password, bool Admin)
        {
            byte[] data = new byte[258];
            byte[] result;

            data = System.Text.Encoding.UTF8.GetBytes(Password);
            Users myUser = new Users();
            myUser.Username = Username;
            myUser.Admin = Admin;

            //Sha1 Encryption password
            SHA1 sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);
            myUser.Password = System.Text.Encoding.UTF8.GetString(result);

            em.Users.Add(myUser);
            this.UpdateDB();
            return TranslateUsersEntityToUser(myUser);
        }

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="CurrentUser">User obj</param>
        public void DeleteUser(int idUser)
        {
            foreach (Notes note in em.Users.Find(idUser).Notes)
                em.Notes.Remove(note);
            em.Users.Remove(em.Users.Find(idUser));
            this.UpdateDB();
        }

        /// <summary>
        /// Check credentials
        /// </summary>
        /// <param name="Username">user's username</param>
        /// <param name="Password">user's password (plain text)</param>
        /// <returns></returns>
        public bool Authenticate(string Username, string Password)
        {
           string strResult = GetHashString(Password);

            var q = from user in em.Users
                    where user.Username == Username &&
                    user.Password == strResult.ToLower()
                    select user;
            if (q.Count() == 0)
                return false;
            return true;
        }

        /// <summary>
        /// Return hash from string
        /// </summary>
        /// <param name="inputString">String to hash</param>
        /// <returns></returns>
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA1.Create();  // SHA1.Create()
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        /// Return sha1 of passed string
        /// </summary>
        /// <param name="inputString">String to hash</param>
        /// <returns></returns>
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
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
        /// EntityFramework User to Webservice User
        /// </summary>
        /// <param name="userEntity">EF User</param>
        /// <returns>WebService User</returns>
        private User TranslateUsersEntityToUser(Users userEntity)
        {
            User user = new User();
            user.Admin = userEntity.Admin;
            user.idUser = userEntity.idUser;
            user.Password = userEntity.Password;
            user.Username = userEntity.Username;
            return user;
        }
    }
}
