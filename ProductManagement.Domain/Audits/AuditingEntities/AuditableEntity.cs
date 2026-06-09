namespace ProductManagement.Domain.Audits.AuditingEntities;

/// <summary>
/// An Auditable non Soft Deletable base entity.
/// </summary>
public abstract class AuditableEntity : IEntity, ICreatable, IUpdatable
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; init; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
