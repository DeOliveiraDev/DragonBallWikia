using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class SpecieResponse
    {
        public SpecieResponse(Species model)
        {
            Id = model.Id;
            Name = model.Name;
            ImageUrl = model.ImageUrl;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
