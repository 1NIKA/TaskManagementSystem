using System.Text.Json.Serialization;

namespace Shared.DTOs;

public class JsonWebToken
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }
    
    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; } = "Bearer";
    
    [JsonPropertyName("expires_in")]
    public long ExpiresIn { get; set; }
}