using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VacanciesAndCandidates.DatabaseSettings.CandidateContext;
using VacanciesAndCandidates.Models.CandidateModel;

namespace VacanciesAndCandidates.ModelsActions.CandidateAction
{
    static class CandidateAction
    {        
        public static ObservableCollection<CandidateModel> GetCandidate()
        {
            var candidateList = new ObservableCollection<CandidateModel>();

            using (CandidateContext db = new CandidateContext())
            {
                foreach (var item in db.Candidates.Where(c => c.Rec_Active == 1).ToList()) 
                    candidateList.Add(item);
            }

            return candidateList;
        }

        public static void AddCandidate(string[] sqlParameters,
                                        bool gender, 
                                        int? vacancyID,
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
                       '{2}',
                       @inputCorrect OUTPUT,
                       @resultText OUTPUT", String.Join("',\n'", sqlParameters), vacancyID, gender);

                var addCandidateQueryResult = db.Database.ExecuteSqlCommand(addCandidateQuery, inputCorrectParam, resultTextParam);
                db.SaveChanges();

                inputCorrect = (bool)inputCorrectParam.Value;
                resultText = resultTextParam.Value.ToString();
            }
        }



        public static void UpdateCandidate(int cadidateID, string[] sqlParameters,
                                       bool gender,
                                       int? vacancyID,
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
                    @"EXECUTE [dbo].[UpdateCandidate] 
                       {0},
                        '{1}',
                       '{2}',
                       '{3}',
                       @inputCorrect OUTPUT,
                       @resultText OUTPUT", cadidateID,String.Join("',\n'", sqlParameters),  vacancyID, gender);

                var addCandidateQueryResult = db.Database.ExecuteSqlCommand(addCandidateQuery, inputCorrectParam, resultTextParam);
                db.SaveChanges();

                inputCorrect = (bool)inputCorrectParam.Value;
                resultText = resultTextParam.Value.ToString();
            }
        }

        public static void DeleteCandidate(int cadidateID)
        {
            bool deleteFlag = false;
            if (MessageBox.Show("Вы хотите удалить кандидата?",
                "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                deleteFlag = true;

            if (deleteFlag) {
                using (CandidateContext db = new CandidateContext())
                {
                    string addCandidateQuery = string.Format(@"EXECUTE [dbo].[DeleteCandidate] {0}", cadidateID);

                    var addCandidateQueryResult = db.Database.ExecuteSqlCommand(addCandidateQuery);
                    db.SaveChanges();
                }
            }
        }


    }
}
