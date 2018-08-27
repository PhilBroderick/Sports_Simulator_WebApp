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
                CreateRounds(league);
            }
        }

        //public List<LeagueEntry> PopulateLeagueEntries(League league)
        //{

        //}

        public List<List<Matchup>> CreateRounds(League league)
        {
            Round rounds = new Round();
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
                    firstMatchup.MatchupRound = roundNumber + 1;
                    round.Add(firstMatchup);

                    for (var idx = 1; idx < numberOfMatchesInARound; idx++)
                    {
                        Matchup nextMatchup = new Matchup();

                        var firstTeamIndex = (roundNumber + idx) % numberOfTeams;
                        var secondteamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;

                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[firstTeamIndex].TeamId });
                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[secondteamIndex].TeamId });
                        nextMatchup.MatchupRound = roundNumber + 1;
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
                    firstMatchup.MatchupRound = roundNumber + 1;
                    round.Add(firstMatchup);

                    for (var idx = 1; idx < numberOfMatchesInARound; idx++)
                    {
                        Matchup nextMatchup = new Matchup();

                        var firstTeamIndex = (roundNumber + idx) % numberOfTeams;
                        var secondteamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;

                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[firstTeamIndex].TeamId });
                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[secondteamIndex].TeamId });
                        nextMatchup.MatchupRound = roundNumber + 1;
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
                    firstMatchup.MatchupRound = roundNumber + 1;
                    round.Add(firstMatchup);

                    for (var idx = 1; idx < numberOfMatchesInARound; idx++)
                    {
                        Matchup nextMatchup = new Matchup();

                        var firstTeamIndex = (roundNumber + idx) % numberOfTeams;
                        var secondteamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;

                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[firstTeamIndex].TeamId });
                        nextMatchup.MatchupEntries.Add(new MatchupEntry { TeamCompetingId = teamList[secondteamIndex].TeamId });
                        nextMatchup.MatchupRound = roundNumber + 1;
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

            matchups = CreateRounds(league);

            foreach (List<Matchup> mList in matchups)
            {
                foreach (Matchup m in mList)
                {
                    output.Add(new Round { MatchupId = m.id, RoundNumber = m.MatchupRound });
                }
            }
            return output;
        }

        //public void RandomiseRounds(League league)
        //{
        //    Random rng = new Random();
        //    int n = league.Rounds.Count;
        //    List<Round> rounds = new List<Round>();
        //    rounds = league.Rounds.ToArray()

        //    while(n > 1)
        //    {
        //        n--;
        //        int k = rng.Next(n + 1);
        //        List<Matchup> value = league.Rounds[k];
                  
        //    }
        //}

    }
}