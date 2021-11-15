using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API2.ModelDTOs;
using API2.Persistence.Entities;
using AutoMapper;

namespace API2.Controllers
{
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private LocalDBContext context;
        private  IMapper mapper;

        public TeamsController(LocalDBContext context, IMapper mapper)
        {
            this.context = (LocalDBContext)context;
            this.mapper = mapper;
        }

        [ProducesResponseType(typeof(IEnumerable<TeamDTO>), 200)]
        [HttpGet(Name = "GetAllTeams1")]
        public IActionResult GetAllTeams1()
        {
            if (context.Teams.Any())
            {
                BadRequest("No teams found");
            }

            List<TeamEntity> teamList = context.Teams.ToList();

            var result = mapper.Map<IEnumerable<TeamDTO>>(teamList);

            return Ok(result);
        }

        ////[MapToApiVersion("2.0")]
        //[ProducesResponseType(typeof(IEnumerable<TeamDTO>), 200)]
        //[HttpGet(Name = "GetAllTeams2")]
        //public IActionResult GetAllTeams2()
        //{
        //    if (context.Teams.Any())
        //    {
        //        BadRequest("No teams found");
        //    }

        //    List<TeamEntity> teamList = context.Teams.ToList();

        //    var result = mapper.Map<IEnumerable<TeamDTO>>(teamList);

        //    return Ok(result);
        //}

        [ProducesResponseType(201)]
        [HttpPost("{teamName}")]
        public IActionResult CreateTeam1(string teamName, [FromBody]List<PlayerDTO> playerNames)
        {
            if (context.Teams.Any(t => t.Name == teamName))
            {
                ModelState.AddModelError("Explanation", "Such team already exists");
            }

            if (context.Teams.Any(t => t.PlayerList.Equals(playerNames.Any())))
            {
                ModelState.AddModelError("Explanation", @"One of existing team already contains a member of your team.
                             Review all team lists and change composition of your new team accordingly");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newdto = new TeamDTO { Name = teamName, PlayerList = playerNames };
            var result = mapper.Map<TeamEntity>(newdto);
            context.Teams.Add(result);
            context.SaveChanges(true);

            return CreatedAtRoute("GetTeamById", new { id = result.TeamId }, null);
        }

        ////[MapToApiVersion("2.0")]
        //[ProducesResponseType(201)]
        //[HttpPost("{playerNames}")]
        //public IActionResult CreateTeam2(string teamName, [FromBody]List<PlayerDTO> playerNames)
        //{
        //    if (context.Teams.Any(t => t.Name == teamName))
        //    {
        //        ModelState.AddModelError("Explanation", "Such team already exists");
        //    }

        //    if (context.Teams.Any(t => t.PlayerList.Equals(playerNames.Any())))
        //    {
        //        ModelState.AddModelError("Player already in one of teams", @"One of existing team already contains a member of your team.
        //                     Review all team lists and change composition of your new team accordingly");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var newdto = new TeamDTO { Name = teamName, PlayerList = playerNames };
        //    var result = mapper.Map<TeamEntity>(newdto);
        //    context.Teams.Add(result);
        //    context.SaveChanges(true);

        //    return CreatedAtRoute("GetTeamById2", new { id = result.TeamId }, null);
        //}

        [ProducesResponseType(typeof(TeamDTO), 200)]
        [HttpGet("{id}", Name = "GetTeamById")]
        public IActionResult GetTeamById1(int id)
        {
            if (!context.Teams.Any(t => t.TeamId == id))
            {
                BadRequest("No such team exists");
            }

            var result = mapper.Map<TeamDTO>(context.Teams.Where(t => t.TeamId == id).FirstOrDefault());
            return Ok(result);
        }

        ////[MapToApiVersion("2.0")]
        //[ProducesResponseType(typeof(TeamDTO), 200)]
        //[HttpGet("{id}", Name = "GetTeamById2")]
        //public IActionResult GetTeamById2(int id)
        //{
        //    if (!context.Teams.Any(t => t.TeamId == id))
        //    {
        //        BadRequest("No such team exists");
        //    }
                        
        //    var result = mapper.Map<TeamDTO>(context.Teams.Where(t => t.TeamId == id).FirstOrDefault());
        //    return Ok(result);
        //}
    }
}
