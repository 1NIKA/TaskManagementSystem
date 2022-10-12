namespace Shared.DTOs;

public record FileDto(int Id, 
    string? Name, 
    string? Path, 
    DateTime CratedAt);