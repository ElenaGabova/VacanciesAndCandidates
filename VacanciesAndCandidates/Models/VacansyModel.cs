using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacanciesAndCandidates.Models.VacansyModel
{
    [Table("Vacansies")]
    public class VacansyModel
    {
        string staffing_item_parrent_full_ext_id,
               staffing_item_full_ext_id,
               fio_vlad,
               telefon_vlad,
               fio_rec,
               telefon_rec,
               email_rec;

        [Key]
        public int Id { get; set; }
        public string Staffing_item_parrent_full_ext_id
        {
            get { return staffing_item_parrent_full_ext_id; }
            set
            {
                staffing_item_parrent_full_ext_id = value;
                OnPropertyChanged("Staffing_item_parrent_full_ext_id");
            }
        }
        public string Staffing_item_full_ext_id
        {
            get { return staffing_item_full_ext_id; }
            set
            {
                staffing_item_full_ext_id = value;
                OnPropertyChanged("Staffing_item_full_ext_id");
            }
        }
        public string Fio_vlad
        {
            get { return fio_vlad; }
            set
            {
                fio_vlad = value;
                OnPropertyChanged("Fio_vlad");
            }
        }
        public string Telefon_vlad
        {
            get { return telefon_vlad; }
            set
            {
                telefon_vlad = value;
                OnPropertyChanged("Telefon_vlad");
            }
        }
        public string Fio_rec
        {
            get { return fio_rec; }
            set
            {
                fio_rec = value;
                OnPropertyChanged("Fio_rec");
            }
        }
        public string Email_rec
        {
            get { return email_rec; }
            set
            {
                email_rec = value;
                OnPropertyChanged("Email_rec");
            }
        }
        public string Telefon_rec
        {
            get { return telefon_rec; }
            set
            {
                telefon_rec = value;
                OnPropertyChanged("Telefon_rec");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
