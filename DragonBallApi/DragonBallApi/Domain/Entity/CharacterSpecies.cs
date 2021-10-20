using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.Entity
{
    [Table("CharacterSpecies")]
    public class CharacterSpecies
    {
        [Key]
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int SpecieId { get; set; }
        
        public virtual Characters Characters { get; set; }
        public virtual Species Species { get; set; }

    }
}
