using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class CharacterSpeciesResponse
    {
        public CharacterSpeciesResponse(CharacterSpecies model)
        {
            Species = new FSpecieResponse(model.Species);
        }


        public virtual FSpecieResponse Species { get; set; }
    }
}
