using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.Entity
{
    [Table("CoverImage")]
    public class CoverImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
