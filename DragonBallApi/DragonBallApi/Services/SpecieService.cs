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
    public class SpecieService
    {
        private readonly SpecieRepository _specieRepository;

        public SpecieService(SpecieRepository specieRepository)
        {
            _specieRepository = specieRepository;
        }

		public async Task<ServiceResponse<List<SpecieResponse>>> Search(int pageIndex, int qtdPage)
		{
			if (pageIndex < 0)
			{
				return new ServiceResponse<List<SpecieResponse>>("O indice da página atual deve começar em 0");
			}

			if (qtdPage < 1 || qtdPage > 50)
			{
				return new ServiceResponse<List<SpecieResponse>>("Quantidade de itens por página deve ser entre 1 e 50 itens");
			}


			var list = await _specieRepository.Search(pageIndex, qtdPage);
			var listConvert = list.Select(x => new SpecieResponse(x)).ToList();

			return new ServiceResponse<List<SpecieResponse>>(listConvert);
		}

		public async Task<ServiceResponse<SpecieResponse>> SearchById(int id)
		{
			var specie = await _specieRepository.SearchById(id);
			if (specie != null)
			{
				return new ServiceResponse<SpecieResponse>(new SpecieResponse(specie));
			}
			return new ServiceResponse<SpecieResponse>("Not Found");
		}

		
		public async Task<ServiceResponse<SpecieResponse>> Register(SpecieCreateRequest newSpecie)
		{
			var model = new Species
			{
				Name = newSpecie.Name,
				ImageUrl = newSpecie.ImageUrl
			};

			await _specieRepository.Register(model);

			return new ServiceResponse<SpecieResponse>(new SpecieResponse(model));
		}

		public  ServiceResponse<Species> Update(int id, SpecieCreateRequest model)
		{
			var newModel = new Species
			{
				Name = model.Name,
				ImageUrl = model.ImageUrl
			};

			var result = _specieRepository.Update(id, newModel);

			return new ServiceResponse<Species>(newModel);
		}
	}
}
