using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawFirm.Models.Entities;

namespace LawFirm.Presenter.Models.BlogViewModels {
	public class CommentViewModel {
		public int Id { get; set; }
		public string Author { get; set; }
		public string Text { get; set; }
		public DateTime CreationTime { get; set; }
		public List<Like> Likes { get; set; }
		public int IdLinkedComment { get; set; }
		public int IdBlogItem { get; set; }

		public CommentViewModel(Comment comment) {
			Id = comment.Id;
			Author = comment.Author;
			Text = comment.Text;
			CreationTime = comment.CreationTime;
			Likes = comment.Likes;
			IdBlogItem = comment.IdBlogItem;
			IdLinkedComment = comment.IdLinkedComment;
		}
	}
}