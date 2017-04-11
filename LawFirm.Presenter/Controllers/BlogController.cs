using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LawFirm.BusinessLogic;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models;
using LawFirm.Presenter.Models.BlogViewModels;
using Microsoft.AspNet.Identity;
using LawFirm.Models;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Helpers;

namespace LawFirm.Presenter.Controllers {

	public class BlogController : BaseController {

		protected ArticleService ArticleService { get; set; }
		protected LikeService LikeService { get; set; }
		protected CommentService CommentService { get; set; }
		protected CategoryService CategoryService { get; set; }

		public BlogController() {
			ArticleService = new ArticleService(AppConfig.ConnectionString);
			LikeService = new LikeService(AppConfig.ConnectionString);
			CommentService = new CommentService(AppConfig.ConnectionString);
			CategoryService = new CategoryService(AppConfig.ConnectionString);
		}

		// GET: Blog
		public ActionResult Index(int pageNumber = 1, int pageSize = 5) {

			BlogView vm = new BlogView {
				ArticlesPage = ArticleService.GetArticlesInfoPage(pageNumber, pageSize),
				LastArticles = ArticleService.GetLastArticles().Select(ToViewModel),
				Categories = CategoryService.GetCategoriesInfo().Select(ToViewModel),
				ArchiveList = ArticleService.GetArchive().Select(ToViewModel)
			};

			vm.ArticlesPage.Select(ToViewModel).ToList();

			return View(vm);
		}

		public ActionResult CateroryArticles(int id, int pageNumber = 1, int pageSize = 5) {
			BlogView vm = new BlogView {
				ArticlesPage = ArticleService.GetArticlesInfoPage(id, pageNumber, pageSize),
				LastArticles = ArticleService.GetLastArticles().Select(ToViewModel),
				Categories = CategoryService.GetCategoriesInfo().Select(ToViewModel),
				ArchiveList = ArticleService.GetArchive().Select(ToViewModel)
			};

			ViewBag.Category = CategoryService.GetById(id).Title;

			vm.ArticlesPage.Select(ToViewModel).ToList();
			return View("Index", vm);
		}


		public ActionResult ArchiveArticles(int month, int year, int pageNumber = 1, int pageSize = 5) {
			BlogView vm = new BlogView {
				ArticlesPage = ArticleService.GetArchiveArticles(month, year, pageNumber, pageSize),
				LastArticles = ArticleService.GetLastArticles().Select(ToViewModel),
				Categories = CategoryService.GetCategoriesInfo().Select(ToViewModel),
				ArchiveList = ArticleService.GetArchive().Select(ToViewModel)
			};

			ViewBag.Archive = ((Monthes)month-1).ToString() + " " + year;

			vm.ArticlesPage.Select(ToViewModel).ToList();
			return View("Index", vm);
		}

		public ActionResult Details(int id) {

			BlogView vm = new BlogView {
				LastArticles = ArticleService.GetLastArticles().Select(ToViewModel),
				Categories = CategoryService.GetCategoriesInfo().Select(ToViewModel),
				ArchiveList = ArticleService.GetArchive().Select(ToViewModel)
			};

			ArticleDetail article = ArticleService.GetArticleDetail(id);

			vm.CurrentArticle = ToViewModel(article);

			if (User.Identity.IsAuthenticated) {
				string userId = User.Identity.GetUserId();
				vm.CurrentArticle.Likes.IsLiked = LikeService.IsLikedArticle(userId, id);
			}
			else {
				vm.CurrentArticle.Likes.IsLiked = false;
			}

			vm.CurrentArticle.Comments = CommentHelper.GetCommentTree(id, CommentService);

			return View(vm);
		}


		protected ArticleInfo ToViewModel(ArticleInfo model) {

			model.ImagePath = AppConfig.BlogImagesPath + model.ImagePath;

			if (!String.IsNullOrEmpty(model.Text) && model.Text.Length > 200) {
				model.Text = String.Format("{0}...", model.Text.Substring(0, 200));
			}

			return model;
		}

		protected LastArticle ToViewModel(LastArticle model) {
			model.ImagePath = AppConfig.BlogImagesPath + model.ImagePath;
			return model;
		}

		protected ArticleViewModel ToViewModel(ArticleDetail model) {
			model.ImagePath = AppConfig.BlogImagesPath + model.ImagePath;
			return new ArticleViewModel {
				Id = model.Id,
				Title = model.Title,
				Text = model.Text,
				CategoryId = model.CategoryId,
				CreationTime = model.CreationTime,
				ImagePath = model.ImagePath,
				Likes = new LikeViewModel {
					Count = model.Likes,
					PublicationId = model.Id
				},
				Comments = model.Comments.Select(CommentHelper.ToViewModel).ToList(),
				TotalComments = model.Comments.Count()
			};
		}
		public CategoryViewModel ToViewModel(CategoryInfo category) {
			return new CategoryViewModel {
				Id = category.Id,
				Title = category.Title,
				Articles = category.Articles
			};
		}

		public ArchiveViewModel ToViewModel(Archive archive) {
			return new ArchiveViewModel {
				Month = archive.Month,
				MonthNum = archive.MonthNum,
				Year = archive.Year
			};
		}

	}
}

//ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());