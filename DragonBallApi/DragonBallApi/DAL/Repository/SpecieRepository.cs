using DragonBallApi.Domain.DTO;
using DragonBallApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.DAL.Repository
{
    public class SpecieRepository
    {
        private readonly DragonBallContext _dragonBallContext;

        public SpecieRepository(DragonBallContext dragonBallContext)
        {
            _dragonBallContext = dragonBallContext;
        }

        public async Task<List<Species>> Search(int page, int qnt)
        {
            int qtaPaginasAnteriores = page * qnt;

            return await _dragonBallContext.Species.Skip(qtaPaginasAnteriores).Take(qnt).Include(x => x.CharacterSpecies).ThenInclude( x => x.Characters).ToListAsync();
        }

        public async Task<Species> SearchById(int id)
        {
            
            return await _dragonBallContext.Species.FindAsync(id);
        }

        
        public async Task<Species> Register(Species newSpecie)
        {
            _dragonBallContext.Species.Add(newSpecie);
            await _dragonBallContext.SaveChangesAsync(); 
            return newSpecie;
        }

        public Species Update(int id, Species model)
        {
            var result =  _dragonBallContext.Species.FirstOrDefault(x => x.Id == id);

            result.Name = model.Name;
            result.ImageUrl = model.ImageUrl;

            _dragonBallContext.Species.Add(result).State = EntityState.Modified;
            _dragonBallContext.SaveChanges();

            return model;
        }
    }
}
