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
using VacanciesAndCandidates.ModelsActions.CandidateAction;
using VacanciesAndCandidates.Models.CandidateModel;

namespace VacanciesAndCandidates
{
    /// <summary>
    /// Логика взаимодействия для ShowCandidate.xaml
    /// </summary>
    public partial class ShowCandidateWindow : Window
    {
        public ShowCandidateWindow()
        { 
            InitializeComponent();
            CandidateList.ItemsSource = CandidateAction.GetCandidate();
        }

        public void UpdateCandidate(object sender, EventArgs e)
        {
            CreateCandidateWindow window = new CreateCandidateWindow((CandidateModel)CandidateList.SelectedItem);
            window.Show();
        }

        public void DeleteCandidate(object sender, EventArgs e)
        {
            var item = CandidateList.SelectedItem as CandidateModel;
            CandidateAction.DeleteCandidate(item.Id);
            CandidateList.ItemsSource = CandidateAction.GetCandidate();
        }
    }
}
