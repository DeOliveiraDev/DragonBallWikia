using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.DAL.EFCore
{
    public interface ICharactersRepository
    {
        public Task<List<Characters>> SearchCharacters(int currentPage, int numberOfPage);

        public Task<Characters> SearchCharacterById(int id);

        public Task<Characters> SaveCharacters(Characters model);

        public Task<Characters> UpdateCharacterInfo(Characters model);

    }
}
