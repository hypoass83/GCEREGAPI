using Insfrastructure.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insfrastructure.Entities.Parameters.Examiners
{

    public class SelectedExaminer
    {
        public int SelectedExaminerID { get; set; }
        [StringLength(5)]
        public required string RoeCode { get; set; }
        public required string NameofExaminer { get; set; }
        public required string Post { get; set; }
        public string? Institution { get; set; }
        public string? Qualif { get; set; }
        public string? IndexCat { get; set; }
        public string? Division { get; set; }
        public string? SubjectCode { get; set; }
        public string? ExamCode { get; set; }
    }
}