using System;

namespace StuffPacker.Persistence.Entity
{
    public interface ISoftDeleteEntity
    {
        string DeletedBy { get; set; }

        DateTimeOffset? Deleted { get; set; }
    }
}
