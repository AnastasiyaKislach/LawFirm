using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Models.Entities {
	public class Question : BaseEntity {
		public string QuestionText { get; set; }

		public string Answer { get; set; }
	}
}
