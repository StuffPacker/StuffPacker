using System;
using System.Collections.Generic;

namespace Shared.Contract.Dtos.PackList
{
    public class UpdatePackListVisibleListDto
    {
        public IEnumerable<PackListVisibleDto> VisibleList { get; set; }
    }
    public class PackListVisibleDto
    {
        public Guid Id { get; set; }
        public bool Visible { get; set; }
    }
}
