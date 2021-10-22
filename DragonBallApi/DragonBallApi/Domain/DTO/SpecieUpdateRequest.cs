using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.DTO
{
    public class SpecieUpdateRequest
    {
        [Required(ErrorMessage = "The field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string ImageUrl { get; set; }
    }
}
