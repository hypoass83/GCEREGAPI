using Domain.Models.Localisation;

namespace Domain.Models.Parameters
{
    public class ExamCentreModel
    {
        public int ExamCentreID { get; set; }
        public string ExamCentreCode { get; set; }
        public string ExamCentreName { get; set; }
        public string AbbreviatedName { get; set; }
        public int AdressID { get; set; }
        public virtual AdressModel Adress { get; set; }
        //public int CompanyID { get; set; }
    }
}
