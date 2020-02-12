using Microsoft.Extensions.Options;
using Shared.Contract.Options;
using StuffPacker.Enums;
using System;

namespace StuffPacker.Services
{
    public class CdnHelper : ICdnHelper
    {
        private readonly StorageOptions _storageOptions;

        public CdnHelper(IOptions<StorageOptions> storageOptions)
        {
            _storageOptions = storageOptions.Value;
        }
        public string GetPath(CdnFileType cdnFileType, string fileName)
        {

            switch (cdnFileType)
            {
                case CdnFileType.UserImage:
                    return _storageOptions.Cdn + "usrimg/" + fileName;
            }
            throw new Exception("No CdnFileType selected");
        }
    }
}
