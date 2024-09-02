using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataTier
{
    public class UserManager
    {
        private List<User> connectedUsers = new List<User>();

        public bool IsUsernameUnique(string username)
        {

            

            foreach (User user1 in connectedUsers)
            {
                if (username == user1.Name) { return false; }
            }

           

             return true;
        }

    public void AddUser(string username)
        {
            User user = new User { Name = username};
            connectedUsers.Add(user);
        }

        public void RemoveUser(string username)
        {
            User user = null;
            foreach (User user1 in connectedUsers)
            {
                if (username == user1.Name) { user = user1; }
            }
            connectedUsers.Remove(user);
        }
    }
}
