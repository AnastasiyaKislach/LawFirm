using System.Data.Entity;
using LawFirm.Models.Entities;

namespace LawFirm.DataAccess {
	public class DataContext : DbContext {

		public virtual DbSet<Slider> Slides { get; set; }
		public virtual DbSet<Setting> Settings { get; set; }

		public DataContext(string connectionString)
			: base(connectionString) {

		}
	}
}
