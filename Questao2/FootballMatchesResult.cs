using System.Text.Json.Serialization;

namespace Questao2
{
    public sealed class FootballMatchesResult
    {
        [JsonPropertyName("page")]
        public short Page { get; set; }

        [JsonPropertyName("per_page")]
        public short PerPage { get; set; }

        [JsonPropertyName("total")]
        public short Total { get; set; }

        [JsonPropertyName("total_pages")]
        public short TotalPages { get; set; }

        [JsonPropertyName("data")]
        public FootballMatchesData[] Data { get; set; } = Array.Empty<FootballMatchesData>();
    }

    public sealed class FootballMatchesData
    {
        [JsonPropertyName("competition")]
        public string? Competition { get; set; }

        [JsonPropertyName("year")]
        public short Year { get; set; }

        [JsonPropertyName("round")]
        public string? Round { get; set; }

        [JsonPropertyName("team1")]
        public string? Team1 { get; set; }

        [JsonPropertyName("team2")]
        public string? Team2 { get; set; }

        [JsonPropertyName("team1goals")]
        public string? Team1Goals { get; set; }

        [JsonPropertyName("team2goals")]
        public string? Team2Goals { get; set; }
    }
}
