using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domain.InterfacesServices.File
{
    public interface IFileService
    {
        public int UploadFile(IFormFile file);
    }
}