using System;
using System.Linq;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {
	public class ConsultationService : BaseService{
		public ConsultationService(string connectionString) : base(connectionString) {
		}

		public IQueryable<Consultation> GetAll() {
			return DataContext.Consultations.GetAll().Where(i => !i.IsDeleted);
		}

		public void Add(Consultation consultation) {
			if (consultation == null) {
				throw new ArgumentNullException(nameof(consultation));
			}

			consultation.Name = consultation.Name.Trim();
			consultation.Email = consultation.Email.Trim();
			consultation.Phone = consultation.Phone.Trim();
			consultation.CreationTime = DateTime.Now;
			consultation.MessageText = consultation.MessageText.Trim();

			DataContext.Consultations.Create(consultation);
			DataContext.Save();
		}

		public void Delete(int id) {
			Consultation consultation = DataContext.Consultations.GetById(id);

			if (consultation != null) {
				consultation.IsDeleted = true;
			}

			DataContext.Consultations.Update(consultation);
			DataContext.Save();
		}
	}
}
