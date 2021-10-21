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
    public class CoverImageService
    {
        public readonly CoverImageRepository _coverImageRepository;
        public readonly DragonBallContext _dbContext;
        public CoverImageService(CoverImageRepository coverImageRepository, DragonBallContext dbContext)
        {
            _coverImageRepository = coverImageRepository;
            _dbContext = dbContext;
        }


        public async Task<ServiceResponse<List<CoverImageResponse>>> SearchAllCoverImages(int index, int quantity)
        {
            var coverImageSearch = await _coverImageRepository.SearchCoverImage(index, quantity);
            var coverImageSearchResult = coverImageSearch.Select(x => new CoverImageResponse(x)).ToList();

            return new ServiceResponse<List<CoverImageResponse>>(coverImageSearchResult);
        }

        public async Task<ServiceResponse<CoverImageResponse>> PesquisaPorId(int id)
        {
            var coverImage = await _coverImageRepository.PesquisaPorId(id);
            if (coverImage != null)
            {
                return new ServiceResponse<CoverImageResponse>(new CoverImageResponse(coverImage));
            }
            return new ServiceResponse<CoverImageResponse>("Not Found");
        }

        public async Task<ServiceResponse<CoverImageResponse>> Cadastrar(CICreateRequest novo)
        {
            var modeloDb = new CoverImage
            {
                ImageUrl = novo.ImageUrl,
               
            };

            await _coverImageRepository.Cadastrar(modeloDb);

            return new ServiceResponse<CoverImageResponse>(new CoverImageResponse(modeloDb));
        }

        public async Task<ServiceResponse<CoverImage>> Editar(int id, CIUpdateRequest model)
        {
            var resultado = _dbContext.CoverImage.FirstOrDefault(x => x.Id == id);

            if (resultado == null)
                return new ServiceResponse<CoverImage>("Not found!");

            resultado.ImageUrl = (model.ImageUrl);

            await _coverImageRepository.Editar(resultado);

            return new ServiceResponse<CoverImage>(resultado);
        }

    }
}
