using System;
using System.Collections.Generic;

namespace StuffPacker.Model
{
    public class PackListGroupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PackListGroupItemModel> Items { get; set; }
    }
    [Obsolete("dont use this one for new objects")]
    public class OldPackListGroupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> Items { get; set; }
    }


    

    public class PackListGroupItemModel
    {
        public Guid Id { get;  set; }
        public bool IsKit { get; set; }
    }
}
