using Insfrastructure.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insfrastructure.Entities.Parameters.Examiners
{

    public class IndexCat
    {
        public int IndexCatID { get; set; }
        public required string IndexCatCode { get; set; }
        public string? IndexCatName { get; set; }
        
    }
}