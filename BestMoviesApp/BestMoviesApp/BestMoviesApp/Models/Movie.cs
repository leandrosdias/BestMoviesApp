using Newtonsoft.Json;
using SQLite;

public class Movie
{
    [JsonProperty("vote_count")]
    [Ignore]
    public int VoteCount { get; set; }

    [JsonProperty("id")]
    [PrimaryKey]
    public int Id { get; set; }

    [JsonProperty("video")]
    [Ignore]
    public bool Video { get; set; }

    [JsonProperty("vote_average")]
    [Ignore]
    public float VoteAverage { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("popularity")]
    [Ignore]
    public float Popularity { get; set; }

    [JsonProperty("poster_path")]
    public string PosterPath { get; set; }

    [JsonProperty("original_language")]
    [Ignore]
    public string OriginalLanguage { get; set; }

    [JsonProperty("original_title")]
    [Ignore]
    public string OriginalTitle { get; set; }

    [JsonProperty("genre_ids")]
    [Ignore]
    public int[] GenreIds { get; set; }

    [JsonProperty("backdrop_path")]
    public string BackdropPath { get; set; }

    [JsonProperty("adult")]
    [Ignore]
    public bool Adult { get; set; }

    [JsonProperty("overview")]
    public string Overview { get; set; }

    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; }

    [JsonIgnore]
    public bool IsFavorite { get; set; }
}
