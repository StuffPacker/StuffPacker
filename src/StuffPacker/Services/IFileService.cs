using StuffPacker.Enums;
using System.IO;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IFileService
    {
        Task Save(MemoryStream stream, string fileName, FileUploadType fileUploadType);
        Task<string> GetFileName(FileUploadType fileUploadType,string filename);
        string CheckExtension(string extension, FileUploadType fileUploadType);
    }

}
