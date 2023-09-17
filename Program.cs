using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration.Ini;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();




string xmlFilePath = "..\\..\\..\\apple.xml";
string jsonFilePath = "..\\..\\..\\microsoft.json";
string iniFilePath = "..\\..\\..\\google.ini";
string jsonMyInfoPath = "..\\..\\..\\me.json";

Company google = Company.setCompanyFromIni(iniFilePath);
Company microsoft = Company.setCompanyFromJson(jsonFilePath);
Company apple = Company.setCompanyFromXML(xmlFilePath);

Company[] company_array = [google, apple, microsoft];



app.MapGet("/", () => apple.Show());
app.MapGet("/most-employeers", () => Company.EmployeersAmountStatistic(company_array));
app.MapGet("/randomInt", () => "" + new Random().Next(0, 101));
app.MapGet("/info", () => MyInfo.GetInfoFromJson(jsonMyInfoPath));
app.Run();




class Company
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("employeers_amount")]
    public int Employeers_amount { get; set; }

    [JsonPropertyName("budget")]
    public long Budget { get; set; }

    public Company(string name, int employeers_amount, long budget)
    {
        this.Name = name;
        this.Employeers_amount = employeers_amount;
        this.Budget = budget;
    }
    public string Show()
    {
        return ("Name of the company: " + this.Name + 
            "\nCompany employeers amount: " + this.Employeers_amount + 
            "\nBudget of the company: " + this.Budget);
    }

    public static Company setCompanyFromXML(string filePath)
    {
        XmlReader reader = XmlReader.Create(filePath, new XmlReaderSettings { IgnoreWhitespace = true });
        
        reader.ReadStartElement("Company");
        
        string name = reader.ReadElementContentAsString("name", "");
        int empl_amount = reader.ReadElementContentAsInt("employeers_amount", "");
        long budget = reader.ReadElementContentAsLong("budget", "");
        
        return new Company(name, empl_amount, budget);
    }

    public static Company setCompanyFromIni (string filePath)
    {
        IniParser iniParser = new IniParser(filePath);

        string name = iniParser.GetSetting("Company", "name");
        int empl_amount = int.Parse(iniParser.GetSetting("Company", "employeers_amount"));
        long budget = long.Parse(iniParser.GetSetting("Company", "budget"));
        
        return new Company (name, empl_amount, budget);
    }

    public static Company setCompanyFromJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        
        return JsonSerializer.Deserialize<Company>(jsonString);
    }

    public static string EmployeersAmountStatistic(Company[] company_array)
    {
        if (company_array == null || company_array.Length == 0)
        {
            return null;
        }

        Company companyWithMaxEmployees = company_array[0];
        int maxEmployees = companyWithMaxEmployees.Employeers_amount;

        foreach (Company company in company_array)
        {
            if (company.Employeers_amount > maxEmployees)
            {
                maxEmployees = company.Employeers_amount;
                companyWithMaxEmployees = company;
            }
        }

        return "Name of the company which have the max amount of employeers is: " + companyWithMaxEmployees.Name;
    }
}

class MyInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }
    
    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("destination")]
    public string Destination { get; set; }

    public static string GetInfoFromJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        MyInfo myInfo = JsonSerializer.Deserialize<MyInfo>(jsonString);

        string formattedInfo = $"Name: {myInfo.Name}\n" +
                            $"Last name: {myInfo.LastName}\n" +
                            $"Age: {myInfo.Age}\n" +
                            $"Destination: {myInfo.Destination}";

        return formattedInfo;
    }
}


public class IniParser
{
    private readonly Dictionary<string, Dictionary<string, string>> sections = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

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



