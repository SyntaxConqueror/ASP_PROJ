namespace ASP_PROJ
{
    public class IniParser
    {
        private readonly Dictionary<string, Dictionary<string, string>> sections
        = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

        public IniParser(string filePath)
        {
            ParseFile(filePath);
        }

        public string GetSetting(string section, string key)
        {
            if (sections.ContainsKey(section) && sections[section].ContainsKey(key))
            {
                return sections[section][key];
            }
            return null;
        }

        private void ParseFile(string filePath)
        {
            string currentSection = string.Empty;

            foreach (var line in File.ReadLines(filePath))
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    sections[currentSection] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }
                else if (!string.IsNullOrWhiteSpace(trimmedLine) && currentSection != null)
                {
                    var parts = trimmedLine.Split('=');
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        sections[currentSection][key] = value;
                    }
                }
            }
        }
    }
}
