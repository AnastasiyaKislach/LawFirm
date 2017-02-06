using System;
using LawFirm.Models.Entities;

namespace LawFirm.DataAccess.Contracts {

	public interface IUnitOfWork : IDisposable {

		IRepository<Slider> Slides { get; }

		IRepository<Testimonial> Testimonials { get; }

		IRepository<Setting> Settings { get; }

		IRepository<Practice> Practices { get; }

		IRepository<Article> Articles { get; }

		IRepository<Comment> Comments { get; }

		IRepository<Like> Likes { get; }

		IRepository<Consultation> Consultations { get; }

		IRepository<Question> Questions { get; }

		void Save();
	}
}