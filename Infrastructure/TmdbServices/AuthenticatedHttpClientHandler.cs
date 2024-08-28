using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.TmdbServices;

public class AuthenticatedHttpClientHandler(IConfiguration configuration) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = configuration["TMDB:TMDBToken"] ?? throw new NullReferenceException(nameof(configuration));
        
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}