using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BookMyLawyer.Models
{
    public class LawyerContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public LawyerContext() : base("DefaultConnection"){}
        public static LawyerContext Create()
        {
            return new LawyerContext();
        }
    }
}