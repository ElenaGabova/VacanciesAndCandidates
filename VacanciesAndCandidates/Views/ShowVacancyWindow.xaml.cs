using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using VacanciesAndCandidates.Models.VacansyModel;
using VacanciesAndCandidates.ModelsActions.VacancyAction;

namespace VacanciesAndCandidates.Views
{
    /// <summary>
    /// Логика взаимодействия для ShowVacancyWindow.xaml
    /// </summary>
    public partial class ShowVacancyWindow : Window
    {
        public ShowVacancyWindow()
        {
            InitializeComponent();
            VacancyList.ItemsSource = VacancyAction.GetVacancy();
        }

        public void UpdateVacancy(object sender, EventArgs e)
        {
            CreateVacancyWindow window = new CreateVacancyWindow((VacansyModel) VacancyList.SelectedItem);
            window.Show();
        }
    }
}
