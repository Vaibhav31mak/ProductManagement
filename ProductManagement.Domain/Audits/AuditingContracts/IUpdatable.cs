namespace ProductManagement.Domain.Audits.AuditingContracts;

/// <summary>
/// Update audits following ISP and LSP.
/// </summary>
public interface IUpdatable
{
    DateTimeOffset? UpdatedAt { get; set; }
}
