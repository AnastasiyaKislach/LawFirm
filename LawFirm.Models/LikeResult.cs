using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Models {
	public class LikeResult {
		public int Count { get; set; }

		public bool IsLiked { get; set; }

		public int PublicationId { get; set; }
	}
}
