using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class CharactersResponse
    {
        public CharactersResponse(Character character) {
            Id = character.Id;
            Name = character.Name;
            Status = character.Status;
            Gender = character.Gender;
            ImagePerfil = character.ImagePerfil;
            BirthDate = character.BirthDate;
            DeathDate = character.DeathDate;
            OriginPlanetId = character.OriginPlanetId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Gender { get; set; }
        public string ImagePerfil { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public int OriginPlanetId { get; set; }
    }
}
