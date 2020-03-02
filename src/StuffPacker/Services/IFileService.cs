using StuffPacker.Enums;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IFileService
    {
        Task Save(MemoryStream stream, string fileName, FileUploadType fileUploadType);
        Task<string> GetFileName(Guid Id,FileUploadType fileUploadType,string filename);
        string CheckExtension(string extension, FileUploadType fileUploadType);

        Task UploadToStorage(string fileName, MemoryStream file, FileUploadType fileUploadType);
    }

}
