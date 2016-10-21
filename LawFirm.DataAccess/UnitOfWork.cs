using System;
using LawFirm.DataAccess.Contracts;
using LawFirm.Models.Entities;

namespace LawFirm.DataAccess {
	public class UnitOfWork : IUnitOfWork {

		protected DataContext DataContext;
		private IRepository<Slider> _slides;
		private IRepository<Setting> _settings;
		private bool _disposed;

		public UnitOfWork(string connectionString) {
			DataContext = new DataContext(connectionString);
		}

		public IRepository<Slider> Slides {
			get { return _slides ?? (_slides = new Repository<Slider>(DataContext)); }
		}

		public IRepository<Setting> Settings {
			get { return _settings ?? (_settings = new Repository<Setting>(DataContext)); }
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
