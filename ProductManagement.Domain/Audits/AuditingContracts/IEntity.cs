namespace ProductManagement.Domain.Audits.AuditingContracts;

/// <summary>
/// Primary Key IEntity to follow ISP and LSP for audits.
/// </summary>
public interface IEntity
{
    // init as it is immutable
    string Id { get; init; }
}
