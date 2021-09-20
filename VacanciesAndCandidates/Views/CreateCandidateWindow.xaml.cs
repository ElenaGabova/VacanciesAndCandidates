using System;
using System.Collections.Generic;
using System.Globalization;
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
using VacanciesAndCandidates.ModelsActions.CandidateAction;
using VacanciesAndCandidates.Models.CandidateModel;
using VacanciesAndCandidates.ModelsActions.VacancyAction;
using VacanciesAndCandidates.Models.VacansyModel;

namespace VacanciesAndCandidates
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class CreateCandidateWindow : Window
    {
        public CandidateModel Candidate;

        public CreateCandidateWindow()
        {
            InitializeComponent();
            vacancyBox.ItemsSource = VacancyAction.GetVacancy();
        }

        public CreateCandidateWindow(CandidateModel c)
        {
            InitializeComponent();
            Candidate = c;

            FullName.Text = Candidate.First_name + ' ' + Candidate.Last_name;
            if (!string.IsNullOrEmpty(Candidate.Middle_name))
                FullName.Text += ' ' + Candidate.Middle_name;

            Email.Text = Candidate.Email;
            dt_birthday.Text = Convert.ToString(Candidate.Dt_birthday);
            gender.IsChecked = Candidate.Gender;
            vacancyBox.ItemsSource = VacancyAction.GetVacancy();
            vacancyBox.SelectedItem = VacancyAction.GetVacancyByID(c.VacancyID);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }


        private void CreateCadidate_Click(object sender, RoutedEventArgs e)
        {
            var partsOfFullName = FullName.Text.Split(' ');

            string first_name  = partsOfFullName[0];
            string last_name   = partsOfFullName.Count() > 1 ? partsOfFullName[1] : string.Empty;
            string middle_name = partsOfFullName.Count() > 2 ? partsOfFullName[2] : string.Empty;
            
            string[] sqlParameters = new string[] { first_name,
                                                    last_name,
                                                    middle_name,
                                                    Email.Text, 
                                                    dt_birthday.Text };

            bool inputNotCorrect = false;
            string resultText = string.Empty;
            var vacancy = (VacansyModel)vacancyBox.SelectedItem;
            int? vacancyId = vacancy?.Id;

            if (Candidate is null)

                CandidateAction.AddCandidate(sqlParameters,
                                             (bool)gender.IsChecked,
                                             vacancyId,
                                             out inputNotCorrect,
                                             out resultText);
            else
                CandidateAction.UpdateCandidate(Candidate.Id, 
                                                sqlParameters,
                                                (bool)gender.IsChecked,
                                                vacancyId,
                                                out inputNotCorrect,
                                                out resultText);


            var textColor = Colors.Red;

            if (!inputNotCorrect)
            {
                textColor = Colors.Green;
                this.IsEnabled = false;
            }

            infoTextBlock.Text = resultText;
            infoTextBlock.Foreground = new SolidColorBrush(textColor);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
