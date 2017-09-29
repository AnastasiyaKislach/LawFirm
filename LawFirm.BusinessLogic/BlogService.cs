using System;
using System.Collections.Generic;
using System.Linq;
using LawFirm.Models.Entities;
using PagedList;
using LawFirm.Models;

namespace LawFirm.BusinessLogic {

	public class ArticleService : BaseService<Article> {

		public ArticleService(string connectionString) : base(connectionString) {
		}

		public override IQueryable<Article> GetAll() {
			return base.GetAll().Where(i => !i.IsDeleted);
		}

		public Article Add(Article blogItem) {
			if (blogItem == null) {
				throw new ArgumentNullException(nameof(blogItem));
			}

			blogItem.CreationTime = DateTime.Now;

			Article newArticle = Create(blogItem);
			Save();

			return newArticle;
		}

		public Article Edit(Article blogItem) {
			if (blogItem == null) {
				throw new ArgumentNullException(nameof(blogItem));
			}

			Article updatedArticle = Update(blogItem);
			Save();

			return updatedArticle;
		}

		public Article Delete(int id) {
			Article article = DataContext.Articles.GetById(id);

			if (article != null) {
				article.IsDeleted = true;
			}

			Article deletedArticle = Update(article);
			Save();

			return deletedArticle;
		}

		public IPagedList<ArticleInfo> GetArticlesInfoPage(int pageNumber, int pageSize) {

			IQueryable<ArticleInfo> items = GetAll()
				.Select(i => new ArticleInfo {
					Id = i.Id,
					Text = i.Text,
					Title = i.Title,
					ImagePath = i.ImagePath,
					CreationTime = i.CreationTime,
					Comments = i.Comments.Count(l => !l.IsDeleted),
					Likes = i.Likes.Count(l => !l.IsDeleted)
				})
				.OrderByDescending(i => i.CreationTime);

			IPagedList<ArticleInfo> page = items.ToPagedList(pageNumber, pageSize);
			return page;
		}

		public IPagedList<ArticleInfo> GetArticlesInfoPage(int id, int pageNumber, int pageSize) {

			IQueryable<ArticleInfo> items = GetAll()
				.Where(i => i.CategoryId == id)
				.Select(i => new ArticleInfo {
					Id = i.Id,
					Text = i.Text,
					Title = i.Title,
					ImagePath = i.ImagePath,
					CreationTime = i.CreationTime,
					Comments = i.Comments.Count(l => !l.IsDeleted),
					Likes = i.Likes.Count(l => !l.IsDeleted)
				})
				.OrderByDescending(i => i.CreationTime);

			IPagedList<ArticleInfo> page = items.ToPagedList(pageNumber, pageSize);
			return page;
		}

		public IPagedList<ArticleInfo> GetArchiveArticles(int month, int year, int pageNumber, int pageSize) {

			IQueryable<ArticleInfo> items = GetAll()
				.Where(i => i.CreationTime.Month == month && i.CreationTime.Year == year)
				.Select(i => new ArticleInfo {
					Id = i.Id,
					Text = i.Text,
					Title = i.Title,
					ImagePath = i.ImagePath,
					CreationTime = i.CreationTime,
					Comments = i.Comments.Count(l => !l.IsDeleted),
					Likes = i.Likes.Count(l => !l.IsDeleted)
				})
				.OrderByDescending(i => i.CreationTime);

			IPagedList<ArticleInfo> page = items.ToPagedList(pageNumber, pageSize);
			return page;
		}

		public IQueryable<LastArticle> GetLastArticles(int count = 6) {

			IQueryable<LastArticle> items = GetAll()
				.OrderByDescending(i => i.CreationTime)
				.Take(count)
				.Select(i => new LastArticle {
					Id = i.Id,
					Title = i.Title,
					ImagePath = i.ImagePath,
					CreationTime = i.CreationTime
				});

			return items;
		}

		public ArticleDetail GetArticleDetail(int id) {
			Article article = GetById(id);
			ArticleDetail detail = new ArticleDetail() {
				Id = article.Id,
				Title = article.Title,
				Text = article.Text,
				CategoryId = article.CategoryId,
				ImagePath = article.ImagePath,
				Likes = article.Likes.Count(i => !i.IsDeleted),
				Comments = article.Comments.Where(i => !i.IsDeleted).ToList(),
				CreationTime = article.CreationTime
			};
			return detail;
		}

		public IEnumerable<Archive> GetArchive() {
			List<Archive> archives = new List<Archive>();
			int minYear = GetAll().Min(i => i.CreationTime.Year);
			int maxYear = GetAll().Max(i => i.CreationTime.Year);

			for (int i = minYear; i <= maxYear; i++) {
				int maxMonth = DataContext.Articles.GetAll().Where(k => k.CreationTime.Year == i).Max(l => l.CreationTime.Month) - 1;
				int minMonth = DataContext.Articles.GetAll().Where(k => k.CreationTime.Year == i).Min(l => l.CreationTime.Month) - 1;
				for (int j = minMonth; j <= maxMonth; j++) {
					List<Article> list = DataContext.Articles.GetAll().Where(k => k.CreationTime.Year == i && k.CreationTime.Month == j + 1).ToList();
					if (list.Count > 0) { //надо проверить точно
						archives.Add(new Archive {
							Month = ((Monthes)j).ToString(),
							MonthNum = j + 1,
							Year = i
						});
					}
				}

			}
			return archives;
		}
	}
}
