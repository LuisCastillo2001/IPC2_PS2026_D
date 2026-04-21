namespace Clase_12.Dtos;

public sealed class TokenResponse
{
    public required string AccessToken { get; init; }
    public string TokenType { get; init; } = "Bearer";
    public int ExpiresInSeconds { get; init; }
}
