using System;
using System.Collections.Generic;
using System.IO;

namespace RemoteDeployManager
{
    public class ConfigLoader
    {
        public string TargetFolder { get; private set; }
        public Dictionary<string, List<string>> ServerFileMappings { get; private set; } = new Dictionary<string, List<string>>();

        public bool LoadConfig(string path)
        {
            if (!File.Exists(path))
                return false;

            var lines = File.ReadAllLines(path);
            string currentSection = null;

            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                if (currentSection == null)
                {
                    TargetFolder = trimmed;
                    currentSection = "TargetLoaded";
                }
                else
                {
                    if (trimmed.StartsWith("<") && trimmed.EndsWith(">"))
                    {
                        var serverName = trimmed.Trim('<', '>');
                        ServerFileMappings[serverName] = new List<string>();
                        currentSection = serverName;
                    }
                    else if (currentSection != "TargetLoaded")
                    {
                        ServerFileMappings[currentSection].Add(trimmed);
                    }
                }
            }

            return true;
        }
    }
}
