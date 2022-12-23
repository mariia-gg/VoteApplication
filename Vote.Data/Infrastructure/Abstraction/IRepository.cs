using Vote.Data.Entities;

namespace Vote.Data.Infrastructure.Abstraction;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    public IEnumerable<TEntity> GetAll();

    public TEntity? GetById(Guid id);

    public TEntity Add(TEntity entity);

    public TEntity Update(TEntity entity);

    public void Delete(TEntity entity);
}