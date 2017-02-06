using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Models.Entities {
	public class Like : BaseEntity {

		public int IdUser { get; set; }

		public int IdArticle { get; set; }

		public virtual Article Article { get; set; }

		public virtual Type Type { get; set; }
	}
}
