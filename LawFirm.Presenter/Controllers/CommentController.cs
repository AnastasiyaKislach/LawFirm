using LawFirm.BusinessLogic;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Models.CommentViewModels;
using System;
using System.Net;
using System.Web.Mvc;
using LawFirm.Presenter.Attributes;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Helpers;
using Microsoft.AspNet.Identity;

namespace LawFirm.Presenter.Controllers {
	public class CommentController : BaseController {
		protected CommentService Service;

		public CommentController() {
			Service = new CommentService(AppConfig.ConnectionString);
		}
		
		[HttpPost]
		[AuthorizeRedirect(IsJson = true)]
		public ActionResult Create(CommentFormViewModel model) {

			if (!ModelState.IsValid) {
				return PartialView("_CommentForm", model);
			}
			
			string userId = User.Identity.GetUserId();

			try {
				Comment comment = ToModel(model, userId);
				
				Comment newComment = Service.Add(comment);

				CommentViewModel vm = CommentHelper.ToViewModel(newComment);

				return PartialView("_Comment", vm);
			}
			catch (Exception e) {
				return PartialView("_CommentFormResult", e.Message);
			}
		}

		
		public ActionResult Reply(int idArticle, int idComment) {
			if (!User.Identity.IsAuthenticated) {
				return Json(new { statusCode = HttpStatusCode.Redirect, redirectUrl = Url.Action("Login", "Account") });
			}
			CommentFormViewModel vm = new CommentFormViewModel() {
				ArticleId = idArticle,
				ParentCommentId = idComment
			};
			return PartialView("_ReplyForm", vm);
		}

		protected Comment ToModel(CommentFormViewModel model, string userId) {
			return new Comment {
				Text = model.Text,
				ArticleId = model.ArticleId ?? 0,
				ApplicationUserId = userId,
				ParentCommentId = model.ParentCommentId
			};
		}
	}
}