using Domain.Models;
using Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesStores.Security
{
    public interface IJobStore 
    {
        public JobModel? CreateJob(JobModel JobModel);
        public JobModel? GetJobById(int id);
        public IEnumerable<JobModel>? GetAllJobs();
        public JobModel? UpdateJob(JobModel JobModel);
        public bool DeleteJob(int id);
    }
}
