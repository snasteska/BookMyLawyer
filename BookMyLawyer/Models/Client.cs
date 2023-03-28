using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMyLawyer.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Crime { get; set; }
        public virtual ICollection<Lawyer> lawyers { get; set; }
        public Client()
        {
            lawyers = new List<Lawyer>();
        }
    }
}
