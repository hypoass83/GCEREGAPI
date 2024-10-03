using Domain.Models;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insfrastructure.Entities.Parameters;
using Domain.Models.Parameters;
using Domain.InterfacesStores.Parameters;

namespace Insfrastructure.Stores.Parameters
{
    public class ExamCentreStore : IExamCentreStore
    {
        private readonly FsContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public ExamCentreStore(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public ExamCentreModel? CreateExamCentre(ExamCentreModel ExamCentreModel)
        {
            var ExamCentre = _mapper.Map<ExamCentre>(ExamCentreModel);
            _dbContext.Examcentres.Add(ExamCentre);
            _dbContext.SaveChanges();
            return _mapper.Map<ExamCentreModel>(ExamCentreModel);
        }

        public ExamCentreModel? GetExamCentreById(int ExamCentreId)
        {
            var ExamCentre = _dbContext.Examcentres.FirstOrDefault(u => u.ExamCentreID.Equals(ExamCentreId));
            return ExamCentre == null ? null : _mapper.Map<ExamCentreModel>(ExamCentre);
        }


        public IEnumerable<ExamCentreModel>? GetAllExamCentres()
        {
            var ExamCentres = _dbContext.Examcentres.ToList();
            return ExamCentres.Select(_mapper.Map<ExamCentreModel>);
        }

        public ExamCentreModel? UpdateExamCentre(ExamCentreModel ExamCentreModel)
        {
            var ExamCentre = _mapper.Map<ExamCentre>(ExamCentreModel);
            _dbContext.Examcentres.Update(ExamCentre);
            _dbContext.SaveChanges();
            return _mapper.Map<ExamCentreModel>(ExamCentreModel);
        }

        public bool DeleteExamCentre(int id)
        {
            var ExamCentre = _dbContext.Examcentres.FirstOrDefault(u => u.ExamCentreID.Equals(id));
            if (ExamCentre == null)
            {
                return false;
            }

            _dbContext.Examcentres.Remove(ExamCentre);
            _dbContext.SaveChanges();
            return true;
        }
    }
}