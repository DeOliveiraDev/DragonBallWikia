using DragonBallApi.DAL.Repository;
using DragonBallApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Services
{
    public class CharacterSpeciesService
    {
        private readonly CharacterSpeciesRepository _characterSpecieRepository;

        public CharacterSpeciesService(CharacterSpeciesRepository characterSpecieRepository)
        {
            _characterSpecieRepository = characterSpecieRepository;
        }


        public async  Task Register(int idCharacter, List<int> idSpecie)
        {

            
            

            for(int i = 0; i < idSpecie.Count(); i++)
            {
                var model = new CharacterSpecies();
                model.CharacterId = idCharacter;
                model.SpecieId = idSpecie[i];

                await  _characterSpecieRepository.Register(model);
            }

            
        }
    }
}
