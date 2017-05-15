using System;
using System.Linq;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {
	public class ConsultationService : BaseService<Consultation> {
		public ConsultationService(string connectionString) : base(connectionString) {
		}

		public override IQueryable<Consultation> GetAll() {
			return base.GetAll().Where(i => !i.IsDeleted);
		}

		public Consultation Add(Consultation consultation) {
			if (consultation == null) {
				throw new ArgumentNullException(nameof(consultation));
			}

			consultation.Name = consultation.Name.Trim();
			consultation.Email = consultation.Email.Trim();
			consultation.Phone = consultation.Phone.Trim();
			consultation.CreationTime = DateTime.Now;
			consultation.MessageText = consultation.MessageText.Trim();

			Consultation newConsultation = Create(consultation);
			Save();

			return newConsultation;
		}

		public override Consultation Delete(int id) {
			Consultation consultation = GetById(id);

			if (consultation != null) {
				consultation.IsDeleted = true;
			}

			Consultation deletedConsultation = Update(consultation);
			Save();

			return deletedConsultation;
		}
	}
}
