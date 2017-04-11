using LawFirm.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.BusinessLogic {
	public class SlideService : BaseService {
		public SlideService(string connectionString) : base(connectionString) {
		}

		public IQueryable<Slide> GetAll() {
			return DataContext.Slides.GetAll().Where(i => !i.IsDeleted);
		}

		public Slide GetById(int id) {
			Slide slide = DataContext.Slides.GetById(id);
			return slide;
		}


		public void Add(Slide slide) {
			if (slide == null) {
				throw new ArgumentNullException(nameof(slide));
			}

			slide.ImagePath = slide.ImagePath;

			DataContext.Slides.Create(slide);
			DataContext.Save();
		}

		public void Delete(int id) {
			Slide slide = DataContext.Slides.GetById(id);

			if (slide != null) {
				slide.IsDeleted = true;
			}

			DataContext.Slides.Update(slide);
			DataContext.Save();
		}
	}
}
