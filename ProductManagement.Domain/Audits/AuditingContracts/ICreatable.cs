namespace ProductManagement.Domain.Audits.AuditingContracts;

/// <summary>
/// Audits for insert following ISP and LSP.
/// </summary>
public interface ICreatable
{
    // init as it is immutable.
    DateTimeOffset? CreatedAt { get; set; }
}
