using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VacanciesAndCandidates.DatabaseSettings.CandidateContext;
using VacanciesAndCandidates.Models.CandidateModel;

namespace VacanciesAndCandidates
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



           string[] sqlParameters = new string[] { "Елена", "Белых", "Юрьевна", "", "44" };
           bool inputCorrect = false;
           string resultText = string.Empty;
           AddCandidate(sqlParameters, out inputCorrect, out resultText);
          
            MessageBox.Show(resultText);

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        public static void AddCandidate(string[] sqlParameters, 
                                        out bool inputCorrect, 
                                        out string  resultText)
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
                Size   = 250,
                Direction = System.Data.ParameterDirection.Output
            };

            using (CandidateContext db = new CandidateContext())
            {
                string addCandidateQuery = string.Format(
                    @"EXECUTE [dbo].[AddCandidate] 
                      '{0}',
                      false,
                     @inputCorrect OUTPUT,
                     @resultText OUTPUT", String.Join("',\n'", sqlParameters));

                var addCandidateQueryResult = db.Database.ExecuteSqlCommand(addCandidateQuery, inputCorrectParam, resultTextParam);
                db.SaveChanges();

                inputCorrect = (bool)inputCorrectParam.Value;
                resultText   = resultTextParam.Value.ToString();
            }
        }

    }
}
