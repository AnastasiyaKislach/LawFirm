using LawFirm.Models.Entities;
using System;
using System.Linq;
using LawFirm.Models;

namespace LawFirm.BusinessLogic {
	public class LikeService : BaseService {

		public LikeService(string connectionString) : base(connectionString) {
		}

		public IQueryable<Like> GetAll() {
			return DataContext.Likes.GetAll().Where(i => !i.IsDeleted);
		}
		
		public bool IsLikedArticle(string userId, int articleId) {

			Article article = DataContext.Articles.GetById(articleId);

			if (article == null){
				return false;
			}

			Like like = article.Likes.FirstOrDefault(i => i.ApplicationUserId == userId && !i.IsDeleted);

			if (like == null){
				return false;
			}

			return true;
		}

		public bool IsLikedComment(string userId, int commentId) {

			Comment comment = DataContext.Comments.GetById(commentId);

			if (comment == null) {
				return false;
			}

			Like like = comment.Likes.FirstOrDefault(i => i.ApplicationUserId == userId && !i.IsDeleted);

			if (like == null) {
				return false;
			}

			return true;
		}

		public LikeResult LikeArticle(string userId, int articleId) {

			Article article = DataContext.Articles.GetById(articleId);

			if (article != null) {

				Like like = article.Likes.FirstOrDefault(i => i.ApplicationUserId == userId && !i.IsDeleted);

				if (like == null) {

					like = new Like {
						ApplicationUserId = userId,
						IsDeleted = false
					};

					article.Likes.Add(like);

					DataContext.Articles.Update(article);
				}
				else {

					like.IsDeleted = !like.IsDeleted;

					DataContext.Likes.Update(like);
				}

				Save();

				LikeResult likeResult = new LikeResult {
					Count = article.Likes.Count(i => i.IsDeleted == false),
					IsLiked = !like.IsDeleted,
					PublicationId = articleId
				};

				return likeResult;
			}

			return null;
		}

		public LikeResult LikeComment(string userId, int commentId) {

			Comment comment = DataContext.Comments.GetById(commentId);

			if (comment != null) {

				Like like = comment.Likes.FirstOrDefault(i => i.ApplicationUserId == userId && !i.IsDeleted);

				if (like == null) {

					like = new Like {
						ApplicationUserId = userId,
						IsDeleted = false
					};

					comment.Likes.Add(like);

					DataContext.Comments.Update(comment);
				}
				else {

					like.IsDeleted = !like.IsDeleted;

					DataContext.Likes.Update(like);
				}

				Save();

				LikeResult likeResult = new LikeResult {
					Count = comment.Likes.Count(i => i.IsDeleted == false),
					IsLiked = !like.IsDeleted,
					PublicationId = commentId
				};

				return likeResult;
			}

			return null;
		}


		public Like Delete(Like like) {

			if (like == null) {
				throw new ArgumentNullException(nameof(like));
			}

			Delete(like);

			return like;
		}

		public Like Delete(int likeId) {

			Like like = DataContext.Likes.GetById(likeId);

			if (like != null) {
				like.IsDeleted = true;
			}

			DataContext.Likes.Update(like);
			Save();

			return like;
		}

		public Like Recovery(Like like) {

			if (like == null) {
				throw new ArgumentNullException(nameof(like));
			}

			Recovery(like);

			return like;
		}

		public Like Recovery(int likeId) {

			Like like = DataContext.Likes.GetById(likeId);

			if (like != null) {
				like.IsDeleted = false;
			}

			DataContext.Likes.Update(like);
			Save();

			return like;
		}

		public Like Remove(Like like) {

			if (like == null) {
				throw new ArgumentNullException(nameof(like));
			}

			DataContext.Likes.Delete(like);
			Save();

			return like;
		}

		public Like Remove(int likeId) {

			Like like = DataContext.Likes.GetById(likeId);

			if (like != null) {
				Remove(like);
			}

			return like;
		}
	}
}
