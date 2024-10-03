using Insfrastructure.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insfrastructure.Entities.Parameters.Examiners
{

    public class Rank
    {
        public int RankID { get; set; }
        public required string RankCode { get; set; }
        public string? RankName { get; set; }
        
    }
}