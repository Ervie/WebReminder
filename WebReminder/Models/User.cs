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

        [Required(ErrorMessage="Login in required")]
        [MaxLength(32, ErrorMessage="You can only add up to 32 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password in required")]
        [MaxLength(32, ErrorMessage="You can only add up to 32 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password in required")]
        [Compare("Password", ErrorMessage="Please confirm your password")]
        [MaxLength(32, ErrorMessage="You can only add up to 32 characters")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email in required")]
        [MaxLength(64, ErrorMessage="You can only add up to 64 characters")]
        [EmailAddress(ErrorMessage="We don't recognize it as valid email address")]
        public string Email {get; set;}

        [MaxLength(16, ErrorMessage="You can only add up to 16 characters")]
        [Phone(ErrorMessage="We do not recognize it as phone number")]
        public string Phone { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public User()
        {
            Tasks = new List<Task>();
        }
    }
}