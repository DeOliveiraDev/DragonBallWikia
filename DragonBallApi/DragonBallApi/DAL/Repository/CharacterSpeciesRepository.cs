using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.DAL.Repository
{
    public class CharacterSpeciesRepository
    {
        public readonly DragonBallContext _dragonBallContext;

        public CharacterSpeciesRepository(DragonBallContext dragonBallContext)
        {
            _dragonBallContext = dragonBallContext;
        }

        public async Task<CharacterSpecies> Register( CharacterSpecies model)
        {
            _dragonBallContext.CharacterSpecies.Add(model);
            await _dragonBallContext.SaveChangesAsync();
            return model;
        }
    }
}
