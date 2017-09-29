using LawFirm.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.BusinessLogic {
	public class SlideService : BaseService<Slide> {
		public SlideService(string connectionString) : base(connectionString) {
		}

		public override IQueryable<Slide> GetAll() {
			return base.GetAll().Where(i => !i.IsDeleted);
		}

		public void Add(Slide slide) {
			if (slide == null) {
				throw new ArgumentNullException(nameof(slide));
			}

			slide.ImagePath = slide.ImagePath;

			Create(slide);
			Save();
		}

		public void Delete(int id) {
			Slide slide = GetById(id);

			if (slide != null) {
				slide.IsDeleted = true;
			}

			Update(slide);
			Save();
		}
	}
}
