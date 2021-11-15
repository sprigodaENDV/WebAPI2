using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.ModelDTOs
{
    public class MatchDTO
    {
        public int MatchId { get; set; }
        public string Location { get; set; }
        public TeamDTO TeamA { get; set; }
        public TeamDTO TeamB { get; set; }
        public int TeamAscore { get; set; }
        public int TeamBscore { get; set; }
        public int TimeInMinutes { get; set; }
    }
}
