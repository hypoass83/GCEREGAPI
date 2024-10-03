using Insfrastructure.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insfrastructure.Entities.Parameters.Examiners
{

    public class Qualification
    {
        public int QualificationID { get; set; }
        public required string QualificationCode { get; set; }
        public string? QualificationName { get; set; }
        
    }
}