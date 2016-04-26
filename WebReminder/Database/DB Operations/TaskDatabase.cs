using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebReminder.Models;

namespace WebReminder.Database.DB_Operations
{
    public class TaskDatabase : ContextRepository
    {
        public Task GetTaskById(int id)
        {
            var returnedTask= context.Tasks.FirstOrDefault(x => x.TaskID == id);

            return returnedTask;
        }

        public List<Task> GetUsersTasks(int userId)
        {
            return context.Tasks.Where(x => x.Owner.UserID == userId).ToList();
        }

        public void AddTaskToDatabase(Task newTask, int ownerId)
        {
            var taskOwner = context.Users.FirstOrDefault(x => x.UserID == ownerId);

            if (taskOwner != null)
            {
                newTask.Owner = taskOwner;

                context.Tasks.Add(newTask);
                SaveChanges();
            }

        }

        public void RemoveTaskById(int id)
        {
            context.Tasks.Remove(GetTaskById(id));
            SaveChanges();
        }

        public void ReplaceProperties(Task taskWithNewProperties)
        {
            var selectedTask = GetTaskById(taskWithNewProperties.TaskID);

            if (selectedTask != null)
            {
                selectedTask.DateTime = taskWithNewProperties.DateTime;
                selectedTask.Place = taskWithNewProperties.Place;
                selectedTask.Name = taskWithNewProperties.Name;
                selectedTask.Description = taskWithNewProperties.Description;

                SaveChanges();
            }
        }
    }

    
}