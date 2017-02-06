using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {
	public class CommentService : BaseService {
		public CommentService(string connectionString) : base(connectionString) {
		}

		public void Add(Comment comment) {
			if (comment == null) {
				throw new ArgumentNullException(nameof(comment));
			}

			comment.CreationTime = DateTime.Now;


			DataContext.Comments.Create(comment);
			DataContext.Save();
		}

		public void Delete(int id) {
			Comment comment = DataContext.Comments.GetById(id);

			if (comment != null) {
				comment.IsDeleted = true;
			}

			DataContext.Comments.Update(comment);
			DataContext.Save();
		}
	}
}
