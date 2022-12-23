using System.Text.Json;
using Vote.Data.Entities;
using Vote.Data.Infrastructure.Abstraction;

namespace Vote.Data.Infrastructure.Realization;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly string _fileName = $"{typeof(TEntity).Name}.json";
    private readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), "JsonFiles");
    private IEnumerable<TEntity> _entities = new List<TEntity>();

    public IEnumerable<TEntity> GetAll() => _entities;

    public TEntity? GetById(Guid id) => _entities.FirstOrDefault(entity => entity.Id == id);

    public TEntity Add(TEntity entity)
    {
        if (_entities.Any(e => e.Id == entity.Id))
        {
            throw new Exception("Entity with the same Id already exist");
        }

        if (entity.Id == Guid.Empty)
        {
            entity.Id = Guid.NewGuid();
        }

        _entities = _entities.Append(entity);

        SaveChanges();

        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        Delete(entity);

        return Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _entities = _entities.Where(e => e.Id != entity.Id);

        SaveChanges();
    }

    private void SaveChanges()
    {
        SaveToDisc();
        ReadFromDisc();
    }

    private void SaveToDisc()
    {
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }

        var json = JsonSerializer.Serialize(_entities);

        File.WriteAllText(GetFullPathWithFileName(), json);
    }

    private void ReadFromDisc()
    {
        if (!File.Exists(GetFullPathWithFileName()))
        {
            _entities = new List<TEntity>();

            return;
        }

        var json = File.ReadAllText(GetFullPathWithFileName());

        _entities = JsonSerializer.Deserialize<IEnumerable<TEntity>>(json) ?? new List<TEntity>();
    }

    private string GetFullPathWithFileName() => Path.Combine(_path, _fileName);
}