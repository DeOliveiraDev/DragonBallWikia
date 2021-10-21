using DragonBallApi.DAL;
using DragonBallApi.DAL.EFCore;
using DragonBallApi.DAL.Repository;
using DragonBallApi.Domain.DTO;
using DragonBallApi.Domain.Entity;
using DragonBallApi.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Services
{
    public class CharactersService
    {
        public readonly DragonBallContext _dragonBallContext;
        public readonly CharactersRepository _iRepository;

        public CharactersService(DragonBallContext dragonBallContext, CharactersRepository iRepository)
        {
            _iRepository = iRepository;
            _dragonBallContext = dragonBallContext;
        }


        public async Task<ServiceResponse<List<CharactersResponse>>> SearchAllCharacters(int index, int quantity)
        {
            
            var charactersSearch = await _iRepository.SearchCharacters(index, quantity);
            var charactersSearchResult = charactersSearch.Select(x => new CharactersResponse(x)).ToList();

            return new ServiceResponse<List<CharactersResponse>>(charactersSearchResult);
        }

        public async Task<ServiceResponse<CharactersResponse>> SearchCharactersById(int id)
        {
            var characterSearchResult = await _iRepository.SearchCharacterById(id);
            if (characterSearchResult == null)
            {
                return new ServiceResponse<CharactersResponse>("Não encontrado!");
            }

            return new ServiceResponse<CharactersResponse>(new CharactersResponse(characterSearchResult));
        }

        public async Task<ServiceResponse<CharactersResponse>> PostCharacters(CharactersCreateRequest PostModel)
        {
            var model = new Characters
            {
                Name = PostModel.Name,
                Status = PostModel.Status,
                Gender = PostModel.Gender,
                BirthDate = PostModel.BirthDate,
                DeathDate = PostModel.DeathDate,
                ImagePerfil = PostModel.ImagePerfil,
                OriginPlanetId = PostModel.OriginPlanetId
            };

            await _iRepository.SaveCharacters(model);

            return new ServiceResponse<CharactersResponse>(new CharactersResponse(model));
        }

        public async Task<ServiceResponse<CharactersResponse>> UpdateCharactersIfo(int id, CharactersUpdateRequest putModel)
        {
            var result = _dragonBallContext.Characters.FirstOrDefault(x => x.Id == id);

            if(result == null)
            {
                return new ServiceResponse<CharactersResponse>("Nenhum Personagem foi encontrado!");
            }

            result.Name = putModel.Name;
            result.Status = putModel.Status;
            result.Gender = putModel.Gender;
            result.BirthDate = putModel.BirthDate;
            result.DeathDate = putModel.DeathDate;
            result.ImagePerfil = putModel.ImagePerfil;
            result.OriginPlanetId = putModel.OriginPlanetId;

            await _iRepository.UpdateCharacterInfo(result);

            return new ServiceResponse<CharactersResponse>(new CharactersResponse(result));
        }
    }
}
