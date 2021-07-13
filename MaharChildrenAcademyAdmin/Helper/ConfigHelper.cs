using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace MaharChildrenAcademyAdmin.Helper
{
    public class ConfigHelper
    {
        private const string _BASEURL = "baseUrl";
        private const string _URL_CATEGORY = "categoryUrl";
        private const string _UPLOADLOCATION = "uploadlocation";
       
        static NameValueCollection ConfigAppSettings
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings;
            }
        }

        public static string UPLOAD_LOCATION
        {
            get
            {
                return Convert.ToString(ConfigAppSettings[_UPLOADLOCATION]);
            }
        }

        public static string BASE_URL
        {
            get
            {
                return Convert.ToString(ConfigAppSettings[_BASEURL]);
            }
        }
        public static string SECURITY_KEY
        {
            get
            {
                return String.Empty;
            }
        }
    }
}