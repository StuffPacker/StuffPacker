using System;

namespace StuffPacker.Persistence.Entity
{
    public class ProductGroupEntity
    {
        public Guid Id { get; set; }
        public Guid Owner { get; set; }

        public string Name { get; set; }
        public bool Maximized { get; set; }

        public void UpdateMaximized(bool maximized)
        {
            Maximized = maximized;
        }
    }
}
