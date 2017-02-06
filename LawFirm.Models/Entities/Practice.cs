using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Models.Entities {
	public class Practice : BaseEntity{
		public string Title { get; set; }
		public string Text { get; set; }
		public string ImagePath { get; set; }
	}
}
