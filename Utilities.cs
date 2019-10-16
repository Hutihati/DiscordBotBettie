using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace DiscordBot
{
    class Utilities
    {
        private static readonly Dictionary<string, string> Alerts;
        static Utilities()
        {
            var json = File.ReadAllText("SystemLang/alerts.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            Alerts = data.ToObject<Dictionary<string, string>>();
        }

        public static string GetAlert(string key)
        {
            return Alerts.ContainsKey(key) ? Alerts[key] : "";
        }
        public static string GetAlert(string key, params object[] parameter)
        {
            return Alerts.ContainsKey(key) ? string.Format(Alerts[key], parameter) : "";
        }
    }
}
