using LawFirm.DataAccess;
using LawFirm.DataAccess.Contracts;

namespace LawFirm.BusinessLogic {
	public abstract class BaseService {

		protected IUnitOfWork DataContext { get; private set; }

		protected BaseService(string connectionString) {
			DataContext = new UnitOfWork(connectionString);
		}

		public void Save() {
			DataContext.Save();
		}
	}
}
