using System;
using System.Linq;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {
	public class PracticeService : BaseService<Practice> {
		public PracticeService(string connectionString) : base(connectionString) {
		}

		public override IQueryable<Practice> GetAll() {
			return base.GetAll().Where(i => !i.IsDeleted);
		}

		public Practice Add(Practice practice) {
			if (practice == null) {
				throw new ArgumentNullException(nameof(practice));
			}

			practice.Text = practice.Text.Trim();
			practice.Title = practice.Title.Trim();

			Practice newPractice = Create(practice);
			Save();

			return newPractice; 
		}
		
		public Practice Edit(Practice practice) {
			if (practice == null) {
				throw new ArgumentNullException(nameof(practice));
			}

			Practice updatePractice = Update(practice);
			Save();

			return updatePractice;

		}

		public Practice Delete(int id) {
			Practice practice = GetById(id);

			if (practice != null) {
				practice.IsDeleted = true;
			}

			Practice deletedpractice = Update(practice);
			Save();

			return deletedpractice;
		}
	}
}
