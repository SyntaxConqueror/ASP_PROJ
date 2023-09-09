var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Company company = new Company("MyCompany", "The best company ever", 20000000);

app.MapGet("/", () => company.Show());
app.MapGet("/randomInt", () => "" + new Random().Next(0, 101));
app.Run();




class Company
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public Company(string name, string description, int price)
    {
        this.Name = name;
        this.Description = description;
        this.Price = price;
    }
    public string Show()
    {
        return ("Name of the company: " + this.Name + 
            "\nCompany information: " + this.Description + 
            "\nPrice of the company: " + this.Price);
    }
}




