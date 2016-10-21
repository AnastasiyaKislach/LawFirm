using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LawFirm.Models;
using LawFirm.Models.Entities;

namespace LawFirm.BusinessLogic {
	public class SettingsService : BaseService {

		public SettingsService(string connectionString) : base(connectionString) { }

		public AppSettings GetSettings() {

			AppSettings appSettings = new AppSettings();
			PropertyInfo[] properties = typeof(AppSettings).GetProperties();
			List<Setting> settings = DataContext.Settings.GetAll().ToList();

			foreach (PropertyInfo property in properties) {
				if (property.CanWrite) {
					Setting set = settings.FirstOrDefault(i => i.Key == property.Name);
					if (set != null) {
						property.SetValue(appSettings, set.Value);
					}
				}
			}

			return appSettings;
		}
	}
}
