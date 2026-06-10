namespace ProductManagement.Infrastructure.Repositories.Implementations;

/// <summary>
/// Generic Repository Implementation where T should extend IEntity to be an entity
/// </summary>
/// <typeparam name="T"></typeparam>
public class GenericReposiroty<T>(ProductManagementContext context) 
    : IGenericRepository<T> where T : class, IEntity
{
    // Used reflection for collection name.
    private readonly IMongoCollection<T> _collection = context.Datrabase.GetCollection<T>($"{typeof(T).Name}s");

    /// <summary>
    /// Adding entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task AddAsync(T entity)
    {
        if(entity is ICreatable creatable)
        {
            creatable.CreatedAt = DateTimeOffset.UtcNow;
        }
        await _collection.InsertOneAsync(entity);
    }
        
    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task DeleteAsync(T entity)
    {
        if(entity is ISoftDeletable softDeletable)
        {
            softDeletable.IsDeleted = true;
            softDeletable.DeletedAt = DateTimeOffset.UtcNow;
            await UpdateAsync(entity);
        }
        else
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(entity.Id)));
        }
    }

    /// <summary>
    /// Get all Entities
    /// </summary>
    /// <returns></returns>
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        if(typeof(T).IsAssignableTo(typeof(ISoftDeletable)))
        {
            return await _collection.Find(Builders<T>.Filter.Eq("IsDeleted", false)).ToListAsync();
        }
        return await _collection.Find(new BsonDocument()).ToListAsync();
    }

    /// <summary>
    /// Get entity by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T> GetByIdAsync(string id)
    {
        var entity = await _collection.Find(Builders<T>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync();
        if(entity is null)
        {
            return null!;
        }
        if(entity is ISoftDeletable softDeletable)
        {
            return (softDeletable.IsDeleted) ? null! : entity; 
        }
        return entity;
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task UpdateAsync(T entity)
    {
        if(entity is IUpdatable updatable)
        {
            updatable.UpdatedAt = DateTimeOffset.UtcNow;
        }
        if(entity is ICreatable creatable)
        {
            creatable.CreatedAt = DateTimeOffset.UtcNow;
        }
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(entity.Id)), entity);
    }
}
