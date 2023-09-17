using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration.Ini;
using ASP_PROJ;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string xmlFilePath = "apple.xml";
string jsonFilePath = "microsoft.json";
string iniFilePath = "google.ini";
string jsonMyInfoPath = "me.json";

Company google = Company.setCompanyFromIni(iniFilePath);
Company microsoft = Company.setCompanyFromJson(jsonFilePath);
Company apple = Company.setCompanyFromXML(xmlFilePath);

Company[] company_array = [google, apple, microsoft];


app.MapGet("/", () => apple.Show());
app.MapGet("/most-employeers", () => Company.EmployeersAmountStatistic(company_array));
app.MapGet("/randomInt", () => "" + new Random().Next(0, 101));
app.MapGet("/info", () => MyInfo.GetInfoFromJson(jsonMyInfoPath));
app.Run();




