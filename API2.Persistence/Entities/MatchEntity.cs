using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Persistence.Entities
{
    public class MatchEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]     
        [Key]
        public int MatchId { get; set; }
        public string Location { get; set; }
        public TeamEntity TeamA { get; set; }
        public TeamEntity TeamB { get; set; }
        public int TeamAscore { get; set; }
        public int TeamBscore { get; set; }
        public int TimeInMinutes { get; set; }
    }
}
