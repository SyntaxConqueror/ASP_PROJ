using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml;

namespace ASP_PROJ
{
    public class Company
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

        public static Company setCompanyFromIni(string filePath)
        {
            IniParser iniParser = new IniParser(filePath);

            string name = iniParser.GetSetting("Company", "name");
            int empl_amount = int.Parse(iniParser.GetSetting("Company", "employeers_amount"));
            long budget = long.Parse(iniParser.GetSetting("Company", "budget"));

            return new Company(name, empl_amount, budget);
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
}
