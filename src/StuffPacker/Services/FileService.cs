using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using StuffPacker.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Shared.Contract.Options;
namespace StuffPacker.Services
{
    public class FileService : IFileService
    {
        
        private readonly IWebHostEnvironment _env;
        private readonly StorageOptions _storageOptions;

        public FileService(IWebHostEnvironment env,IOptions<StorageOptions> storageOptions)
        {
            
            _env = env;
            _storageOptions = storageOptions.Value;
        }
        public async Task<string> GetFileName(Guid Id,FileUploadType fileUploadType,string filename)
        {
           
            switch(fileUploadType)
            {
                case FileUploadType.UserImg:
                    return GetUserImg(Id,Path.GetExtension(filename));
                case FileUploadType.ProductImg:
                    return GetFilenameInner(Id, Path.GetExtension(filename));

            }
            throw new Exception("no file upload type selected");
        }

        private string GetFilenameInner(Guid id, string fileExtension)
        {
            return id.ToString("N") + DateTime.UtcNow.Ticks + fileExtension;
        }

        private string GetUserImg(Guid userId,string fileExtension)
        {
            if(userId==Guid.Empty)
            {
                throw new Exception("no user");
            }
            return GetFilenameInner(userId,fileExtension);
        }

        public async Task Save(MemoryStream stream, string fileName, FileUploadType fileUploadType)
        {
            try
            {
                var path=GetPath(fileUploadType);

                string filename = path + fileName;

                FileStream writeStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
              
                await ReadWriteStream(stream, writeStream);

            }
            catch (Exception e)
            {

                throw;
            }



        }

        private string GetPath(FileUploadType fileUploadType)
        {
            string contentRootPath = _env.WebRootPath;
            switch (fileUploadType)
            {
                case FileUploadType.UserImg:
                    return contentRootPath + "\\img\\members\\";
            }
            throw new Exception("cant create path");
        }

        private async Task ReadWriteStream(Stream readStream, Stream writeStream)
        {


            readStream.Seek(0, SeekOrigin.Begin);
            var bla = readStream.Position;
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = await readStream.ReadAsync(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }

        public string CheckExtension(string extension, FileUploadType fileUploadType)
        {
           switch(fileUploadType)
            {
                case FileUploadType.UserImg:
                    if(extension!=".png" && extension != ".jpg" && extension != ".jpeg")
                    {
                        return "file extension must be one of: png,jpg";
                    }
                    break;

                case FileUploadType.ProductImg:
                    if (extension != ".png" && extension != ".jpg" && extension != ".jpeg")
                    {
                        return "file extension must be one of: png,jpg";
                    }
                    break;
            }
            return string.Empty;
        }

        public async Task UploadToStorage(string fileName,MemoryStream file, FileUploadType fileUploadType)
        {
            string connectionString = _storageOptions.ConnectionString; 

            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            var containerName = GetBlobContainer(fileUploadType);
            BlobContainerClient containerClient =  blobServiceClient.GetBlobContainerClient(containerName) ;// .CreateBlobContainerAsync(containerName);

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            // Open the file and upload its data
            //using FileStream uploadFileStream = File.OpenRead(localFilePath);
            await blobClient.UploadAsync(file);
            //uploadFileStream.Close();
        }

        private string GetBlobContainer(FileUploadType fileUploadType)
        {
            switch(fileUploadType)
            {
                case FileUploadType.UserImg:
                    return "usrimg";
                case FileUploadType.ProductImg:
                    return "productimg";
            }
            throw new Exception("Cant find container name");
        }
    }
}
