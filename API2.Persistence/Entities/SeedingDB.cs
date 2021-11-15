using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Persistence.Entities
{
    public class SeedingDB
    {
        public SeedingDB(LocalDBContext context)
        {
            this.context = context;
        }

        private LocalDBContext context;


        public void AddMatchEntity(MatchEntity match)
        {
            context.Matches.Add((MatchEntity)match);
        }


        public void SeedDB()
        {
            var anyTeam = context.Teams.FirstOrDefault();
            if (anyTeam == null)
            {
                context.Teams.Add(new TeamEntity { Name = "CF Montréal" });
                context.Teams.Add(new TeamEntity { Name = "Orlando City SC" });
                context.Teams.Add(new TeamEntity { Name = "Columbus Crew" });
                context.Teams.Add(new TeamEntity { Name = "Chicago Fire FC" });
                context.Teams.Add(new TeamEntity { Name = "FC Cincinnati" });
                context.Teams.Add(new TeamEntity { Name = "Atlanta United FC" });
                context.Teams.Add(new TeamEntity { Name = "Nashville SC" });
                context.Teams.Add(new TeamEntity { Name = "New York Red Bulls" });
                context.Teams.Add(new TeamEntity { Name = "New England Revolution " });
                context.Teams.Add(new TeamEntity { Name = "Inter Miami CF" });
                context.Teams.Add(new TeamEntity { Name = "New York City FC " });
                context.Teams.Add(new TeamEntity { Name = "Philadelphia Union" });
                context.SaveChanges();
            }

            var anyMatch = context.Matches.FirstOrDefault();
            if (anyMatch == null)
            {
                AddMatchEntity(
                new MatchEntity()
                {
                    TeamA = new TeamEntity() { Name = "New York City FC", PlayerList = new List<PlayerEntity>() },
                    TeamB = new TeamEntity() { Name = "Philadelphia Union", PlayerList = new List<PlayerEntity>() },
                    Location = "Yankee Stadium, New York",
                    TeamAscore = 1,
                    TeamBscore = 1,
                    TimeInMinutes = 34
                });

                AddMatchEntity(
                new MatchEntity()
                {
                    TeamA = new TeamEntity() { Name = "Columbus Crew", PlayerList = new List<PlayerEntity>() },
                    TeamB = new TeamEntity() { Name = "Chicago Fire FC", PlayerList = new List<PlayerEntity>() },
                    Location = "Lower.com Field, Columbus, OH",
                    TeamAscore = 2,
                    TeamBscore = 0,
                    TimeInMinutes = 38
                });

                AddMatchEntity(
                new MatchEntity()
                {
                    TeamA = new TeamEntity() { Name = "FC Cincinnati", PlayerList = new List<PlayerEntity>() },
                    TeamB = new TeamEntity() { Name = "Atlanta United FC", PlayerList = new List<PlayerEntity>() },
                    Location = "TQL Stadium, Cincinnati, OH",
                    TeamAscore = 1,
                    TeamBscore = 2,
                    TimeInMinutes = 56
                });

                AddMatchEntity(
                new MatchEntity()
                {
                    TeamA = new TeamEntity() { Name = "Nashville SC", PlayerList = new List<PlayerEntity>() },
                    TeamB = new TeamEntity() { Name = "New York Red Bulls", PlayerList = new List<PlayerEntity>() },
                    Location = "Nissan Stadium, Nashville, Nashville, TN",
                    TeamAscore = 1,
                    TeamBscore = 1,
                    TimeInMinutes = 58
                });

                AddMatchEntity(
                new MatchEntity()
                {
                    TeamA = new TeamEntity() { Name = "New England Revolution ", PlayerList = new List<PlayerEntity>() },
                    TeamB = new TeamEntity() { Name = "Inter Miami CF", PlayerList = new List<PlayerEntity>() },
                    Location = "Gillette Stadium, Foxborough",
                    TeamAscore = 0,
                    TeamBscore = 1,
                    TimeInMinutes = 47
                });

                AddMatchEntity(
                new MatchEntity()
                {
                    TeamA = new TeamEntity() { Name = "New York City FC ", PlayerList = new List<PlayerEntity>() },
                    TeamB = new TeamEntity() { Name = "Philadelphia Union", PlayerList = new List<PlayerEntity>() },
                    Location = "Yankee Stadium, New York",
                    TeamAscore = 1,
                    TeamBscore = 1,
                    TimeInMinutes = 14
                });


                context.SaveChanges();
            }
        }  
    }
}
