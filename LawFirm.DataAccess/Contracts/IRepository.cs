using System.Linq;

namespace LawFirm.DataAccess.Contracts {
	public interface IRepository<TEntity> {
		TEntity Create(TEntity entity);
		TEntity Update(TEntity entity);
		TEntity Delete(TEntity entity);
		TEntity GetById(object entityId);
		IQueryable<TEntity> GetAll();
	}
}