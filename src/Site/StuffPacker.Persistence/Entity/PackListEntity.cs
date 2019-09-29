﻿using StuffPacker.Persistence.Entity;
using System;

namespace StuffPacker.Model
{
    public class PackListEntity: SoftDeleteEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Groups { get; set; }
        public Guid UserId { get; set; }

        public PackListEntity(Guid id,Guid userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}