namespace ProductManagement.Application.DTOs;

/// <summary>
/// ProductResponse DTO
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Price"></param>
/// <param name="Quantity"></param>
/// <param name="Category"></param>
public record ProductResponse(
    string Id, string Name, string? Description, decimal Price, int Quantity, string? Category);