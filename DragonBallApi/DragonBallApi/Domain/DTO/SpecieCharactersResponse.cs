using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class SpecieCharactersResponse
    {
        public SpecieCharactersResponse(CharacterSpecies model)
        {
            Characters = new FCharactersResponse(model.Characters);
        }


        public virtual FCharactersResponse Characters { get; set; }
    }
}
