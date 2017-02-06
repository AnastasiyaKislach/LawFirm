using System;
using System.Linq;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {

	public class TestimonialService : BaseService {

		public TestimonialService(string connectionString) : base(connectionString) {
		}

		public IQueryable<Testimonial> GetAll() {
			return DataContext.Testimonials.GetAll().Where(i => !i.IsDeleted && i.IsApprove);
		}

		public void Add(Testimonial testimonial) {
			if (testimonial == null) {
				throw new ArgumentNullException(nameof(testimonial));
			}

			testimonial.CreationTime = DateTime.Now;
			testimonial.Author = testimonial.Author.Trim();
			testimonial.Email = testimonial.Email.Trim();
			testimonial.Text = testimonial.Text.Trim();

			DataContext.Testimonials.Create(testimonial);
			DataContext.Save();
		}

		public void Delete(int id) {
			Testimonial testimonial = DataContext.Testimonials.GetById(id);

			if (testimonial != null) {
				testimonial.IsDeleted = true;
			}

			DataContext.Testimonials.Update(testimonial);
			DataContext.Save();
		}
	}
}
