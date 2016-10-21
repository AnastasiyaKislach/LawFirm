using System.Data.Entity;
using System.Linq;
using LawFirm.DataAccess.Contracts;

namespace LawFirm.DataAccess {
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {

		protected DbSet<TEntity> Items { get; private set; }
		protected DbContext Context { get; private set; }

		public Repository(DbContext context) {
			Items = context.Set<TEntity>();
			Context = context;
		}

		public virtual TEntity Create(TEntity entity) {
			Items.Add(entity);
			return entity;
		}

		public virtual TEntity Update(TEntity entity) {
			Context.Entry(entity).State = EntityState.Modified;
			return entity;
		}

		public virtual TEntity Delete(TEntity entity) {
			Items.Remove(entity);
			return entity;
		}

		public virtual TEntity GetById(object entityId) {
			TEntity entity = Items.Find(entityId);
			return entity;
		}

		public virtual IQueryable<TEntity> GetAll() {
			return Items;
		}
	}
}
