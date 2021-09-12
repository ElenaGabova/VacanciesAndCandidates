using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VacanciesAndCandidates.Models.VacansyModel;

namespace VacanciesAndCandidates.DatabaseSettings.VacansyContext
{
    public class VacansyContext : DbContext
    {
        public VacansyContext()
         : base("DbConnection")
        { }

        public DbSet<VacansyModel> Vacansies { get; set; }
    }
}
