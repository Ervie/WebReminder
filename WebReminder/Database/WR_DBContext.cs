using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using WebReminder.Models;

namespace WebReminder.Database
{
    public class WR_DBContext : DbContext
    {

        public WR_DBContext() : base("WebReminder")
        {
            System.Data.Entity.Database.SetInitializer<WR_DBContext>(new DBInitializer());
        }

        /// <summary>
        /// Creates associations in database.
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }


        // Tables to create in database.
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }

    
}