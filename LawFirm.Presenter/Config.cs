using System.Configuration;
using System.Web.Hosting;

namespace LawFirm.Presenter {
	public static class Config {
		public static string ImagesRootPath { get { return ConfigurationManager.AppSettings["ImagesRootPath"]; } }
		public static string ConnectionString { get { return "DefaultConnection"; } }
	}
}