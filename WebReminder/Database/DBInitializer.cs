using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using WebReminder.Models;
//TESTTESTTEST
namespace WebReminder.Database
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<WR_DBContext>
    {
        protected override void Seed(WR_DBContext context)
        {
            User tmpUser = new User()
            {
                Login = "Jan",
                Password = "Kowalski",
                ConfirmPassword = "Kowalski",
                Email = "Jan@wp.pl"
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