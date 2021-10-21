using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class SpecieCreateRequest
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(400)]
        public string ImageUrl { get; set; }
    }
}
