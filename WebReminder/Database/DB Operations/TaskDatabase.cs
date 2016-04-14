using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebReminder.Models;

namespace WebReminder.Database.DB_Operations
{
    public class TaskDatabase : ContextRepository
    {
        public Task testFoo()
        {
            var query = context.Tasks.FirstOrDefault();

            return query;
        }

        public List<Task> getUsersTasks(int userId)
        {
            return context.Tasks.Where(x => x.Owner.UserID == userId).ToList();
        }
    }

    
}