using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace BookMyLawyer.Models
{
    public class Lawyer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Earnings { get; set; }
        public string Experience { get; set; }
        public bool IsAvailable { get; set; }
        public virtual ICollection<Client> clients { get; set; }
        public Lawyer()
        {
            clients = new List<Client>();
            IsAvailable = true;
            Earnings = 0;
        }
    }
}