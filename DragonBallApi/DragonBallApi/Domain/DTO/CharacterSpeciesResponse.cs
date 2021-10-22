using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class CharacterSpeciesResponse
    {
        public CharacterSpeciesResponse(CharacterSpecies characterSpecies)
        {
            Id = characterSpecies.Id;
            CharacterId = characterSpecies.CharacterId;
            SpecieId = characterSpecies.SpecieId;
        }
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int SpecieId { get; set; }
    }
}
