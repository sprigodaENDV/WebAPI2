using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.ModelDTOs
{
    public class TeamDTO
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public List<PlayerDTO> PlayerList { get; set; }
    }
}
