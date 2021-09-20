using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VacanciesAndCandidates.DatabaseSettings.VacansyContext;
using VacanciesAndCandidates.Models.VacansyModel;

namespace VacanciesAndCandidates.ModelsActions.VacancyAction
{
    class VacancyAction
    {
        public static ObservableCollection<VacansyModel> GetVacancy()
        {
            var vacancyList = new ObservableCollection<VacansyModel>();

            using (VacansyContext db = new VacansyContext())
            {
                foreach (var item in db.Vacansies.ToList())
                    vacancyList.Add(item);
            }

            return vacancyList;

        }

        public static VacansyModel GetVacancyByID(int vacancyID)
        {
            using (VacansyContext db = new VacansyContext())
            {
                return db.Vacansies.Where(c => c.Id == vacancyID).FirstOrDefault();
            }
        }

        public static void AddVacancy(string[] sqlParameters,
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

            using (VacansyContext db = new VacansyContext())
            {
                string addVacancyQuery = string.Format(
                    @"EXECUTE [dbo].[AddVacancy] 
                       '{0}',
                       @inputCorrect OUTPUT,
                       @resultText OUTPUT", String.Join("',\n'", sqlParameters));

                var addVacancyQueryResult = db.Database.ExecuteSqlCommand(addVacancyQuery, inputCorrectParam, resultTextParam);
                db.SaveChanges();

                inputCorrect = (bool)inputCorrectParam.Value;
                resultText = resultTextParam.Value.ToString();
            }
        }

        public static void UpdateVacancy(int vacancyID, string[] sqlParameters,
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

            using (VacansyContext db = new VacansyContext())
            {
                string addVacancyQuery = string.Format(
                    @"EXECUTE [dbo].[UpdateVacancy] 
                        {0},
                       '{1}',
                       @inputCorrect OUTPUT,
                       @resultText OUTPUT", vacancyID, String.Join("',\n'", sqlParameters));

                var addVacancyQueryResult = db.Database.ExecuteSqlCommand(addVacancyQuery, inputCorrectParam, resultTextParam);
                db.SaveChanges();

                inputCorrect = (bool)inputCorrectParam.Value;
                resultText = resultTextParam.Value.ToString();
            }
        }
    }
}
