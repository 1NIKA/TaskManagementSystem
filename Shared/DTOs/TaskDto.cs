namespace Shared.DTOs;

public record TaskDto(int Id,
    string? Title, 
    string? BriefDescription,
    string? Description,
    int CreatorUserId,
    int ReceiverUserId,
    IEnumerable<FileDto>? Files,
    DateTime CratedAt);