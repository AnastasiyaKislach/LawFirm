using System;
using LawFirm.Models.Entities;

namespace LawFirm.DataAccess.Contracts {
	public interface IUnitOfWork : IDisposable {
		IRepository<Slider> Slides { get; }
		IRepository<Setting> Settings { get; }

		void Save();
	}
}