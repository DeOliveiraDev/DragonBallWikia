using DragonBallApi.DAL.Repository;
using DragonBallApi.Domain.DTO;
using DragonBallApi.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Services
{
    public class CharactersService
    {
        public readonly CharactersRepository _charactersRepository;
        public CharactersService(CharactersRepository charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }


        public async Task<ServiceResponse<List<CharactersResponse>>> SearchAllCharacters(int index, int quantity)
        {
            var charactersSearch = await _charactersRepository.SearchCharacters(index, quantity);
            var charactersSearchResult = charactersSearch.Select(x => new CharactersResponse(x)).ToList();

            return new ServiceResponse<List<CharactersResponse>>(charactersSearchResult);
        }
    }
}
