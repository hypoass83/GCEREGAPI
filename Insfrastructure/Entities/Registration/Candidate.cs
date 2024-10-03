using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;
using Insfrastructure.Entities.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insfrastructure.Entities.Registration
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public int ExamID { get; set; }
        public virtual Exam? Exam { get;set;}
        public int Session { get; set; }
        public int ExamCentreID { get; set; }
        public virtual ExamCentre? ExamCentre { get; set; }
        public long CandNumber { get; set; }
        [StringLength(100)]
        public string? MinesecMatricule { get; set; }
        public required string CandName { get; set; }
        [StringLength(10)]
        public string? Sex { get; set; }
        [StringLength(10)]
        public required string BirthDate { get; set; }
        [StringLength(200)]
        public string? PlaceOfBirth { get; set; }

        public int? SubDivisionID { get; set; }
        public virtual SubDivision? SubDivision { get; set; }
        [StringLength(20)]
        public required string TelNo { get; set; }
        [StringLength(200)]
        public string? Email { get; set; }

        public int? SpecialtyID { get; set; }
        public virtual Specialty? Specialty { get; set; }

        public int? SpecialtyNAID { get; set; }
        public virtual Specialty? SpecialtyNA { get; set; }

        public string? Picture4x4Path { get; set; }
        public string? ScanG3FormPath { get; set; }
        public string? ScanBirthCertificatePath { get; set; }
        public string? ScanHighDiplomaPath { get; set; }
        public string? ScanIDCardPath { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}