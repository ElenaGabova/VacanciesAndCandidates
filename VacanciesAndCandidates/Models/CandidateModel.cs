using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacanciesAndCandidates.Models.CandidateModel
{
    [Table("Candidates")]
    public class CandidateModel
    {
		string first_name,
			   last_name,
			   middle_name,
			   email;

		DateTime dt_birthday;
        bool gender;
        int rec_Active;
        int vacancyID;
        
        [Key]
        public int Id { get; set; }
        public string First_name
        {
            get { return first_name; }
            set
            {
                first_name = value;
                OnPropertyChanged("First_name");
            }
        }
        public string Last_name
        {
            get { return last_name; }
            set
            {
                last_name = value;
                OnPropertyChanged("Last_name");
            }
        }
        public string Middle_name
        {
            get { return middle_name; }
            set
            {
                middle_name = value;
                OnPropertyChanged("Middle_name");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public int VacancyID
        {
            get { return vacancyID; }
            set
            {
                vacancyID = value;
                OnPropertyChanged("VacancyID");
            }
        }

        public DateTime Dt_birthday
        {
            get { return dt_birthday; }
            set
            {
                dt_birthday = value;
                OnPropertyChanged("Dt_birthday");
            }
        }
        public bool Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }
        public int Rec_Active
        {
            get { return rec_Active; }
            set
            {
                rec_Active = value;
                OnPropertyChanged("Rec_Active");
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
