using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Parameters;
using Domain.InterfacesStores.Parameters;
using Domain.InterfacesServices.Parameters;

namespace Application.Services.Parameters
{
    public class ExamCentreService : IExamCentreService
    {
        private readonly IExamCentreStore _ExamCentreStore;

        public ExamCentreService(IExamCentreStore ExamCentreService)
        {
            _ExamCentreStore = ExamCentreService;
        }

        public ExamCentreModel? CreateExamCentre(ExamCentreModel ExamCentre)
        {
            return _ExamCentreStore.CreateExamCentre(ExamCentre);
        }

        public ExamCentreModel? GetExamCentreById(int ExamCentreId)
        {
            return _ExamCentreStore.GetExamCentreById(ExamCentreId);
        }

        public IEnumerable<ExamCentreModel>? GetAllExamCentres()
        {
            return _ExamCentreStore.GetAllExamCentres();
        }

        public ExamCentreModel? UpdateExamCentre(ExamCentreModel ExamCentreModel)
        {
            return _ExamCentreStore.UpdateExamCentre(ExamCentreModel);
        }

        public bool DeleteExamCentre(int idExamCentre)
        {
            return _ExamCentreStore.DeleteExamCentre(idExamCentre);
        }

    }
}
