using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API2.Persistence.Entities;
using AutoMapper;
using API2.ModelDTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API2.Controllers
{
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private LocalDBContext context;
        private IMapper mapper;

        public MatchesController(LocalDBContext context, IMapper mapper)
        {
            this.context = (LocalDBContext)context;
            this.mapper = mapper;
        }

        //[MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(IEnumerable<MatchDTO>), 200)]
        [HttpGet]
        public IActionResult GetMatches1()
        {
            if (!context.Matches.Any())
            {
                BadRequest("No matches happened yet");
            }

            List<MatchEntity> matchList = context.Matches.ToList();

            var result = mapper.Map<IEnumerable<MatchDTO>>(matchList);

            return Ok(result);
        }

        ////[MapToApiVersion("2.0")]
        //[ProducesResponseType(typeof(IEnumerable<MatchDTO>), 200)]
        //[HttpGet()]
        //public IActionResult GetMatches2()
        //{
        //    if (!context.Matches.Any())
        //    {
        //        BadRequest("No matches happened yet");
        //    }

        //    List<MatchEntity> matchList = context.Matches.ToList();

        //    var result = mapper.Map<IEnumerable<MatchDTO>>(matchList);

        //    return Ok(result);
        //}

        [ProducesResponseType(typeof(IEnumerable<MatchEntity>), 200)]
        [HttpGet("{playerName}")]
        public IActionResult GetMatchesByPlayer1(string playerName)
        { 
            bool playerParticipated =
            context.Matches.Any(m => m.TeamA.PlayerList.Any(p => p.Name == playerName) || m.TeamA.PlayerList.Any(p => p.Name == playerName));

            if (!playerParticipated)
            {
                ModelState.AddModelError("No such player played", "No matches with such player happened yet");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchesWithPlayer =
            context.Matches.Select(m => m.TeamA.PlayerList.Any(p => p.Name == playerName) || m.TeamA.PlayerList.Any(p => p.Name == playerName));

            var result = mapper.Map<IEnumerable<MatchDTO>>(matchesWithPlayer);
            return Ok(result);
        }
        
    }
}
