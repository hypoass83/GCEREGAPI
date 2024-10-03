using Domain.InterfacesServices.File;
using Domain.InterfacesStores.File;
using Infrastructure.Entities;
using Insfrastructure.Entities.Parameters;
using Microsoft.AspNetCore.Http;

namespace Insfrastructure.Stores.FIles
{
    public class FileStore : IFileStore
    {
        private readonly FsContext _dbContext;

        public FileStore(FsContext dbContext)
        {
            _dbContext = dbContext;

        }
        public int UploadFile(IFormFile file)
        {
            var archive = new Archive();
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                byte[] fileBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(fileBytes);

                archive.FileBase64 = base64String;
                archive.FileName = file.FileName;
                archive.ContentType = file.ContentType;
            }

            _dbContext.Archives.Add(archive);
            _dbContext.SaveChanges();

            return archive.ArchiveID;

        }
    }
}