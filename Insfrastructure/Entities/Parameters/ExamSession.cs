using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insfrastructure.Entities.Parameters
{
    [Serializable]
    public class ExamSession
    {
        public int ExamSessionID { get; set; }
        
        [Required]
        public int Session { get; set; }
        [StringLength(10)]
        public required string SessionName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RegStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RegEnd { get; set; }

        public bool RegClose { get; set; }

        public int ExamCentreID { get; set; }
        public virtual ExamCentre? ExamCentre { get; set; }  

    }


}