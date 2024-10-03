using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domain.InterfacesStores.File
{
    public interface IFileStore
    {
        public int UploadFile(IFormFile file);

    }
}