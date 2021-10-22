using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.Entity
{
    [Table("Character")]
    public class Characters
    {
        public Characters()
        {
            CharacterSpecies = new HashSet<CharacterSpecies>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public string ImagePerfil { get; set; }
        public string BirthDate { get; set; }
        public string DeathDate { get; set; }
        public int OriginPlanetId { get; set; }

        public virtual OriginPlanet OriginPlanet { get; set; }
        public virtual ICollection<CharacterSpecies> CharacterSpecies { get; set; }
    }
}
