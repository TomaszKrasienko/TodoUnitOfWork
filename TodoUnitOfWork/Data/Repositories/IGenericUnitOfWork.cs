namespace TodoUnitOfWork.Data.Repositories
{
    public interface IGenericUnitOfWork
    {
        void Dispose();
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}