using System.Linq;
using LawFirm.DataAccess;
using LawFirm.DataAccess.Contracts;

namespace LawFirm.BusinessLogic {
	public abstract class BaseService<T> where T : class {
		private IRepository<T> repository;
		protected IUnitOfWork DataContext { get; private set; }

		protected BaseService(string connectionString) {
			DataContext = new UnitOfWork(connectionString);
			repository = DataContext.GetRepository<T>();
		}

		public virtual T Create(T item) {
			return repository.Create(item);
		}

		public virtual IQueryable<T> GetAll() {
			return repository.GetAll();
		}

		public virtual T GetById(int id) {
			return repository.GetById(id);
		}

		public virtual T Update(T item) {
			return repository.Update(item);
		}

		public virtual T Delete(int id) {
			T item = GetById(id);
			return repository.Delete(item);
		}
		
		public void Save() {
			DataContext.Save();
		}
	}
}
