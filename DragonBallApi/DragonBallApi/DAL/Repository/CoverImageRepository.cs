using DragonBallApi.Domain.DTO;
using DragonBallApi.Domain.Entity;
using DragonBallApi.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.DAL.Repository
{
	public class CoverImageRepository
	{
		private readonly DragonBallContext _dbContext;

		public CoverImageRepository(DragonBallContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<CoverImage>> SearchCoverImage(int currentPage, int numberOfPage)
        {
			int skipPages = currentPage * numberOfPage;
			return await _dbContext.CoverImage.Skip(skipPages).Take(numberOfPage).ToListAsync();
        }

		public async Task<CoverImage> PesquisaPorId(int id)
		{
			return await _dbContext.CoverImage.FindAsync(id);
		}

		public async Task<CoverImage> Cadastrar(CoverImage novo)
		{
			_dbContext.CoverImage.Add(novo);
			await _dbContext.SaveChangesAsync();
			return novo;
		}

		public async Task<CoverImage> Editar(CoverImage model)
        {
			_dbContext.CoverImage.Add(model).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return model;
        }
	}
}
