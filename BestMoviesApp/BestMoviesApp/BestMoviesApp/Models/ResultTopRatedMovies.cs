﻿
using Newtonsoft.Json;

public class ResultTopRatedMovies
{
    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("total_results")]
    public int TotalResults { get; set; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }

    [JsonProperty("results")]
    public Movie[] Movies { get; set; }
}
