using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.Entity
{
    [Table("Character")]
    public class Character
    {
        public Character()
        {
            CharacterSpecies = new HashSet<CharacterSpecies>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Gender { get; set; }
        public string ImagePerfil { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathTime { get; set; }
        public int OriginPlanetId { get; set; }

        public virtual OriginPlanet OriginPlanet { get; set; }
        public virtual ICollection<CharacterSpecies> CharacterSpecies { get; set; }

    }
}
