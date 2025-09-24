using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NbaStatistics.Models;

namespace NbaStatistics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private const string ApiUrl = "https://api.server.nbaapi.com/api/playertotals?season=2025&team=HOU&page=1&pageSize=35&isPlayoff=False";

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(ApiUrl);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error querying external API");

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var playerResponse = JsonSerializer.Deserialize<PlayerResponse>(content, options);

            if (playerResponse == null || playerResponse.Data == null)
                return NotFound("No players found");

            return Ok(new
            {
                data = playerResponse.Data,
                pagination = playerResponse.Pagination
            });
        }

        [HttpGet("{playerId}")]
        public async Task<ActionResult<PlayerModel>> GetById(string playerId)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(ApiUrl);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error querying external API");

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var playerResponse = JsonSerializer.Deserialize<PlayerResponse>(content, options);

            if (playerResponse == null || playerResponse.Data == null)
                return NotFound("No players found");

            var player = playerResponse.Data.FirstOrDefault(p => p.PlayerId == playerId);

            if (player == null)
                return NotFound($"Player with ID '{playerId}' not found");

            return Ok(player);
        }
    }
}
