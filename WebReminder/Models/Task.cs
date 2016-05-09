using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebReminder.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "You must name your new task")]
        [MaxLength(64, ErrorMessage = "Task name must include from 1 to 64 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime DateTime { get; set; }

        [MaxLength(256, ErrorMessage = "Max length of description is 256 characters")]
        public string Description { get; set; }

        [MaxLength(64, ErrorMessage = "Max length of description is 64 characters")]
        public string Place { get; set; }

        public virtual User Owner { get; set; }
    }
}