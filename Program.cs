using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration.Ini;
using ASP_PROJ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<CalcService>();

var app = builder.Build();

string xmlFilePath = "apple.xml";
string jsonFilePath = "microsoft.json";
string iniFilePath = "google.ini";
string jsonMyInfoPath = "me.json";

Company google = Company.setCompanyFromIni(iniFilePath);
Company microsoft = Company.setCompanyFromJson(jsonFilePath);
Company apple = Company.setCompanyFromXML(xmlFilePath);

Company[] company_array = [google, apple, microsoft];

app.MapGet("/most-employeers", () => Company.EmployeersAmountStatistic(company_array));
app.MapGet("/randomInt", () => "" + new Random().Next(0, 101));
app.MapGet("/info", () => MyInfo.GetInfoFromJson(jsonMyInfoPath));
app.MapGet("/calc", () => app.Services.GetService<CalcService>().Mult(3.5, 6.4));

app.Run(async context =>
{
    var calcService = app.Services.GetService<CalcService>();
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync($"Time: {calcService?.GetTime()}");
});

app.Run();




