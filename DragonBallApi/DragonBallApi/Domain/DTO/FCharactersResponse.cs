using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class FCharactersResponse
    {
        public FCharactersResponse(Characters character)
        {
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
        public string Status { get; set; }
        public string Gender { get; set; }
        public string ImagePerfil { get; set; }
        public string BirthDate { get; set; }
        public string DeathDate { get; set; }

        public int OriginPlanetId { get; set; }
    }
}
