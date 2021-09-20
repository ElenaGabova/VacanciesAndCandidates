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
using VacanciesAndCandidates.Views;

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
        }

        private void AddCandidate_Click(object sender, RoutedEventArgs e)
        {
            CreateCandidateWindow window = new CreateCandidateWindow();
            window.Show();
        }

        private void ShowCandidate_Click(object sender, RoutedEventArgs e)
        {
            ShowCandidateWindow window = new ShowCandidateWindow();
            window.Show();
        }
        private void AddVacancy_Click(object sender, RoutedEventArgs e)
        {
            CreateVacancyWindow window = new CreateVacancyWindow();
            window.Show();
        }

        private void ShowVacancy_Click(object sender, RoutedEventArgs e)
        {
            ShowVacancyWindow window = new ShowVacancyWindow();
            window.Show();
        }
    }
}
