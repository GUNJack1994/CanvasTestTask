using Newtonsoft.Json;

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