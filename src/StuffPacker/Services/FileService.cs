using Microsoft.AspNetCore.Hosting;
using StuffPacker.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public class FileService : IFileService
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IWebHostEnvironment _env;

        public FileService(ICurrentUserProvider currentUserProvider, IWebHostEnvironment env)
        {
            _currentUserProvider = currentUserProvider;
            _env = env;
        }
        public async Task<string> GetFileName(FileUploadType fileUploadType,string filename)
        {
           
            switch(fileUploadType)
            {
                case FileUploadType.UserImg:
                    return GetUserImg(_currentUserProvider.GetUserId,Path.GetExtension(filename));
                    
            }
            throw new Exception("no file upload type selected");
        }

        private string GetUserImg(Guid userId,string fileExtension)
        {
            if(userId==Guid.Empty)
            {
                throw new Exception("no user");
            }
            return userId.ToString("N") + DateTime.UtcNow.Ticks + fileExtension;
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
            }
            return string.Empty;
        }
    }
}
