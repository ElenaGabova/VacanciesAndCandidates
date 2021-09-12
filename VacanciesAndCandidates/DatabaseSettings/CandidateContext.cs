using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VacanciesAndCandidates.Models.CandidateModel;

namespace VacanciesAndCandidates.DatabaseSettings.CandidateContext
{
    public class CandidateContext : DbContext
    {
        public CandidateContext()
         : base("DbConnection")
        { }

        public DbSet<CandidateModel> Candidates { get; set;} 

    }
}
