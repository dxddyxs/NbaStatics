using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NbaStatistics.Models;

namespace NbaStatistics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private const string ApiUrl =
            "https://api.server.nbaapi.com/api/playertotals?season=2025&team=HOU&page=1&pageSize=35&isPlayoff=False";

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(ApiUrl);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error when querying external API");

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<PlayerResponse>(content, options);

            if (apiResponse == null || apiResponse.Data == null)
                return NotFound("No players found");

            var players = apiResponse.Data.Select(dto => new PlayerModel
            {
                ExternalId = dto.ExternalId,
                PlayerId = dto.PlayerId,
                PlayerName = dto.PlayerName,
                Team = dto.Team,
                Position = dto.Position,
                Season = dto.Season,
                IsPlayoff = dto.IsPlayoff,
                Games = dto.Games,
                Points = dto.Points,
                Minutes = dto.Minutes,
                TotalRb = dto.TotalRb,
                OffensiveRb = dto.OffensiveRb,
                DefensiveRb = dto.DefensiveRb,
                Assists = dto.Assists,
                Steals = dto.Steals,
                Blocks = dto.Blocks,
                Turnovers = dto.Turnovers,
                PersonalFouls = dto.PersonalFouls,
                FieldPercent = dto.FieldPercent,
                ThreePercent = dto.ThreePercent,
                TwoPercent = dto.TwoPercent,
                FtPercent = dto.FtPercent,
                EffectFgPercent = dto.EffectFgPercent,
                ProviderCreatedAt = dto.ProviderCreatedAt,
                ProviderUpdatedAt = dto.ProviderUpdatedAt,
                ProviderDeletedAt = dto.ProviderDeletedAt,
                LastFetchedAt = dto.LastFetchedAt,
                RawJson = dto.RawJson
            }).ToList();

            return Ok(new
            {
                data = players,
                pagination = apiResponse.Pagination
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerModel>> Get(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(ApiUrl);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error when querying external API");

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<PlayerResponse>(content, options);

            if (apiResponse == null || apiResponse.Data == null)
                return NotFound("No players found");

            var dto = apiResponse.Data.FirstOrDefault(p => p.ExternalId == id);
            if (dto == null)
                return NotFound("Player not found");

            // Converte DTO em PlayerModel
            var player = new PlayerModel(dto);

            return Ok(player);
        }
    }
}
