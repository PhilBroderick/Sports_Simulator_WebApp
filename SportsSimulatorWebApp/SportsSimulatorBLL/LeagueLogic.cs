using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public class LeagueLogic
    {
        public void CreateLeague(League league)
        {
            //PopulateLeagueEntries(league);

            if(league.LeagueEntries != null)
            {
                List<List<Matchup>> output = new List<List<Matchup>>();

                output = CreateRounds(league);

                league.Rounds = AddMatchupsToRounds(output, league);

                RandomiseRounds(league);

                SaveLeagueRounds(league);
            }
        }

        //TODO - Call when hitting 'Add teams' on LeagueEntries controller
        private void PopulateLeagueEntries(League league)
        {
            foreach (LeagueEntry entry in league.LeagueEntries)
            {
                using (var context = new SportsSimulatorDBEntities())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter id = new System.Data.Entity.Core.Objects.ObjectParameter("id", typeof(Int32));
                    entry.id = context.spLeagueEntries_Insert(league.id, entry.TeamId, id);
                }
            }
        }

        private void SaveLeagueRounds(League league)
        {
            foreach (Round round in league.Rounds)
            {
                foreach (Matchup matchup in round.Matchup)
                {
                    using (var context = new SportsSimulatorDBEntities())
                    {
                        //TODO - Create Stored procedure
                        System.Data.Entity.Core.Objects.ObjectParameter id = new System.Data.Entity.Core.Objects.ObjectParameter("id", typeof(Int32));
                        context.spRounds_Insert(league.id, round.RoundNumber, matchup.id, id);

                        round.id = Convert.ToInt32(id.Value);
                    }

                    using (var context = new SportsSimulatorDBEntities())
                    {
                        System.Data.Entity.Core.Objects.ObjectParameter id = new System.Data.Entity.Core.Objects.ObjectParameter("id", typeof(Int32));
                        context.spMatchups_Insert(league.id, round.RoundNumber, id);

                        matchup.id = Convert.ToInt32(id.Value);
                    }
                    foreach (MatchupEntry entry in matchup.MatchupEntries)
                    {
                        using (var context = new SportsSimulatorDBEntities())
                        {
                            //Cannot insert null into ParentMatchupId
                            System.Data.Entity.Core.Objects.ObjectParameter id = new System.Data.Entity.Core.Objects.ObjectParameter("id", typeof(Int32));
                            context.spMatchupEntries_Insert(matchup.id, matchup.id, entry.TeamCompetingId, id);

                            entry.id = Convert.ToInt32(id.Value);
                        }
                    }
                }
            }
        }

        public List<List<Matchup>> CreateRounds(League league)
        {
            List<List<Matchup>> matchups = new List<List<Matchup>>();

            int numberOfRounds = (league.LeagueEntries.Count - 1);
            int numberOfMatchesInARound = league.LeagueEntries.Count / 2;

            List<LeagueEntry> teamList = new List<LeagueEntry>();

            teamList.AddRange(league.LeagueEntries.Skip(numberOfMatchesInARound).Take(numberOfMatchesInARound));
            teamList.AddRange(league.LeagueEntries.Skip(1).Take(numberOfMatchesInARound - 1).ToArray().Reverse());

            int numberOfTeams = teamList.Count;

            for (int roundNumber = 0; roundNumber < numberOfRounds * 2; roundNumber++)
            {
                if(roundNumber == 0)
                {
                    List<Matchup> round = new List<Matchup>();
                    int teamIdx = roundNumber % numberOfTeams;

                    Matchup firstMatchup = new Matchup();
                    //TODO - Make TeamId field required
                    firstMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = league.LeagueEntries.First().TeamId });
                    firstMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[teamIdx].TeamId });
                    //firstMatchup.MatchupRound = roundNumber + 1;
                    round.Add(firstMatchup);

                    for (var idx = 1; idx < numberOfMatchesInARound; idx++)
                    {
                        Matchup nextMatchup = new Matchup();

                        var firstTeamIndex = (roundNumber + idx) % numberOfTeams;
                        var secondteamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;

                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[firstTeamIndex].TeamId });
                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[secondteamIndex].TeamId });
                        //nextMatchup.MatchupRound = roundNumber + 1;
                        round.Add(nextMatchup);
                    }
                    matchups.Add(round);
                }
                else if (numberOfRounds * 2 / roundNumber < 2 )
                {
                    List<Matchup> round = new List<Matchup>();
                    int teamIdx = roundNumber % numberOfTeams;

                    Matchup firstMatchup = new Matchup();
                    //TODO - Make TeamId field required
                    firstMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = league.LeagueEntries.First().TeamId });
                    firstMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[teamIdx].TeamId });
                    //firstMatchup.MatchupRound = roundNumber + 1;
                    round.Add(firstMatchup);

                    for (var idx = 1; idx < numberOfMatchesInARound; idx++)
                    {
                        Matchup nextMatchup = new Matchup();

                        var firstTeamIndex = (roundNumber + idx) % numberOfTeams;
                        var secondteamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;

                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[firstTeamIndex].TeamId });
                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[secondteamIndex].TeamId });
                       // nextMatchup.MatchupRound = roundNumber + 1;
                        round.Add(nextMatchup);
                    }
                    matchups.Add(round);
                }
                else if (numberOfRounds * 2 / roundNumber >= 2)
                {
                    List<Matchup> round = new List<Matchup>();
                    int teamIdx = roundNumber % numberOfTeams;

                    Matchup firstMatchup = new Matchup();

                    firstMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[teamIdx].TeamId });
                    firstMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = league.LeagueEntries.First().TeamId });
                   // firstMatchup.MatchupRound = roundNumber + 1;
                    round.Add(firstMatchup);

                    for (var idx = 1; idx < numberOfMatchesInARound; idx++)
                    {
                        Matchup nextMatchup = new Matchup();

                        var firstTeamIndex = (roundNumber + idx) % numberOfTeams;
                        var secondteamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;

                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[firstTeamIndex].TeamId });
                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[secondteamIndex].TeamId });
                      //  nextMatchup.MatchupRound = roundNumber + 1;
                        round.Add(nextMatchup);
                    }
                    matchups.Add(round);
                }
            }
            return matchups;
        }
        public List<Round> AddMatchupsToRounds(List<List<Matchup>> matchups, League league)
        {
            List<Round> output = new List<Round>();
            
            foreach (List<Matchup> mList in matchups)
            {
                output.Add(new Round { Matchup = mList });
            }
            return output;
        }

        public void RandomiseRounds(League league)
        {
            //Uses Fisher-Yates shuffle
            Random rng = new Random();
            int n = league.Rounds.Count;
            int roundNumber = 1;

            List<Round> rounds = league.Rounds.ToList();

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Round value = rounds[k];
                rounds[k] = rounds[n];
                rounds[n] = value;
            }

            foreach(Round round in rounds)
            {
                round.RoundNumber = roundNumber;
                foreach(Matchup matchup in round.Matchup)
                {
                    matchup.MatchupRound = round.id;
                }
                roundNumber += 1;
            }
            

            league.Rounds = rounds;
        }

    }
}