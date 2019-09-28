using System;

namespace StuffPacker.Persistence.Entity
{
    public class SoftDeleteEntityBase : ISoftDeleteEntity
    {

        public bool IsNew => Created == default(DateTimeOffset);

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Modified { get; set; }

        public string ModifiedBy { get; set; }

        public string CreatedBy { get; set; }

        public string DeletedBy { get; set; }

        public DateTimeOffset? Deleted { get; set; }


    }
}
