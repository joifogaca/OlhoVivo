using Microsoft.AspNetCore.Components.Web;

namespace OlhoVivo.Contract
{
    public interface IEntityGeneric<TEntity> where TEntity : class
    {

        bool Update(TEntity entity);

        bool Create(TEntity entity);
        TEntity Get(long id);
        bool Delete(TEntity entity);
        TEntity GetAll();
       
    
    }
}
