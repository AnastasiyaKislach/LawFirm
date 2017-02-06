using System;

namespace LawFirm.Models.Entities {

	public class Testimonial : BaseEntity {

		public string Author { get; set; }

		public string Email { get; set; }

		public string Text { get; set; }

		public DateTime CreationTime { get; set; }

		public bool IsApprove { get; set; }
	}
}