using LawFirm.Models.Entities;
using System;
using System.Linq;
using LawFirm.Models;

namespace LawFirm.BusinessLogic {
	public class CategoryService : BaseService {
		public CategoryService(string connectionString) : base(connectionString) {
		}

		public IQueryable<Category> GetAll() {
			return DataContext.Categories.GetAll().Where(i => !i.IsDeleted);
		}

		public IQueryable<CategoryInfo> GetCategoriesInfo() {
			return GetAll().Select(i => new CategoryInfo {
				Id = i.Id,
				Title = i.Title,
				Articles = i.Articles.Count(l => !l.IsDeleted)
			});
		}

		public Category GetById(int id) {
			Category category = DataContext.Categories.GetById(id);
			return category;
		}


	}
}
