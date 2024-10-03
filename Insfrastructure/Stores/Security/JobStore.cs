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
    public class JobStore : IJobStore
    {
        private readonly FsContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public JobStore(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public JobModel? CreateJob(JobModel JobModel)
        {
            var Job = _mapper.Map<Job>(JobModel);
            _dbContext.Jobs.Add(Job);
            _dbContext.SaveChanges();
            _dbContext.Entry(Job).State = EntityState.Detached;
            return GetJobById(Job.JobID);
        }

        public JobModel? GetJobById(int JobId)
        {
            var Job = _dbContext.Jobs.FirstOrDefault(u => u.JobID.Equals(JobId));
            return Job == null ? null : _mapper.Map<JobModel>(Job);
        }


        public IEnumerable<JobModel>? GetAllJobs()
        {
            var jobs = _dbContext.Jobs.ToList();
            return jobs.Select(_mapper.Map<JobModel>);
        }

        public JobModel? UpdateJob(JobModel JobModel)
        {
            var existingJob = _dbContext.Jobs.FirstOrDefault(u => u.JobID == JobModel.JobID);
            if (existingJob == null)
            {
                return null;
            }
            var Job = _mapper.Map<Job>(JobModel);
            _dbContext.Entry(existingJob).CurrentValues.SetValues(Job);
            _dbContext.SaveChanges();
            _dbContext.Entry(Job).State = EntityState.Detached;
            return GetJobById(Job.JobID);
        }

        public bool DeleteJob(int id)
        {
            var Job = _dbContext.Jobs.FirstOrDefault(u => u.JobID.Equals(id));
            if (Job == null)
            {
                return false;
            }

            _dbContext.Jobs.Remove(Job);
            _dbContext.SaveChanges();
            return true;
        }
    }
}