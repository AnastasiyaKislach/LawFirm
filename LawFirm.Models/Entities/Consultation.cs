using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Models.Entities {
	public class Consultation : BaseEntity{
		public string Name { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string MessageText { get; set; }

		public DateTime CreationTime { get; set; }

		public int IdPracticeArea { get; set; }
		
		public Practice Practice { get; set; }

	}
}
