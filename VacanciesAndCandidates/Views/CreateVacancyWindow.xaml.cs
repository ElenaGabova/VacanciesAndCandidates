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
using VacanciesAndCandidates.Models.VacansyModel;
using VacanciesAndCandidates.ModelsActions.VacancyAction;

namespace VacanciesAndCandidates
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class CreateVacancyWindow : Window
    {
        public VacansyModel Vancancy;

        public CreateVacancyWindow()
        {
            InitializeComponent();
        }
        public CreateVacancyWindow(VacansyModel c)
        {
            InitializeComponent();
            Vancancy = c;

            staffing_item_parrent_full_ext_id.Text = Vancancy.Staffing_item_parrent_full_ext_id;
            staffing_item_full_ext_id.Text = Vancancy.Staffing_item_full_ext_id;
            Fio_vlad.Text = Vancancy.Fio_vlad;
            Telefon_vlad.Text = Vancancy.Telefon_vlad;
            Fio_rec.Text = Vancancy.Fio_rec;
            Telefon_rec.Text = Vancancy.Telefon_rec;
            Email_rec.Text = Vancancy.Email_rec;
        }

        private void CreateVacancy_Click(object sender, RoutedEventArgs e)
        {
            string[] sqlParameters = new string[] { staffing_item_parrent_full_ext_id.Text,
                                                    staffing_item_full_ext_id.Text,
                                                    Fio_vlad.Text,
                                                    Telefon_vlad.Text ,
                                                    Fio_rec.Text,
                                                    Telefon_rec.Text,
                                                    Email_rec.Text
            };

            bool inputNotCorrect = false;
            string resultText = string.Empty;

            if (Vancancy is null)

                VacancyAction.AddVacancy(sqlParameters,
                                             out inputNotCorrect,
                                             out resultText);
            else
                VacancyAction.UpdateVacancy(Vancancy.Id,
                                            sqlParameters,
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
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
