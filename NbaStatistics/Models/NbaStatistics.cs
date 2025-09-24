using System.Text.Json.Serialization;

namespace NbaStatistics.Models
{
    public class PlayerApiDto
    {
    [JsonPropertyName("ID")]
    public int? ExternalId { get; set; } = null;

    [JsonPropertyName("playerId")]
    public string PlayerId { get; set; } = string.Empty;

    [JsonPropertyName("playerName")]
    public string PlayerName { get; set; } = string.Empty;

    [JsonPropertyName("team")]
    public string? Team { get; set; } = null;

    [JsonPropertyName("position")]
    public string? Position { get; set; } = null;

    [JsonPropertyName("season")]
    public int Season { get; set; }

    [JsonPropertyName("isPlayoff")]
    public bool? IsPlayoff { get; set; } = null;

    [JsonPropertyName("games")]
    public int Games { get; set; } = 0;

    [JsonPropertyName("points")]
    public int Points { get; set; } = 0;

    [JsonPropertyName("minutesPg")]
    public int? Minutes { get; set; } = null;

    [JsonPropertyName("totalRb")]
    public int? TotalRb { get; set; } = null;

    [JsonPropertyName("offensiveRb")]
    public int? OffensiveRb { get; set; } = null;

    [JsonPropertyName("defensiveRb")]
    public int? DefensiveRb { get; set; } = null;

    [JsonPropertyName("assists")]
    public int? Assists { get; set; } = null;

    [JsonPropertyName("steals")]
    public int? Steals { get; set; } = null;

    [JsonPropertyName("blocks")]
    public int? Blocks { get; set; } = null;

    [JsonPropertyName("turnovers")]
    public int? Turnovers { get; set; } = null;

    [JsonPropertyName("personalFouls")]
    public int? PersonalFouls { get; set; } = null;

    [JsonPropertyName("fieldPercent")]
    public double? FieldPercent { get; set; } = null;

    [JsonPropertyName("threePercent")]
    public double? ThreePercent { get; set; } = null;

    [JsonPropertyName("twoPercent")]
    public double? TwoPercent { get; set; } = null;

    [JsonPropertyName("ftPercent")]
    public double? FtPercent { get; set; } = null;

    [JsonPropertyName("effectFgPercent")]
    public double? EffectFgPercent { get; set; } = null;

    [JsonPropertyName("CreatedAt")]
    public DateTime? ProviderCreatedAt { get; set; } = null;

    [JsonPropertyName("UpdatedAt")]
    public DateTime? ProviderUpdatedAt { get; set; } = null;

    [JsonPropertyName("DeletedAt")]
    public DateTime? ProviderDeletedAt { get; set; } = null;

    public DateTime LastFetchedAt { get; set; } = DateTime.UtcNow;

    public string RawJson { get; set; } = string.Empty;

    }
}