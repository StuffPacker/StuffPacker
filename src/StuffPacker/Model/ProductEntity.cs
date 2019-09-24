using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Model
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get;  set; }
        public WeightPrefix WeightPrefix { get;  set; }

        public ProductEntity(Guid id)
        {
            Id = id;
        }
    }
}
