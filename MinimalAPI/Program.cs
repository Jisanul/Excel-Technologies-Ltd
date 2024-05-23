using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.DBContexts;
using LibraryManagementSystem.Repository;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWebApi(typeof(Program));

var objBuilder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
IConfiguration conManager = objBuilder.Build();
var conn = conManager.GetConnectionString("ExcelTechnologiesDB");


builder.Services.AddDbContext<ExcelTechnologiesDBContext>(options =>
{
    options.UseSqlServer(conn);
});
builder.Services.AddTransient<IAllergiesRepository, AllergiesRepository>();
builder.Services.AddTransient<IPatientsRepository, PatientsRepository>();
builder.Services.AddTransient<IDiseaseInformationRepository, DiseaseInformationRepository>();
builder.Services.AddTransient<INCD_DetailsRepository, NCD_DetailsRepository>();
builder.Services.AddTransient<IEpilepsyRepository, EpilepsyRepository>();
builder.Services.AddTransient<IAllergies_DetailsRepository, Allergies_DetailsRepository>();
builder.Services.AddTransient<INCDRepository, NCDRepository>();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await app.RegisterWebApisAsync();
await app.RunAsync();
