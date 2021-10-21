using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonBallApi.Domain.Entity;

namespace DragonBallApi.Domain.DTO
{
    public class CoverImageResponse
    {
        public CoverImageResponse(CoverImage coverImage)
        {
            Id = coverImage.Id;
            ImageUrl = coverImage.ImageUrl;
        }

        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
