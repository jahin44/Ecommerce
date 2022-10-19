namespace Ecommerce.DataAccessLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        void Delete(TEntity entity);


    }
}