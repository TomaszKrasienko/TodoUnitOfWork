using System;
namespace TodoUnitOfWork.Data.Repositories
{
    public class GenericUnitOfWork : IDisposable, IGenericUnitOfWork
    {
        private TodoDbContext _todoDbContext;
        public GenericUnitOfWork(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
                return repositories[typeof(T)] as IRepository<T>;
            IRepository<T> repository = new GenericRepository<T>(_todoDbContext);
            repositories.Add(typeof(T), repository);
            return repository;
        }
        public void SaveChanges()
        {
            _todoDbContext.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _todoDbContext.Dispose();
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

