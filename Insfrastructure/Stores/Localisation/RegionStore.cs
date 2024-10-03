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
    public class RegionStore : IRegionStore
    {
        private readonly FsContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public RegionStore(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public RegionModel? CreateRegion(RegionModel RegionModel)
        {
            var Region = _mapper.Map<Region>(RegionModel);
            _dbContext.Regions.Add(Region);
            _dbContext.SaveChanges();
            _dbContext.Entry(Region).State = EntityState.Detached;

            return GetRegionById(Region.RegionID);

        }

        public RegionModel? GetRegionById(int RegionId)
        {
            var Region = _dbContext.Regions.FirstOrDefault(u => u.RegionID.Equals(RegionId));
            return Region == null ? null : _mapper.Map<RegionModel>(Region);
        }


        public IEnumerable<RegionModel>? GetAllRegions()
        {
            var Regions = _dbContext.Regions.ToList();
            return Regions.Select(_mapper.Map<RegionModel>);
        }

        public RegionModel? UpdateRegion(RegionModel regionModel)
        {
            var existingRegion = _dbContext.Regions.FirstOrDefault(u => u.RegionID == regionModel.RegionID);
            if (existingRegion == null)
            {
                return null;
            }
            var region = _mapper.Map<Region>(regionModel);

            _dbContext.Entry(existingRegion).CurrentValues.SetValues(region);
            _dbContext.SaveChanges();
            _dbContext.Entry(region).State = EntityState.Detached;
            return GetRegionById(region.RegionID)  ;
        }

        public bool DeleteRegion(int id)
        {
            var Region = _dbContext.Regions.FirstOrDefault(u => u.RegionID.Equals(id));
            if (Region == null)
            {
                return false;
            }

            _dbContext.Regions.Remove(Region);
            _dbContext.SaveChanges();
            return true;
        }
    }
}