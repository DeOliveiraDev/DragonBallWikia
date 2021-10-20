using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class OriginPlanetResponse
    {
        public OriginPlanetResponse (OriginPlanet originPlanet)
        {
            Id = originPlanet.Id;
            Name = originPlanet.Name;
            ImageUrl = originPlanet.ImageUrl;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
