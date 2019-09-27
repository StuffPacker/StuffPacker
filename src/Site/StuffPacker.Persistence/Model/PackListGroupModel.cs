using System;
using System.Collections.Generic;

namespace StuffPacker.Model
{
    public class PackListGroupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Guid> Items { get; set; }
    }
}
