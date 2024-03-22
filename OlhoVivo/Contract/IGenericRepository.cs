using Microsoft.AspNetCore.Components.Web;
using OlhoVivo.Models;

namespace OlhoVivo.Contract
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel
    {

        void Update(TEntity entity);

        void Create(TEntity entity);
        TEntity Get(object id);
        void Delete(object id);
        List<TEntity> GetAll();

        void Save();
       
    
    }
}
