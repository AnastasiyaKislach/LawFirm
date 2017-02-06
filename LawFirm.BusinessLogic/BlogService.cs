using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {
	public class BlogService : BaseService {
		public BlogService(string connectionString) : base(connectionString) {
		}

		public IQueryable<Article> GetAll() {
			return DataContext.Articles.GetAll().Where(i => !i.IsDeleted);
		}

		public void Add(Article blogItem) {
			if (blogItem == null) {
				throw new ArgumentNullException(nameof(blogItem));
			}

			blogItem.CreationTime = DateTime.Now;
			

			DataContext.Articles.Create(blogItem);
			DataContext.Save();
		}

		public Article GetById(int id) {
			Article article = DataContext.Articles.GetById(id);
			return article;
		}


		public void Delete(int id) {
			Article article = DataContext.Articles.GetById(id);

			if (article != null) {
				article.IsDeleted = true;
			}

			DataContext.Articles.Update(article);
			DataContext.Save();
		}
	}
}
