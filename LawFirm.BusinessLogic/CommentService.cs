using System;
using System.Collections.Generic;
using System.Linq;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {
	public class CommentService : BaseService {
		public CommentService(string connectionString) : base(connectionString) {
		}

		public Comment Add(Comment comment) {

			if (comment == null) {
				throw new ArgumentNullException(nameof(comment));
			}

			comment.CreationTime = DateTime.Now;

			if (comment.ParentCommentId.HasValue)
			{
				Comment parentComment = GetById(comment.ParentCommentId.Value);

				if (parentComment != null)
				{
					comment.Level = parentComment.Level + 1;
				}
			}

			comment = DataContext.Comments.Create(comment);
			DataContext.Save();

			return comment;
		}

		public IQueryable<Comment> GetAll() {
			return DataContext.Comments.GetAll().Where(i => !i.IsDeleted);
		}

		public IQueryable<Comment> GetAllByArticleId(int articleId) {
			return DataContext.Comments.GetAll().Where(i => !i.IsDeleted && i.ArticleId == articleId);
		}

		public List<Comment> GetReplies(int idComment) {
			return GetAll().Where(i => i.ParentCommentId == idComment).OrderByDescending(i => i.CreationTime).ToList();
		}

		public Comment GetById(int id) {
			Comment comment = DataContext.Comments.GetById(id);
			return comment;
		}
		public void Delete(int id) {
			Comment comment = DataContext.Comments.GetById(id);

			if (comment != null) {
				comment.IsDeleted = true;
			}

			DataContext.Comments.Update(comment);
			DataContext.Save();
		}

		public int GetDepth(int articleId) {
			List<Comment> comments = GetAllByArticleId(articleId).ToList();
			if (comments.Count == 0) {
				return 0;
			}
			return comments.Max(i => i.Level);
		}
		
	}
}
