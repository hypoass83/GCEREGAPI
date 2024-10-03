using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Parameters
{
    public class Subject
    {
        public int SubjectID { get; set; }
        [StringLength(25)]
        public required string SubjectCode { get; set; }
        public required string SubjectName { get; set; }
        [StringLength(2)]
        public string? SubjectTag { get; set; }
        public int NumPapers { get; set; }
        public bool HasPract { get; set; }
        [StringLength(25)]
        public string? AltSubCode { get; set; }
        public bool MkSng { get; set; }
    }
}