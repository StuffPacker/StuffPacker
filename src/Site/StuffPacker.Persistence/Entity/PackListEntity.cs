using StuffPacker.Persistence.Entity;
using System;

namespace StuffPacker.Model
{
    public class PackListEntity: SoftDeleteEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Groups { get; set; }

        public PackListEntity(Guid id)
        {
            Id = id;
        }
    }
}
