using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebReminder.Models;

namespace WebReminder.Database.DB_Operations
{
    public class UserDatabase : ContextRepository
    {

        public void RegisterUser(User user)
        {
            context.Users.Add(user);
            SaveChanges();
        }

        public User LogInUser(User user)
        {
            return context.Users.Where(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefault();        
        }

        public bool CheckIfUserExistByLogin(string userName)
        {
            return !context.Users.Any(x => x.Login == userName);
        }
    }
}