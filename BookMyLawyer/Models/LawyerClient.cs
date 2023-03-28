using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyLawyer.Models
{
    public class LawyerClient
    {
        public Lawyer lawyer { get; set; }
        public List<Client>clients { get; set; }
        public int LawyerId { get; set; }
        public int ClientId { get; set; }
    }
}