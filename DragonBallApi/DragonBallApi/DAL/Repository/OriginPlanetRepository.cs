using DragonBallApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.DAL.Repository
{
    public class OriginPlanetRepository
    {
        private readonly DragonBallContext _dragonBallContex;
        public OriginPlanetRepository(DragonBallContext dragonBallContext)
        {
            _dragonBallContex = dragonBallContext;
        }


        public async Task<OriginPlanet> SearchById(int id)
        {
            return await _dragonBallContex.OriginPlanet.FindAsync(id);
        }

        public async Task<List<OriginPlanet>> Search (int currentPage,  int numberOfPage)
        {
            int amtPagePrevious = currentPage * numberOfPage;
            return await _dragonBallContex.OriginPlanet.Skip(amtPagePrevious).Take(numberOfPage).ToListAsync();
        } 

        public async Task<OriginPlanet> Register(OriginPlanet newModel)
        {
            _dragonBallContex.OriginPlanet.Add(newModel);
            await _dragonBallContex.SaveChangesAsync();
            return newModel;
        }

        public async Task<OriginPlanet> Update(OriginPlanet model)
        {
            _dragonBallContex.OriginPlanet.Add(model).State = EntityState.Modified;
            await _dragonBallContex.SaveChangesAsync();
            return model;
        }
    }
}
