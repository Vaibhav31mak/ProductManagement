namespace ProductManagement.Domain.Audits.AuditingContracts;

/// <summary>
/// Contract for soft delete following ISP and LSP.
/// </summary>
public interface ISoftDeletable
{
    DateTimeOffset? DeletedAt { get; set; }
    bool IsDeleted { get; set; }
}
