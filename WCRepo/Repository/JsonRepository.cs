using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;
using Moduls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WCRepo.Repository
{
    internal class JsonRepository : IRepository
    {
        private static string PathToData = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName,"WCRepo");
        private string JsonDataLoad(string filename, Gender group) => File.ReadAllText(Path.Combine(PathToData, @"Data\", @$"{group}\" , filename));

        private List<Team> LoadTeams(Gender group)
        {
            string json = JsonDataLoad("teams.json", group);
            return JsonSerializer.Deserialize<List<Team>>(json);
        }

        private List<Match> LoadMatches(Gender group)
        {
            string json = JsonDataLoad("matches.json", group);
            return JsonSerializer.Deserialize<List<Match>>(json);
        }

        private List<Moduls.Result> LoadResults(Gender group)
        {
            string json = JsonDataLoad("results.json", group);
            return JsonSerializer.Deserialize<List<Moduls.Result>>(json);
        }

        public Player GetPlayer(int PlayerID,int TeamID, Gender group)
        {
            var players = GetPlayers(TeamID, group);
            return players.FirstOrDefault(p => p.id == PlayerID);
        }

        public ISet<Player> GetPlayers(int TeamID, Gender group)
        {
            List<Team> teams = LoadTeams(group);
            Team team = teams.FirstOrDefault(t => t.id == TeamID);
            if (team == null) return new HashSet<Player>();

            string matchesJson = JsonDataLoad("matches.json", group);
            var matches = JsonSerializer.Deserialize<List<JsonElement>>(matchesJson);

            // Find the first match where the team played
            var match = matches.FirstOrDefault(m =>
                m.GetProperty("home_team_country").GetString() == team.country ||
                m.GetProperty("away_team_country").GetString() == team.country);

            if (match.ValueKind == JsonValueKind.Undefined) return new HashSet<Player>();

            var statsProperty = match.GetProperty(
                match.GetProperty("home_team_country").GetString() == team.country
                    ? "home_team_statistics"
                    : "away_team_statistics"
            );

            var startingEleven = statsProperty.GetProperty("starting_eleven");
            var substitutes = statsProperty.GetProperty("substitutes");

            var players = new HashSet<Player>();
            int idCounter = 1;

            foreach (var p in startingEleven.EnumerateArray())
            {
                players.Add(new Player
                {
                    id = idCounter++,
                    name = p.GetProperty("name").GetString(),
                    captain = p.GetProperty("captain").GetBoolean(),
                    shirt_number = p.GetProperty("shirt_number").GetInt32(),
                    position = p.GetProperty("position").GetString(),
                    favorite = false
                });
            }

            foreach (var p in substitutes.EnumerateArray())
            {
                players.Add(new Player
                {
                    id = idCounter++,
                    name = p.GetProperty("name").GetString(),
                    captain = p.GetProperty("captain").GetBoolean(),
                    shirt_number = p.GetProperty("shirt_number").GetInt32(),
                    position = p.GetProperty("position").GetString(),
                    favorite = false
                });
            }

            return players;
        }

        public Team GetTeam(int TeamID, Gender group)
        {
            var teams = LoadTeams(group);
            return teams.FirstOrDefault(t => t.id == TeamID);
        }

        public ISet<Team> GetTeams(Gender group)
        {
            var teams = LoadTeams(group);
            return teams.ToHashSet();
        }

        public ISet<Result> GetResults(Gender group)
        {
            var reults = LoadResults(group);
            return reults.ToHashSet();
        }

        public string GetDirectory()
        {
            return PathToData;
        }

        public ISet<Match> GetMatches(Gender group)
        {
            throw new NotImplementedException();
        }

        public Match GetMatchByTeamID(int TeamID, Gender group)
        {
            throw new NotImplementedException();
        }

        public ISet<Match> GetMatchesByTeam(int TeamID, Gender group)
        {
            throw new NotImplementedException();
        }

        public Match GetMatchBetweenTeams(int Team1ID, int Team2ID, Gender group)
        {
            var matches = LoadMatches(group);

            // Find match where both teams appear
            foreach (var match in matches)
            {
                bool isFirstHomeSecondAway = match.home_team_statistics.country == GetTeam(Team1ID,group).country &&
                                             match.away_team_statistics.country == GetTeam(Team2ID, group).country;
                bool isFirstAwaySecondHome = match.home_team_statistics.country == GetTeam(Team2ID, group).country &&
                                             match.away_team_statistics.country == GetTeam(Team1ID, group).country;

                if (isFirstHomeSecondAway || isFirstAwaySecondHome)
                {
                    return match;
                }
            }

            return null;
        }

        public Result GetResult(int TeamID, Gender group)
        {
            List<Result> results = LoadResults(group);
            return results.FirstOrDefault(t => t.id == TeamID);
        }

        public Match GetMatch(string MatchID, Gender group)
        {
            var results = LoadMatches(group);
            return results.FirstOrDefault(t => t.fifa_id == MatchID);
        }
    }
}
