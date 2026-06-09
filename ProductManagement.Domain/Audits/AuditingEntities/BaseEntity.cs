namespace ProductManagement.Domain.Audits.AuditingEntities;

/// <summary>
/// Soft Deleteable Base Entity
/// </summary>
public abstract class BaseEntity : AuditableEntity, ISoftDeletable
{
    public DateTimeOffset? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
}
