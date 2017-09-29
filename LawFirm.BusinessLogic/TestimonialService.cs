using System;
using System.Linq;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {

	public class TestimonialService : BaseService<Testimonial> {

		public TestimonialService(string connectionString) : base(connectionString) {
		}

		public IQueryable<Testimonial> GetAllApproved() {
			return GetAll().Where(i => !i.IsDeleted && i.IsApproved);
		}

		public Testimonial Add(Testimonial testimonial) {
			if (testimonial == null) {
				throw new ArgumentNullException(nameof(testimonial));
			}

			testimonial.CreationTime = DateTime.Now;
			testimonial.Author = testimonial.Author.Trim();
			testimonial.Email = testimonial.Email.Trim();
			testimonial.Text = testimonial.Text.Trim();

			Testimonial newTestimonial = Create(testimonial);
			Save();

			return newTestimonial;
		}

		public Testimonial Edit(Testimonial testimonial) {
			if (testimonial == null) {
				throw new ArgumentNullException(nameof(testimonial));
			}

			Testimonial updateTestimonial = Update(testimonial);
			Save();

			return updateTestimonial;

		}

		public void Delete(int id) {
			Testimonial testimonial = GetById(id);

			if (testimonial != null) {
				testimonial.IsDeleted = true;
			}

			Update(testimonial);
			Save();
		}

		public void Approve(int id) {
			Testimonial testimonial = GetById(id);
			testimonial.IsApproved = !testimonial.IsApproved;
			Update(testimonial);
			Save();
		}
	}
}
