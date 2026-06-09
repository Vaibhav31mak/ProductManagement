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
            creatable.CreatedAt = DateTimeOffset.Now;
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
    public async Task<IReadOnlyList<T>> GetAllAsync() =>
        await _collection.Find(new BsonDocument()).ToListAsync();

    /// <summary>
    /// Get entity by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T> GetByIdAsync(string id) =>
        await _collection.Find(Builders<T>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync();

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task UpdateAsync(T entity)
    {
        if(entity is IUpdatable updatable)
        {
            updatable.UpdatedAt = DateTimeOffset.Now;
        }
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(entity.Id)), entity);
    }
}
