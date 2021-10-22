using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.Entity
{
    [Table("Species")]
    public class Species
    {
        public Species()
        {
            CharacterSpecies = new HashSet<CharacterSpecies>();
        }



        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<CharacterSpecies> CharacterSpecies { get; set; }
    }
}
