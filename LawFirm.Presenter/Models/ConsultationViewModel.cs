namespace LawFirm.Presenter.Models {
	public class ConsultationViewModel {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int PracticeId { get; set; }
		public string PracticeTitle { get; set; }
		public string MessageText { get; set; }
	}
}