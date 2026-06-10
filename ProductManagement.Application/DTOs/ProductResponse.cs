namespace ProductManagement.Application.DTOs;

public record ProductResponse(
    string Id, string Name, string? Description, decimal Price, int Quantity, string? Category);