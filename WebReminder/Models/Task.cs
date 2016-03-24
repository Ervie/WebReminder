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

        [MaxLength(64), Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [MaxLength(64)]
        public string Place { get; set; }

        public virtual User Owner { get; set; }
    }
}