using System;
using System.Linq;
using System.Linq.Expressions;

namespace LawFirm.DataAccess.Contracts {
	public interface IRepository<TEntity> {
		TEntity Create(TEntity entity);
		TEntity Update(TEntity entity);
		TEntity Remove(TEntity entity);
		TEntity GetById(object entityId);
		IQueryable<TEntity> GetAll();
		IQueryable<TEntity> Find(Expression<Func<TEntity, Boolean>> predicate);
	}
}