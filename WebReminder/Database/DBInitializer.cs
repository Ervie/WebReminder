using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using WebReminder.Models;

namespace WebReminder.Database
{
    public class DBInitializer : DropCreateDatabaseAlways<WR_DBContext>
    {
        protected override void Seed(WR_DBContext context)
        {
            User tmpUser = new User()
            {
                Login = "Jan",
                Password = "Kowalski"
            };

            Task tmpTask = new Task()
            {
                Name = "Stworzyć aplikację",
                DateTime = DateTime.Now
            };

            tmpUser.Tasks.Add(tmpTask);

            context.Tasks.Add(tmpTask);
            context.Users.Add(tmpUser);

            context.SaveChanges();
        }
    }
}