using Refit;

namespace Infrastructure.TmdbServices;

public interface IGuestApiKeysService
{
    [Get("/authentication/guest_session/new")]
    Task<string> GetGuestApiKey();
}