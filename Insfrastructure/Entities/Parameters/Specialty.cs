using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insfrastructure.Entities.Parameters
{
    public class Specialty
    {
        public int SpecialtyID { get;set;}
        public required string SpecialtyCode { get;set;}
        public string? SpecialtyName { get;set;}
        public string? ShortName { get;set;}
        public SpecialtyType SpecialtyType { get;set;}
    }
    public enum SpecialtyType
    {
        None,Commercial,Industrial
    }
}