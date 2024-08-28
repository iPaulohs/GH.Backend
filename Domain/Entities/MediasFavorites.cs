namespace Domain.Entities;

public class MediasFavorites : EntityBase
{ 
    protected MediasFavorites() { }

    public MediasFavorites(int tmdbId, MediaType mediaType)
    {
        TmdbId = tmdbId;
        MediaType = mediaType;
    }

    public int TmdbId { get; init; }

    public MediaType MediaType { get; init; }
}

public enum MediaType
{
    TvSerie,
    Movie
}