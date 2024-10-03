﻿using Domain.Models;
using Domain.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesServices.Parameters
{
    public interface IExamCentreService
    {
        public ExamCentreModel? CreateExamCentre(ExamCentreModel ExamCentreModel);
        public ExamCentreModel? GetExamCentreById(int id);
        public IEnumerable<ExamCentreModel>? GetAllExamCentres();
        public ExamCentreModel? UpdateExamCentre(ExamCentreModel ExamCentreModel);
        public bool DeleteExamCentre(int id);
    }
}
