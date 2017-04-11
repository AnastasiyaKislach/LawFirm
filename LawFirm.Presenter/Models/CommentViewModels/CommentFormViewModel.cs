using System.ComponentModel.DataAnnotations;

namespace LawFirm.Presenter.Models.CommentViewModels {

	public class CommentFormViewModel {

		[Required(ErrorMessage = "Текст комментария обязателен")]
		public string Text { get; set; }

		[Required]
		public int? ArticleId { get; set; }

		public int? ParentCommentId { get; set; }

	}
}