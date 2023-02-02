using System;
using Microsoft.EntityFrameworkCore;

namespace TodoUnitOfWork.Data.Repositories
{
	public class GenericRepository<T> : IRepository<T> where T : class
	{
		private readonly TodoDbContext _dbContext;
        DbSet<T> _objectSet;
        public GenericRepository(TodoDbContext todoDbContext)
		{
			_dbContext = todoDbContext;
			_objectSet = _dbContext.Set<T>();
		}
		public void Add(T entity)
		{
			_objectSet.Add(entity);
		}
		public void Delete(T entity)
		{
			_objectSet.Remove(entity);
		}
        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
			if (predicate != null)
				return _objectSet.Where(predicate);
			return _objectSet.AsEnumerable();
        }
        public T GetById(Func<T, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }
	}
}

