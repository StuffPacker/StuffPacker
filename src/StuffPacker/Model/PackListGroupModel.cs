using System;
using System.Collections.Generic;

namespace StuffPacker.Model
{
    public class PackListGroupModel
    {
        public string Name { get; set; }

        public IEnumerable<Guid> Items { get; set; }
    }
}
