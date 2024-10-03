using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Models.Localisation;

namespace Domain.Models.Parameters
{
    public class ExamCentreModel
    {
        public int ExamCentreID { get; set; }
        public string ExamCentreCode { get; set; }
        public string ExamCentreAbbreviation { get; set; }
        public string ExamCentreName { get; set; }
        public string ExamCentreDescription { get; set; }
        public int AdressID { get; set; }
        public virtual AdressModel Adress { get; set; }
        //public int CompanyID { get; set; }
    }
}
