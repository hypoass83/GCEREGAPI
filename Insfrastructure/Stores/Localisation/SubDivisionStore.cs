using Infrastructure.Entities;
using Insfrastructure.Entities.Localisation;
using Domain.Models.Localisation;
using Domain.InterfacesStores.Localisation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Stores.Localisation
{
    public class SubDivisionStore : ISubDivisionStore
    {
        private readonly FsContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public SubDivisionStore(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public SubDivisionModel? CreateSubDivision(SubDivisionModel SubDivisionModel)
        {
            var SubDivision = _mapper.Map<SubDivision>(SubDivisionModel);
            _dbContext.SubDivisions.Add(SubDivision);
            _dbContext.SaveChanges();
            _dbContext.Entry(SubDivision).State = EntityState.Detached;
            return GetSubDivisionById(SubDivision.SubDivisionID);
        }

        public SubDivisionModel? GetSubDivisionById(int SubDivisionId)
        {
            var SubDivision = _dbContext.SubDivisions.FirstOrDefault(u => u.SubDivisionID.Equals(SubDivisionId));
            return SubDivision == null ? null : _mapper.Map<SubDivisionModel>(SubDivision);
        }


        public IEnumerable<SubDivisionModel>? GetAllSubDivisions()
        {
            var SubDivisions = _dbContext.SubDivisions.ToList();
            return SubDivisions.Select(_mapper.Map<SubDivisionModel>);
        }

        public SubDivisionModel? UpdateSubDivision(SubDivisionModel SubDivisionModel)
        {
            var existingSubDivision = _dbContext.SubDivisions.FirstOrDefault(u => u.SubDivisionID == SubDivisionModel.SubDivisionID);
            if (existingSubDivision == null)
            {
                return null;
            }
            var SubDivision = _mapper.Map<SubDivision>(SubDivisionModel);
            _dbContext.Entry(existingSubDivision).CurrentValues.SetValues(SubDivision);
            _dbContext.SaveChanges();
            _dbContext.Entry(SubDivision).State = EntityState.Detached;
            return GetSubDivisionById(SubDivision.SubDivisionID);
        }

        public bool DeleteSubDivision(int id)
        {
            var SubDivision = _dbContext.SubDivisions.FirstOrDefault(u => u.SubDivisionID.Equals(id));
            if (SubDivision == null)
            {
                return false;
            }

            _dbContext.SubDivisions.Remove(SubDivision);
            _dbContext.SaveChanges();
            return true;
        }
    }
}