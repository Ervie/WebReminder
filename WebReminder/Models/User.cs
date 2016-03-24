using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebReminder.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required, MaxLength(32)]
        public string Login { get; set; }

        [Required, MaxLength(32)]
        public string Password { get; set; }
        
        [MaxLength(64)]
        public string Email {get; set;}

        [MaxLength(16)]
        public string Phone { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public User()
        {
            Tasks = new List<Task>();
        }
    }
}