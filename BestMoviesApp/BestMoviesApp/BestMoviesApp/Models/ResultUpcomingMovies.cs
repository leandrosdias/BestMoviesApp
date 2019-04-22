

using Newtonsoft.Json;

public class ResultUpcomingMovies
{
    [JsonProperty("results")]
    public Movie[] Movies { get; set; }

    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("total_results")]
    public int TotalMovies { get; set; }

    [JsonProperty("dates")]
    public Dates Dates { get; set; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }
}

public class Dates
{
    [JsonProperty("maximum")]
    public string Maximum { get; set; }

    [JsonProperty("minimum")]
    public string Minimum { get; set; }
}
