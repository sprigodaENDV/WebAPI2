using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API2.Persistence.Entities;

namespace API2.Persistence.Entities
{
    public class TeamEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }

        public List<PlayerEntity> PlayerList { get; set; }
    }
}
