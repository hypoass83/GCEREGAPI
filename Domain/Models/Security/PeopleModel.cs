using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Security
{
    public class PeopleModel : GlobalPersonModel
    {
        public int SexeID { get; set; }
        public SexModel Sex { get; set; }
        public bool IsConnected { get; set; }
        public bool IsMaster { get; set; }
        public bool IsSeller { get; set; }
    }
}
