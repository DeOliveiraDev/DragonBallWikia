using DragonBallApi.DAL.EFCore;
using DragonBallApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.DAL.Repository
{
    public class CharactersRepository
    {
        public readonly DragonBallContext _dragonBallContext;

        public CharactersRepository(DragonBallContext dragonBallContext)
        {
            _dragonBallContext = dragonBallContext;
        }

        public async Task<List<Characters>> SearchCharacters(int currentPage, int numberOfPage)
        {
            int skipPages = currentPage * numberOfPage;
            return await _dragonBallContext.Characters.Skip(skipPages).Take(numberOfPage).Include(x => x.OriginPlanet).Include(x => x.CharacterSpecies).ToListAsync();
        }

        public async Task<Characters> SearchCharacterById(int id)
        {
            return await _dragonBallContext.Characters.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Characters> SaveCharacters(Characters model)
        {
            _dragonBallContext.Characters.Add(model);
            await _dragonBallContext.SaveChangesAsync();
            return model;
        }

        public async Task<Characters> UpdateCharacterInfo(Characters model)
        {
            _dragonBallContext.Characters.Add(model).State = EntityState.Modified;
            await _dragonBallContext.SaveChangesAsync();

            return model;
        }
    }
}
