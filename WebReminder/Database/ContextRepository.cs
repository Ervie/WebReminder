using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebReminder.Exceptions;

namespace WebReminder.Database
{
    abstract public class ContextRepository: IDisposable
    {
        protected WR_DBContext context = new WR_DBContext();

        private bool alreadyReconnected;

        protected void Initialize()
        {
            context.Database.Initialize(false);
            alreadyReconnected = false;
        }

        protected void SaveChanges()
        {
            if (context != null)
                context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }

        /// <summary>
        /// Method that try connectiong to database. Can retry if user is willing to.
        /// </summary>
        public void connectToDB()
        {
            try
            {
                context.Database.Initialize(false);
            }

            catch (System.Data.SqlClient.SqlException)
            {
                if (alreadyReconnected)
                    throw new DBConnectionException();
                else
                {
                    alreadyReconnected = true;
                    connectToDB();
                }
            }

        }
    }
}