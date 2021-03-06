using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class CharactersUpdateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string ImagePerfil { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string DeathDate { get; set; }

        [Required]
        public int OriginPlanetId { get; set; }
    }
}
