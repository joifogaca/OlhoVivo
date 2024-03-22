using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OlhoVivo.Data;
using OlhoVivo.Models;

namespace OlhoVivo.Contract
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
    {
        private AppDataContext _context = null;

        private DbSet<TEntity> _entities = null;

        public GenericRepository()
        {
            this._context = new AppDataContext();  
            _entities = _context.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
           _context.Add(entity);

        }

        public void Delete(object id)
        {
            TEntity existing = _entities.Find(id);

            _entities.Remove(existing);
        }

        public TEntity Get(object id)
        {
            return _entities.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public void Update(TEntity entity)
        {
          _entities.Attach(entity);

         _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save() {
        _context.SaveChanges();
        }
    }
}
