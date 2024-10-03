using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.InterfacesServices.File;
using Domain.InterfacesStores.File;
using Microsoft.AspNetCore.Http;

namespace Application.Services.File
{
    public class FileService : IFileService
    {
        private readonly IFileStore _fileStore;
        public FileService(IFileStore fileStore){
            _fileStore = fileStore;
        }
       public int UploadFile(IFormFile file)
        {
            return _fileStore.UploadFile(file);
        }
    }
}