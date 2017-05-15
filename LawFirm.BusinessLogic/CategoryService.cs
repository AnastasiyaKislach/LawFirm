using LawFirm.Models.Entities;
using System;
using System.Linq;
using LawFirm.Models;

namespace LawFirm.BusinessLogic {
	public class CategoryService : BaseService<Category> {
		public CategoryService(string connectionString) : base(connectionString) {
		}

		public override IQueryable<Category> GetAll() {
			return base.GetAll().Where(i => !i.IsDeleted);
		}

		public IQueryable<CategoryInfo> GetCategoriesInfo() {
			return GetAll().Select(i => new CategoryInfo {
				Id = i.Id,
				Title = i.Title,
				Articles = i.Articles.Count(l => !l.IsDeleted)
			});
		}

	}
}
