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
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Stores.Security
{
    public class MouchardStore : IMouchardStore
    {
        private readonly FsContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public MouchardStore(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public void LogAction(MouchardModel mouchardModel)
        {
            var mouchard = _mapper.Map<Mouchard>(mouchardModel);
            _dbContext.Mouchards.Add(mouchard);
            _dbContext.SaveChanges();

        }
    }
}