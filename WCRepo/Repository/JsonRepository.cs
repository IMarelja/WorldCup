using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WCRepo.Model;
using WCRepo.Models;

namespace WCRepo.Repository
{
    internal class JsonRepository : IRepository
    {
        private string PathToData = AppDomain.CurrentDomain.BaseDirectory;
        private string GetDataPath(Gender group) =>
            group == Gender.men ? "worldcup.sfg.io/men/" : "worldcup.sfg.io/women/";

        private string LoadJson(string filename) =>
            File.ReadAllText(filename);

        private List<Team> LoadTeams(Gender group)
        {
            string json = LoadJson(Path.Combine(GetDataPath(group), "teams.json"));
            return JsonSerializer.Deserialize<List<Team>>(json);
        }

        private List<Match> LoadMatches(Gender group)
        {
            string json = LoadJson(Path.Combine(GetDataPath(group), "matches.json"));
            return JsonSerializer.Deserialize<List<Match>>(json);
        }

        public Player GetPlayer(int TeamID, Gender group)
        {
            throw new NotImplementedException();
        }
        public ISet<Player> GetPlayers(int TeamID, Gender group)
        {
            var teams = LoadTeams(group);
            var team = teams.FirstOrDefault(t => t.id == TeamID);
            if (team == null) return new HashSet<Player>();

            var matches = LoadMatches(group);
            var firstMatch = matches.FirstOrDefault(m =>
                m.home_team_country == team.country || m.away_team_country == team.country);

            if (firstMatch == null) return new HashSet<Player>();

            JsonDocument matchDoc = JsonDocument.Parse(LoadJson(Path.Combine(GetDataPath(group), "matches.json")));
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
                        ID = idCounter++,
                        Name = p.GetProperty("name").GetString(),
                        Captain = p.GetProperty("captain").GetBoolean(),
                        ShirtNumber = p.GetProperty("shirt_number").GetInt32(),
                        Position = p.GetProperty("position").GetString(),
                        Favorite = false
                    });
                }
            }

            AddPlayers(stats.GetProperty("starting_eleven"));
            AddPlayers(stats.GetProperty("substitutes"));

            return playerSet;
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
