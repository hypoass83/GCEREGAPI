using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Localisation;
using Microsoft.EntityFrameworkCore;

namespace Insfrastructure.Entities.Security
{
    public class GlobalPerson
    {
        public int GlobalPersonID { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Tiergroup { get; set; }
        public string? Description { get; set; }

        [StringLength(100)]
        public string? CNI { get; set; }

        public int AdressID { get; set; }
        public virtual Adress? Adress { get; set; }

    }
}


