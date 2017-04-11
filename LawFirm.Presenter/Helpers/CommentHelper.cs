using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawFirm.BusinessLogic;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Models;
using LawFirm.Presenter.Models.BlogViewModels;
using LawFirm.Presenter.Models.CommentViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LawFirm.Presenter.Helpers {
	public static class CommentHelper {
		public static List<CommentViewModel> GetCommentTree(int articleId, CommentService commentService) {
			int depth = commentService.GetDepth(articleId);
			List<CommentViewModel> commentViewModels = new List<CommentViewModel>();

			List<Comment> comments = commentService.GetAllByArticleId(articleId).ToList();

			for (int i = 0; i < comments.Count; i++) {
				commentViewModels.Add(ToViewModel(comments[i]));
			}

			for (int i = depth; i >= 0; i--) {
				List<CommentViewModel> list = commentViewModels.FindAll(c => c.Level == i);
				for (int j = 0; j < list.Count; j++) {
					CommentViewModel vm = commentViewModels.Find(c => c.Id == list[j].Id);
					if (list[j].ParentCommentId.HasValue) {
						CommentViewModel vmparent = commentViewModels.Find(c => c.Id == list[j].ParentCommentId.Value);

						if (vmparent != null) {
							commentViewModels.Find(c => c.Id == list[j].ParentCommentId).Replies.Add(vm);
						}
					}

				}
			}
			return commentViewModels.Where(i => !i.ParentCommentId.HasValue).ToList();

		}

		public static CommentViewModel ToViewModel(Comment model) {
			return new CommentViewModel {
				Id = model.Id,
				ApplicationUserId = model.ApplicationUserId,
				ApplicationUserName = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(model.ApplicationUserId).Email,
				Text = model.Text,
				CreationTime = model.CreationTime,
				ParentCommentId = model.ParentCommentId,
				ArticleId = model.ArticleId,
				Likes = new LikeViewModel {
					Count = model.Likes.Count,
					PublicationId = model.Id,
					IsLiked = model.Likes.Count > 0
				},
				Level = model.Level
			};
		}

	}
}