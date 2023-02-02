using System;
namespace TodoUnitOfWork.Data.Repositories
{
	public interface IRepository<T>
	{
		IEnumerable<T> GetAll(Func<T, bool> predicate = null);
		T GetById(Func<T, bool> predicate);
		void Add(T entity);
		void Delete(T entity);
	}
}

