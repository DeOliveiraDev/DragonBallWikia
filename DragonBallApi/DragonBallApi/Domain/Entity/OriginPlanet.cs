using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.Entity
{
    [Table("OriginPlanet")]
    public class OriginPlanet
    {
        public OriginPlanet()
        {
            Characters = new HashSet<Characters>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Characters> Characters { get; set; }
    }
}
