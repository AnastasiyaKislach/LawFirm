using System.Collections.Generic;

namespace LawFirm.Models.Entities {
	public class Category : BaseEntity {
		public string Title { get; set; }
		public List<Article> Articles { get; set; }

		public Category() {
			Articles = new List<Article>();
		}
	}
}
