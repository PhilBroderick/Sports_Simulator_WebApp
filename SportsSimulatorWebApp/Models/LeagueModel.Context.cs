﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportsSimulatorWebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SportsSimulatorDBEntities : DbContext
    {
        public SportsSimulatorDBEntities()
            : base("name=SportsSimulatorDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<LeagueEntry> LeagueEntries { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<MatchupEntry> MatchupEntries { get; set; }
        public virtual DbSet<Matchup> Matchups { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<EventTiming> EventTimings { get; set; }
        public virtual DbSet<Event> Events { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int spLeagueEntries_Insert(Nullable<int> leagueId, Nullable<int> teamId, ObjectParameter id)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spLeagueEntries_Insert", leagueIdParameter, teamIdParameter, id);
        }
    
        public virtual ObjectResult<spMatchupEntries_GetByMatchup_Result> spMatchupEntries_GetByMatchup(Nullable<int> matchupId)
        {
            var matchupIdParameter = matchupId.HasValue ?
                new ObjectParameter("MatchupId", matchupId) :
                new ObjectParameter("MatchupId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spMatchupEntries_GetByMatchup_Result>("spMatchupEntries_GetByMatchup", matchupIdParameter);
        }
    
        public virtual int spMatchupEntries_Insert(Nullable<int> matchupId, Nullable<int> teamCompetingId, ObjectParameter id)
        {
            var matchupIdParameter = matchupId.HasValue ?
                new ObjectParameter("MatchupId", matchupId) :
                new ObjectParameter("MatchupId", typeof(int));
    
            var teamCompetingIdParameter = teamCompetingId.HasValue ?
                new ObjectParameter("TeamCompetingId", teamCompetingId) :
                new ObjectParameter("TeamCompetingId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spMatchupEntries_Insert", matchupIdParameter, teamCompetingIdParameter, id);
        }
    
        public virtual ObjectResult<spMatchups_GetByLeague_Result> spMatchups_GetByLeague(Nullable<int> leagueId)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spMatchups_GetByLeague_Result>("spMatchups_GetByLeague", leagueIdParameter);
        }
    
        public virtual int spMatchups_Insert(Nullable<int> roundId, ObjectParameter id)
        {
            var roundIdParameter = roundId.HasValue ?
                new ObjectParameter("RoundId", roundId) :
                new ObjectParameter("RoundId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spMatchups_Insert", roundIdParameter, id);
        }
    
        public virtual ObjectResult<spPlayer_GetById_Result> spPlayer_GetById(Nullable<int> playerId)
        {
            var playerIdParameter = playerId.HasValue ?
                new ObjectParameter("PlayerId", playerId) :
                new ObjectParameter("PlayerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spPlayer_GetById_Result>("spPlayer_GetById", playerIdParameter);
        }
    
        public virtual int spPlayers_Insert(string firstName, string lastName, Nullable<decimal> playerRating, string position, ObjectParameter id)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var playerRatingParameter = playerRating.HasValue ?
                new ObjectParameter("PlayerRating", playerRating) :
                new ObjectParameter("PlayerRating", typeof(decimal));
    
            var positionParameter = position != null ?
                new ObjectParameter("Position", position) :
                new ObjectParameter("Position", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spPlayers_Insert", firstNameParameter, lastNameParameter, playerRatingParameter, positionParameter, id);
        }
    
        public virtual ObjectResult<spRounds_GetByLeague_Result> spRounds_GetByLeague(Nullable<int> leagueId)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spRounds_GetByLeague_Result>("spRounds_GetByLeague", leagueIdParameter);
        }
    
        public virtual int spRounds_Insert(Nullable<int> leagueId, Nullable<int> roundNumber, ObjectParameter id)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            var roundNumberParameter = roundNumber.HasValue ?
                new ObjectParameter("RoundNumber", roundNumber) :
                new ObjectParameter("RoundNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spRounds_Insert", leagueIdParameter, roundNumberParameter, id);
        }
    
        public virtual int spTeam_GetById(Nullable<int> teamId)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spTeam_GetById", teamIdParameter);
        }
    
        public virtual ObjectResult<TeamMember> spTeamMembers_GetByTeam(Nullable<int> teamId)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TeamMember>("spTeamMembers_GetByTeam", teamIdParameter);
        }
    
        public virtual ObjectResult<TeamMember> spTeamMembers_GetByTeam(Nullable<int> teamId, MergeOption mergeOption)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TeamMember>("spTeamMembers_GetByTeam", mergeOption, teamIdParameter);
        }
    
        public virtual int spTeamMembers_Insert(Nullable<int> teamId, Nullable<int> playerId, ObjectParameter id)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            var playerIdParameter = playerId.HasValue ?
                new ObjectParameter("PlayerId", playerId) :
                new ObjectParameter("PlayerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spTeamMembers_Insert", teamIdParameter, playerIdParameter, id);
        }
    
        public virtual ObjectResult<spTeams_GetByLeague_Result> spTeams_GetByLeague(Nullable<int> leagueId)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spTeams_GetByLeague_Result>("spTeams_GetByLeague", leagueIdParameter);
        }
    
        public virtual int spTeams_Insert(string teamName, ObjectParameter id)
        {
            var teamNameParameter = teamName != null ?
                new ObjectParameter("TeamName", teamName) :
                new ObjectParameter("TeamName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spTeams_Insert", teamNameParameter, id);
        }
    
        public virtual ObjectResult<spEventTimings_GetByMatchup_Result> spEventTimings_GetByMatchup(Nullable<int> matchupId)
        {
            var matchupIdParameter = matchupId.HasValue ?
                new ObjectParameter("MatchupId", matchupId) :
                new ObjectParameter("MatchupId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spEventTimings_GetByMatchup_Result>("spEventTimings_GetByMatchup", matchupIdParameter);
        }
    
        public virtual int spEventTimings_Insert(Nullable<int> matchupId, Nullable<System.TimeSpan> eventTime, Nullable<int> eventId)
        {
            var matchupIdParameter = matchupId.HasValue ?
                new ObjectParameter("MatchupId", matchupId) :
                new ObjectParameter("MatchupId", typeof(int));
    
            var eventTimeParameter = eventTime.HasValue ?
                new ObjectParameter("EventTime", eventTime) :
                new ObjectParameter("EventTime", typeof(System.TimeSpan));
    
            var eventIdParameter = eventId.HasValue ?
                new ObjectParameter("EventId", eventId) :
                new ObjectParameter("EventId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEventTimings_Insert", matchupIdParameter, eventTimeParameter, eventIdParameter);
        }
    
        public virtual int spTeams_UpdateLosses(Nullable<int> teamId)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spTeams_UpdateLosses", teamIdParameter);
        }
    
        public virtual int spTeams_UpdateWins(Nullable<int> teamId)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spTeams_UpdateWins", teamIdParameter);
        }
    
        public virtual int spMatchupEntries_UpdateAwayScore(Nullable<int> matchupId, Nullable<int> teamId, Nullable<double> score)
        {
            var matchupIdParameter = matchupId.HasValue ?
                new ObjectParameter("MatchupId", matchupId) :
                new ObjectParameter("MatchupId", typeof(int));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spMatchupEntries_UpdateAwayScore", matchupIdParameter, teamIdParameter, scoreParameter);
        }
    
        public virtual int spMatchupEntries_UpdateHomeScore(Nullable<int> matchupId, Nullable<int> teamId, Nullable<double> score)
        {
            var matchupIdParameter = matchupId.HasValue ?
                new ObjectParameter("MatchupId", matchupId) :
                new ObjectParameter("MatchupId", typeof(int));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spMatchupEntries_UpdateHomeScore", matchupIdParameter, teamIdParameter, scoreParameter);
        }
    
        public virtual int spMatchup_UpdateWinnerId(Nullable<int> matchupId, Nullable<int> teamId)
        {
            var matchupIdParameter = matchupId.HasValue ?
                new ObjectParameter("MatchupId", matchupId) :
                new ObjectParameter("MatchupId", typeof(int));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spMatchup_UpdateWinnerId", matchupIdParameter, teamIdParameter);
        }
    
        public virtual ObjectResult<spMatchups_GetByRound_Result> spMatchups_GetByRound(Nullable<int> roundId)
        {
            var roundIdParameter = roundId.HasValue ?
                new ObjectParameter("RoundId", roundId) :
                new ObjectParameter("RoundId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spMatchups_GetByRound_Result>("spMatchups_GetByRound", roundIdParameter);
        }
    
        public virtual int spLeagues_UpdateCurrentRound(Nullable<int> leagueId)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spLeagues_UpdateCurrentRound", leagueIdParameter);
        }
    
        public virtual int spTeams_UpdateDraws(Nullable<int> teamId)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spTeams_UpdateDraws", teamIdParameter);
        }
    
        public virtual int spTeams_UpdateRating(Nullable<int> teamId, Nullable<decimal> teamRating)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            var teamRatingParameter = teamRating.HasValue ?
                new ObjectParameter("TeamRating", teamRating) :
                new ObjectParameter("TeamRating", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spTeams_UpdateRating", teamIdParameter, teamRatingParameter);
        }
    
        public virtual int spEvent_GetByName(string eventName)
        {
            var eventNameParameter = eventName != null ?
                new ObjectParameter("EventName", eventName) :
                new ObjectParameter("EventName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEvent_GetByName", eventNameParameter);
        }
    
        public virtual int spClearLeagueDetails(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spClearLeagueDetails", idParameter);
        }
    
        public virtual int spTeams_UpdatePointsForAgainst(Nullable<int> teamId, Nullable<double> pointsFor, Nullable<double> pointsAgainst)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("teamId", teamId) :
                new ObjectParameter("teamId", typeof(int));
    
            var pointsForParameter = pointsFor.HasValue ?
                new ObjectParameter("PointsFor", pointsFor) :
                new ObjectParameter("PointsFor", typeof(double));
    
            var pointsAgainstParameter = pointsAgainst.HasValue ?
                new ObjectParameter("PointsAgainst", pointsAgainst) :
                new ObjectParameter("PointsAgainst", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spTeams_UpdatePointsForAgainst", teamIdParameter, pointsForParameter, pointsAgainstParameter);
        }
    }
}
