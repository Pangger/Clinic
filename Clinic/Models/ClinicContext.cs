using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clinic.Models
{
    public class ClinicContext : DbContext
    {
        public ClinicContext() : base("ClinicContext") { }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Blood> BloodTests { get; set; }
    }
}