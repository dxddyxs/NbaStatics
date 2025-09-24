using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NbaStatistics.Models;

namespace NbaStatistics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            using var client = new HttpClient();

            string apiURL =
                "https://api.server.nbaapi.com/api/playertotals?season=2025&team=HOU&page=1&pageSize=35&isPlayoff=False";

            var response = await client.GetAsync(apiURL);
            
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error when querying external API");

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            var playerResponse = JsonSerializer.Deserialize<PlayerResponse>(content, options);

            if (playerResponse == null || playerResponse.Data == null)
                return NotFound("No players found");

            return Ok(new
            {
                data = playerResponse.Data,
                pagination = playerResponse.Pagination,
            });
        }
    }
}