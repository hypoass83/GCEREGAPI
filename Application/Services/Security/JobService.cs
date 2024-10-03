using Domain.Models;
using Domain.InterfacesStores.Security;
using Domain.InterfacesServices.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Security;

namespace Application.Service
{
    public class JobService : IJobService
    {
        private readonly IJobStore _JobStore;

        public JobService(IJobStore JobService)
        {
            _JobStore = JobService;
        }

        public JobModel? CreateJob(JobModel Job)
        {
            return _JobStore.CreateJob(Job);
        }

        public JobModel? GetJobById(int JobId)
        {
            return _JobStore.GetJobById(JobId);
        }

        public IEnumerable<JobModel>? GetAllJobs()
        {
            return _JobStore.GetAllJobs();
        }

        public JobModel? UpdateJob(JobModel JobModel)
        {
            return _JobStore.UpdateJob(JobModel);
        }

        public bool DeleteJob(int idJob)
        {
            return _JobStore.DeleteJob(idJob);
        }

    }
}
