using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Domain.Entity
{
    public class CharacterSpecies
    {
       public int ID { get; set; }
        public int CharacterId { get; set; }
        public int SpecieId { get; set; }
    }
}
