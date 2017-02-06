using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawFirm.DataAccess;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {
	public class PracticeService : BaseService {
		public PracticeService(string connectionString) : base(connectionString) {
		}

		public IQueryable<Practice> GetAll() {
			return DataContext.Practices.GetAll().Where(i => !i.IsDeleted);
		}

		public void Add(Practice practice) {
			if (practice == null) {
				throw new ArgumentNullException(nameof(practice));
			}

			practice.Text = practice.Text.Trim();
			practice.Title = practice.Title.Trim();

			DataContext.Practices.Create(practice);
			DataContext.Save();
		}

		public Practice GetById(int id) {
			Practice practice = DataContext.Practices.GetById(id);
			return practice;
		}

		public void Delete(int id) {
			Practice practice = DataContext.Practices.GetById(id);

			if (practice != null) {
				practice.IsDeleted = true;
			}

			DataContext.Practices.Update(practice);
			DataContext.Save();
		}
	}
}
