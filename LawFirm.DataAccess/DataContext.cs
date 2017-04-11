using System.Data.Entity;
using LawFirm.Models.Entities;

namespace LawFirm.DataAccess {

	public class DataContext : DbContext {

		public virtual DbSet<Slide> Slides { get; set; }

		public virtual DbSet<Testimonial> Testimonials { get; set; }

		public virtual DbSet<Setting> Settings { get; set; }

		public virtual DbSet<Practice> Practices { get; set; }

		public virtual DbSet<Article> Articles { get; set; }

		public virtual DbSet<Comment> Comments { get; set; }

		public virtual DbSet<Like> Likes { get; set; }

		public virtual DbSet<Consultation> Consultations { get; set; }

		public virtual DbSet<Question> Questions { get; set; }

		public DataContext() : this("DBConnection") { }

		public DataContext(string connectionString)
			: base(connectionString) {

		}
	}
}
