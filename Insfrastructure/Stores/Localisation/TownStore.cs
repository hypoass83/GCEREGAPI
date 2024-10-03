using Domain.Models;
using Domain.InterfacesStores.Security;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Security;
using Insfrastructure.Entities.Security;
using Insfrastructure.Entities.Localisation;
using Domain.Models.Localisation;
using Domain.InterfacesStores.Localisation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Stores.Localisation
{
    public class DivisionStore : IDivisionStore
    {
        private readonly FsContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public DivisionStore(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public DivisionModel? CreateDivision(DivisionModel DivisionModel)
        {
            var Division = _mapper.Map<Division>(DivisionModel);
            _dbContext.Divisions.Add(Division);
            _dbContext.SaveChanges();
            _dbContext.Entry(Division).State = EntityState.Detached;
            return GetDivisionById(Division.DivisionID);
        }

        public DivisionModel? GetDivisionById(int DivisionId)
        {
            var Division = _dbContext.Divisions.FirstOrDefault(u => u.DivisionID.Equals(DivisionId));
            return Division == null ? null : _mapper.Map<DivisionModel>(Division);
        }


        public IEnumerable<DivisionModel>? GetAllDivisions()
        {
            var Divisions = _dbContext.Divisions.ToList();
            return Divisions.Select(_mapper.Map<DivisionModel>);
        }

        public DivisionModel? UpdateDivision(DivisionModel DivisionModel)
        {
            var existingDivision = _dbContext.Divisions.FirstOrDefault(u => u.DivisionID == DivisionModel.DivisionID);
            if (existingDivision == null)
            {
                return null;
            }
            var Division = _mapper.Map<Division>(DivisionModel);
            _dbContext.Entry(existingDivision).CurrentValues.SetValues(Division);
            _dbContext.SaveChanges();
            _dbContext.Entry(Division).State = EntityState.Detached;
            return GetDivisionById(Division.DivisionID);
        }

        public bool DeleteDivision(int id)
        {
            var Division = _dbContext.Divisions.FirstOrDefault(u => u.DivisionID.Equals(id));
            if (Division == null)
            {
                return false;
            }

            _dbContext.Divisions.Remove(Division);
            _dbContext.SaveChanges();
            return true;
        }
    }
}