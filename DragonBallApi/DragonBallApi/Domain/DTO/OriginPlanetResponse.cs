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

            if(originPlanet.Characters != null && originPlanet.Characters.Any())
            {
                Characters = new List<CharactersResponse>();
                Characters.AddRange(originPlanet.Characters.Select(x => new CharactersResponse(x)));
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public List<CharactersResponse> Characters { get; set; }
    }
}
