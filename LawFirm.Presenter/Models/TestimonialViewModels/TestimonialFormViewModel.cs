using System.ComponentModel.DataAnnotations;

namespace LawFirm.Presenter.Models.TestimonialViewModels {

	public class TestimonialFormViewModel {

		[Required(ErrorMessage = "Требуется ввести значение поля")]
		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 2)]
		[Display(Name = "Автор")]
		public string Author { get; set; }

		[Required(ErrorMessage = "Требуется ввести значение поля")]
		[EmailAddress(ErrorMessage = "Введен некорректный адрес электронной почты")]
		[Display(Name = "Адрес электронной почты")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Требуется ввести значение поля")]
		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 2)]
		[Display(Name = "Автор")]
		public string Text { get; set; }
	}
}