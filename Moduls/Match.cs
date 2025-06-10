using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class Match
    {
        [JsonProperty("venue")]
        public string venue { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("fifa_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public string fifa_id { get; set; }

        [JsonProperty("attendance")]
        [JsonConverter(typeof(ParseStringConverter))]
        public string attendance { get; set; }

        [JsonProperty("home_team_country")]
        public string home_team_country { get; set; }

        [JsonProperty("away_team_country")]
        public string away_team_country { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset datetime { get; set; }

        [JsonProperty("home_team")]
        public Team home_team { get; set; }

        [JsonProperty("away_team")]
        public Team away_team { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent> home_team_events { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent> away_team_events { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics home_team_statistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics away_team_statistics { get; set; }

    }

    public partial class TeamEvent
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("type_of_event")]
        public string type_of_event { get; set; }

        [JsonProperty("player")]
        public string player { get; set; }

        [JsonProperty("time")]
        public string time { get; set; }
    }

    public partial class TeamStatistics
    {
        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("starting_eleven")]
        public List<Player> starting_eleven { get; set; }

        [JsonProperty("substitutes")]
        public List<Player> substitutes { get; set; }
    }

    public enum TypeOfEvent { Goal, SubstitutionIn, SubstitutionOut, YellowCard };

    public enum Position { Defender, Forward, Goalie, Midfield };

    public partial class Match
    {
        public static Match FromJson(string json) => JsonConvert.DeserializeObject<Match>(json, Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Match self) => JsonConvert.SerializeObject(self, Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeOfEventConverter.Singleton,
                PositionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class TypeOfEventConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeOfEvent) || t == typeof(TypeOfEvent?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "goal":
                    return TypeOfEvent.Goal;
                case "substitution-in":
                    return TypeOfEvent.SubstitutionIn;
                case "substitution-out":
                    return TypeOfEvent.SubstitutionOut;
                case "yellow-card":
                    return TypeOfEvent.YellowCard;
            }
            throw new Exception("Cannot unmarshal type TypeOfEvent");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeOfEvent)untypedValue;
            switch (value)
            {
                case TypeOfEvent.Goal:
                    serializer.Serialize(writer, "goal");
                    return;
                case TypeOfEvent.SubstitutionIn:
                    serializer.Serialize(writer, "substitution-in");
                    return;
                case TypeOfEvent.SubstitutionOut:
                    serializer.Serialize(writer, "substitution-out");
                    return;
                case TypeOfEvent.YellowCard:
                    serializer.Serialize(writer, "yellow-card");
                    return;
            }
            throw new Exception("Cannot marshal type TypeOfEvent");
        }

        public static readonly TypeOfEventConverter Singleton = new TypeOfEventConverter();
    }

    internal class PositionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Position) || t == typeof(Position?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Defender":
                    return Position.Defender;
                case "Forward":
                    return Position.Forward;
                case "Goalie":
                    return Position.Goalie;
                case "Midfield":
                    return Position.Midfield;
            }
            throw new Exception("Cannot unmarshal type Position");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Position)untypedValue;
            switch (value)
            {
                case Position.Defender:
                    serializer.Serialize(writer, "Defender");
                    return;
                case Position.Forward:
                    serializer.Serialize(writer, "Forward");
                    return;
                case Position.Goalie:
                    serializer.Serialize(writer, "Goalie");
                    return;
                case Position.Midfield:
                    serializer.Serialize(writer, "Midfield");
                    return;
            }
            throw new Exception("Cannot marshal type Position");
        }

        public static readonly PositionConverter Singleton = new PositionConverter();
    }
}
