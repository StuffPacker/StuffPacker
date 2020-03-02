using Shared.Contract;
using Shared.Contract.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StuffPacker.Model
{
    public class ProductModel
    {
        public ProductEntity Entity;

        public ProductModel(ProductEntity entity)
        {
            Entity = entity;
        }

        public string Name => Entity.Name;

        public string Description => Entity.Description;

        public decimal Weight => Entity.Weight;

        public WeightPrefix WeightPrefix => Entity.WeightPrefix;

        public Guid Id => Entity.Id;

        public Guid? Owner => Entity.Owner;

        public void Update(string name, decimal weight,WeightPrefix weightPrefix,string description)
        {
            Entity.Name = name;
            Entity.WeightPrefix = weightPrefix;
            if(weightPrefix!= WeightPrefix.Gram)
            {
                weight = WeightHelper.ConvertToGram(weight,weightPrefix);
            }
            Entity.Weight = weight;
            Entity.Description = description;
        }
        public IEnumerable<ProductImageDto> Images=>GetImages();

        private IEnumerable<ProductImageDto> GetImages()
        {
            var images = Entity.Images;
            if(string.IsNullOrEmpty(images))
            {
                return new List<ProductImageDto>();
            }
            return Shared.Common.Serializer.Default.DeSerialize<List<ProductImageDto>>(images);
        }

        public void AddImg(Guid fileId,string imageName)
        {
            var images = Images.ToList();
            images.Add(new ProductImageDto
            {
                Id=fileId,
                FileName=imageName
            });
            Entity.Images = Shared.Common.Serializer.Default.Serialize(images);
        }

        
    }
}
