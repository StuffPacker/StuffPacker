using StuffPacker.Enums;

namespace StuffPacker.Services
{
    public interface ICdnHelper
    {
        string GetPath(CdnFileType cdnFileType, string fileName);
    }
}
