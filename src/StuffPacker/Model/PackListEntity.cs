using System;

namespace StuffPacker.Model
{
    public class PackListEntity
    {
        public Guid Id { get; set; }
        public string Groups { get; set; }

        public PackListEntity(Guid guid)
        {
            Id = guid;
        }
    }
}
