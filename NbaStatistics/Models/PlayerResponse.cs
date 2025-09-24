using System.Text.Json.Serialization;

namespace NbaStatistics.Models
{
    public class PlayerResponse
    {
        [JsonPropertyName("data")] 
        public List<PlayerModel> Data { get; set; } = new();

        [JsonPropertyName("pagination")] 
        public PaginationInfo Pagination { get; set; } = new();
    }
    
    public class PaginationInfo
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
} 