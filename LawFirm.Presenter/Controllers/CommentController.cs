﻿using LawFirm.BusinessLogic;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Models.CommentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawFirm.Presenter.Models.BlogViewModels;

namespace LawFirm.Presenter.Controllers {
	public class CommentController : BaseController {
		public CommentService Service { get; set; }


		public ActionResult CreateComment(CommentFormViewModel model) {
			if (!ModelState.IsValid) {
				return PartialView("_CommentForm", model);
			}

			bool result = true;
			//необходимо извлечь пользователя
			try {
				Comment comment = ToModel(model);

				Service.Add(comment);
			}
			catch {
				result = false;
			}

			return PartialView("_CommentFormResult", result);
		}

		[HttpGet]
		public ActionResult CommentForm() {
			return PartialView("_CommentForm", new CommentFormViewModel());
		}

		protected CommentViewModel ToVewModel(Comment model) {
			return new CommentViewModel {
				Id = model.Id,
				ApplicationUserId = model.ApplicationUserId,
				Text = model.Text,
				CreationTime = model.CreationTime,
				LinkedCommentId = model.LinkedCommentId,
				ArticleId = model.ArticleId
			};
		}

		protected Comment ToModel(CommentFormViewModel model) {
			return new Comment {
				Text = model.Text,
				CreationTime = model.CreationTime,
				LinkedCommentId = model.LinkedCommentId,
				ArticleId = model.ArticleId
			};
		}
	}
}