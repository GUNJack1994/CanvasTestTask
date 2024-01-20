using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasReplyTestTask.Support
{
    public class AppConfigReader
    {
        private readonly string configFile = "app.json";

        public AppConfig ReadConfig()
        {
            var json = File.ReadAllText(configFile);
            return JsonConvert.DeserializeObject<AppConfig>(json);
        }
    }
}
