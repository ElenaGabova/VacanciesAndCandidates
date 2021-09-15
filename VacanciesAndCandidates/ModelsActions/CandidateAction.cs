using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacanciesAndCandidates.DatabaseSettings.CandidateContext;
using VacanciesAndCandidates.Models.CandidateModel;

namespace VacanciesAndCandidates.ModelsActions.CandidateAction
{
    static class CandidateAction
    {
        public static void AddCandidate(string[] sqlParameters,
                                        bool gender,
                                        out bool inputCorrect,
                                        out string resultText)
        {

            var inputCorrectParam = new SqlParameter
            {
                ParameterName = "inputCorrect",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var resultTextParam = new SqlParameter
            {
                ParameterName = "resultText",
                DbType = System.Data.DbType.String,
                Size = 250,
                Direction = System.Data.ParameterDirection.Output
            };

            using (CandidateContext db = new CandidateContext())
            {
                string addCandidateQuery = string.Format(
                    @"EXECUTE [dbo].[AddCandidate] 
                       '{0}',
                       '{1}',
                       @inputCorrect OUTPUT,
                       @resultText OUTPUT", String.Join("',\n'", sqlParameters), gender);

                var addCandidateQueryResult = db.Database.ExecuteSqlCommand(addCandidateQuery, inputCorrectParam, resultTextParam);
                db.SaveChanges();

                inputCorrect = (bool)inputCorrectParam.Value;
                resultText = resultTextParam.Value.ToString();
            }
        }

        public static ObservableCollection<CandidateModel> GetCandidate()
        {
            var candidateList = new ObservableCollection<CandidateModel>();

            using (CandidateContext db = new CandidateContext())
            {
                foreach (var item in db.Candidates.ToList()) 
                    candidateList.Add(item);
            }

            return candidateList;
        }
    }
}
