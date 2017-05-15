using System;

namespace LawFirm.Presenter.Models.TestimonialViewModels {

	public class TestimonialViewModel {
		public int Id { get; set; }

		public string Author { get; set; }

		public string Email { get; set; }

		public string Text { get; set; }

		public DateTime CreationTime { get; set; }

		public bool IsApproved { get; set; }
	}
}