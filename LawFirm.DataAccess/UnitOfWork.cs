using System;
using LawFirm.DataAccess.Contracts;
using LawFirm.Models.Entities;

namespace LawFirm.DataAccess {
	public class UnitOfWork : IUnitOfWork {

		protected DataContext DataContext;
		private IRepository<Slider> _slides;
		private IRepository<Testimonial> _testimonials;
		private IRepository<Setting> _settings;
		private IRepository<Practice> _practices;
		private IRepository<Article> _articles;
		private IRepository<Comment> _comments;
		private IRepository<Like> _likes;
		private IRepository<Consultation> _consultations;
		private IRepository<Question> _questions; 

		private bool _disposed;

		public UnitOfWork(string connectionString) {
			DataContext = new DataContext(connectionString);
		}

		public IRepository<Slider> Slides
		{
			get { return _slides ?? (_slides = new Repository<Slider>(DataContext)); }
		}

		public IRepository<Testimonial> Testimonials
		{
			get { return _testimonials ?? (_testimonials = new Repository<Testimonial>(DataContext)); }
		}

		public IRepository<Setting> Settings
		{
			get { return _settings ?? (_settings = new Repository<Setting>(DataContext)); }
		}
		public IRepository<Practice> Practices
		{
			get { return _practices ?? (_practices = new Repository<Practice>(DataContext)); }
		}
		public IRepository<Article> Articles
		{
			get { return _articles ?? (_articles = new Repository<Article>(DataContext)); }
		}
		public IRepository<Comment> Comments
		{
			get { return _comments ?? (_comments = new Repository<Comment>(DataContext)); }
		}
		public IRepository<Like> Likes
		{
			get { return _likes ?? (_likes = new Repository<Like>(DataContext)); }
		}
		public IRepository<Consultation> Consultations 
		{
			get { return _consultations ?? (_consultations = new Repository<Consultation>(DataContext)); }
		}
		public IRepository<Question> Questions
		{
			get { return _questions ?? (_questions = new Repository<Question>(DataContext)); }
		}
		public void Save() {
			DataContext.SaveChanges();
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (!_disposed) {
				if (disposing) {
					DataContext.Dispose();
				}
				_disposed = true;
			}
		}
	}
}
