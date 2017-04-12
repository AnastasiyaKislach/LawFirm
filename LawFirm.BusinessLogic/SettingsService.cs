using System;
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

		public void SetSetting(AppSettings settings) {

			var properties = typeof(AppSettings).GetProperties();

			foreach (var p in properties) {

				var set = DataContext.Settings.GetAll().FirstOrDefault(i => i.Key == p.Name);

				if (set == null) {
					DataContext.Settings.Create(new Setting() {
						Key = p.Name,
						Value = (p.GetValue(settings) ?? String.Empty).ToString()
					});
					DataContext.Save();
				}
				else {
					set.Value = (p.GetValue(settings) ?? String.Empty).ToString();
					DataContext.Settings.Update(set);
					DataContext.Save();
				}
			}
		}
	}
}
