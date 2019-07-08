using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Angular.Template.Service.ApplicationConfiguration
{
    public class Settings
    {
        public string Secret { get; set; }
       
    }

    public class GlobalSettings
    {
        public string WebsiteName { get; set; }
        public string ApiUrl { get; set; }
    }
}
