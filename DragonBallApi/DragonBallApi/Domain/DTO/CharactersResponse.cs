using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class CharactersResponse
    {
        public CharactersResponse(Characters character) {
            Id = character.Id;
            Name = character.Name;
            Status = character.Status;
            Gender = character.Gender;
            ImagePerfil = character.ImagePerfil;
            BirthDate = character.BirthDate;
            DeathDate = character.DeathDate;
            OriginPlanetId = character.OriginPlanetId;

            if (character.CharacterSpecies != null && character.CharacterSpecies.Any())
            {
                CharacterSpecies = new List<CharacterSpecies>();
                CharacterSpecies.AddRange(character.CharacterSpecies.Select(x => new CharacterSpecies()));
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public string ImagePerfil { get; set; }
        public string BirthDate { get; set; }
        public string DeathDate { get; set; }

        public int OriginPlanetId { get; set; }

        public List<CharacterSpecies> CharacterSpecies { get; set; }

    }
}
