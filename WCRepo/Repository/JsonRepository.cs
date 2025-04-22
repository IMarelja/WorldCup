using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WCRepo.Model;
using WCRepo.Models;
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

        public Player GetPlayer(int PlayerID,int TeamID, Gender group)
        {
            var players = GetPlayers(TeamID, group);
            return players.FirstOrDefault(p => p.id == PlayerID);
        }

        public ISet<Player> GetPlayers(int TeamID, Gender group)
        {
            var teams = LoadTeams(group);
            var team = teams.FirstOrDefault(t => t.id == TeamID);
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


        /*
        public ISet<Player> GetPlayers(int TeamID, Gender group)
        {
            var teams = LoadTeams(group);
            var team = teams.FirstOrDefault(t => t.id == TeamID);
            if (team == null) return new HashSet<Player>();

            var matches = LoadMatches(group);
            var firstMatch = matches.FirstOrDefault(m =>
                m.home_team_country == team.country || m.away_team_country == team.country);

            if (firstMatch == null) return new HashSet<Player>();

            JsonDocument matchDoc = JsonDocument.Parse(JsonDataLoad("matches.json", group));
            JsonElement matchEl = matchDoc.RootElement.EnumerateArray()
                .FirstOrDefault(m =>
                    m.GetProperty("home_team_country").GetString() == team.country ||
                    m.GetProperty("away_team_country").GetString() == team.country);

            if (matchEl.ValueKind == JsonValueKind.Undefined)
                return new HashSet<Player>();

            string side = matchEl.GetProperty("home_team_country").GetString() == team.country
                ? "home_team_statistics"
                : "away_team_statistics";

            var playerSet = new HashSet<Player>();
            var stats = matchEl.GetProperty(side);

            void AddPlayers(JsonElement array)
            {
                int idCounter = 1;
                foreach (var p in array.EnumerateArray())
                {
                    playerSet.Add(new Player
                    {
                        name = p.GetProperty("name").GetString(),
                        captain = p.GetProperty("captain").GetBoolean(),
                        shirt_number = p.GetProperty("shirt_number").GetInt32(),
                        position = p.GetProperty("position").GetString(),
                        favorite = false
                    });
                }
            }

            AddPlayers(stats.GetProperty("starting_eleven"));
            AddPlayers(stats.GetProperty("substitutes"));

            return playerSet;
        }*/

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

        public Match GetMatch(int TeamID, Gender group)
        {
            throw new NotImplementedException();
        }

        public ISet<Match> GetMatches(int TeamID, Gender group)
        {
            throw new NotImplementedException();
        }

        public string GetDirectory()
        {
            return PathToData;
        }
    }
}
