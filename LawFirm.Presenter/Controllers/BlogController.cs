using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using LawFirm.BusinessLogic;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models;
using LawFirm.Presenter.Models.BlogViewModels;

namespace LawFirm.Presenter.Controllers {
	public class BlogController : BaseController {
		protected BlogService Service { get; set; }

		public BlogController() {
			Service = new BlogService(AppConfig.ConnectionString);
			//for (int i = 0; i < 2; i++) {
			//	Article article = new Article() {
			//		Title = "Локальный репозиторий",
			//		CreationTime = DateTime.Now,
			//		ImagePath = "~/Images/Blog/Blog-photos.jpg",
			//		Text = "Локальный репозиторий",
			//		CategoryId = 2
			//	};
			//	Service.Add(article);
			//}


		}

		// GET: Blog
		public ActionResult Index() {

			BlogView vm = new BlogView {
				Articles = Service.GetAll().Select(ToVewModel),
				
			};


			return View(vm);
		}

		public ActionResult Details(int id) {
			Article article = Service.GetById(id);
			ArticleViewModel vm = new ArticleViewModel {
				Id = article.Id,
				Title = article.Title,
				Text = article.Text,
				ImagePath = article.ImagePath,
				CreationTime = article.CreationTime,
				CategoryId = article.CategoryId,
				//Likes = article.
			};
			return View(vm);
		}

		//public ActionResult CreateBlogItem(BlogViewModel model) {

		//	if (!ModelState.IsValid) {
		//		return PartialView("_CommentForm", model);
		//	}

		//	bool result = true;

		//	try {
		//		BlogItem blogItem = ToModel(model);

		//		Service.Add(blogItem);
		//	}
		//	catch {
		//		result = false;
		//	}

		//	return PartialView("_CommentFormResult");
		//}

		//private BlogItem ToModel(BlogViewModel model) {
		//	return new BlogItem()
		//	{
		//		Text = model.Text,
		//		IdCategory = model.IdCategory,
		//		Comments = model.Comments.Select(ToModel).ToList(),
		//		Likes = model.Likes

		//	};
		//}

		protected ArticleViewModel ToVewModel(Article model) {
			return new ArticleViewModel {
				Id = model.Id,
				Title = model.Title,
				ImagePath = model.ImagePath,
				Text = model.Text,
				CreationTime = model.CreationTime,
				//Comments = model.Comments, //преобразовать надо блин
				//Likes = model.Likes,
				CategoryId = model.CategoryId
			};
		}
	}
}