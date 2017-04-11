using System.Configuration;
using System.Web.Configuration;

namespace LawFirm.Presenter.Config {

	public static class AppConfig {

		public static string ConnectionStringName { get { return WebConfigurationManager.AppSettings["ConnectionStringName"]; } }

		public static string ConnectionString
		{
			get
			{
				return WebConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
			}
		}

		public static string ImagesRootPath { get { return ConfigurationManager.AppSettings["ImagesRootPath"] ?? string.Empty; } }

		public static string BlogImagesPath { get { return ImagesRootPath + "/Blog/"; } }

		public static string PracticeImagesPath { get { return ImagesRootPath + "/PracticeArea/"; } }
	}

}