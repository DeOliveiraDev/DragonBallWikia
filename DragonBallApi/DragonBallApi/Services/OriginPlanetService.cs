using DragonBallApi.DAL;
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
    public class OriginPlanetService
    {
        private readonly OriginPlanetRepository _originPlanetRepository;
        private readonly DragonBallContext _dragonBallContext;

        public OriginPlanetService(OriginPlanetRepository originPlanetRepository, DragonBallContext dragonBallContext)
        {
            _originPlanetRepository = originPlanetRepository;
            _dragonBallContext = dragonBallContext;
        }

        public async Task<ServiceResponse<OriginPlanetResponse>> SearchById(int id)
        {
            var originPlanet = await _originPlanetRepository.SearchById(id);

            if (originPlanet != null)
                return new ServiceResponse<OriginPlanetResponse>(new OriginPlanetResponse(originPlanet));
            return new ServiceResponse<OriginPlanetResponse>("Id not found!");
        }

        public async Task<ServiceResponse<List<OriginPlanetResponse>>> Search (int currentPage, int numberOfPage)
        {
            if (currentPage < 0)
                return new ServiceResponse<List<OriginPlanetResponse>>("The current page index must start at 0");
            if (numberOfPage < 1 || numberOfPage > 30)
                return new ServiceResponse<List<OriginPlanetResponse>>("Quantity of items per page must be between 1 and 50 items!");

            var searchList = await _originPlanetRepository.Search(currentPage, numberOfPage);
            var convertedList = searchList.Select(x => new OriginPlanetResponse(x)).ToList();

            return new ServiceResponse<List<OriginPlanetResponse>>(convertedList);
        }

        public async Task<ServiceResponse<OriginPlanet>> Register (OriginPlanetCreateRequest newOriginPlanet)
        {
            var modelDB = new OriginPlanet
            {
                Name = newOriginPlanet.Name,
                ImageUrl = newOriginPlanet.ImageUrl
            };
            await _originPlanetRepository.Register(modelDB);

            return new ServiceResponse<OriginPlanet>(modelDB);
        }

        public async Task<ServiceResponse<OriginPlanet>> Update (int id , OriginPlanetUpdateRequest model)
        {
            var result = _dragonBallContext.OriginPlanet.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return new ServiceResponse<OriginPlanet>("Id not found!");

            result.Name = model.Name;
            result.ImageUrl = model.ImageUrl;

            await _originPlanetRepository.Update(result);
            return new ServiceResponse<OriginPlanet>(result);
        }
    }
}
