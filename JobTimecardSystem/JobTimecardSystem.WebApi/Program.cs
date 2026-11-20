using System.Data.SqlClient;
using System.Text.Json.Serialization;
using JobTimecardSystem.Data.Repositories;
using NHibernate;
var builder = WebApplication.CreateBuilder(args);

// 1. Force a fixed HTTP port so it never depends on launchSettings.json or HTTPS certs
builder.WebHost.UseUrls("http://localhost:5295");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=(localdb)\\MSSQLLocalDB;Database=JobTimecardDb;Trusted_Connection=True;TrustServerCertificate=True;";

// 2. Automatically create JobTimecardDb on ANY machine if it doesn't exist yet
var masterConnectionString = connectionString.Replace("Database=JobTimecardDb", "Database=master");
using (var conn = new SqlConnection(masterConnectionString))
{
    conn.Open();
    using var cmd = conn.CreateCommand();
    cmd.CommandText = "IF DB_ID('JobTimecardDb') IS NULL CREATE DATABASE [JobTimecardDb];";
    cmd.ExecuteNonQuery();
}

// 3. Register NHibernate & Repositories
var sessionFactory = NHibernateHelper.CreateSessionFactory(connectionString);
builder.Services.AddSingleton(sessionFactory);
builder.Services.AddScoped<JobRepository>();
builder.Services.AddScoped<TimecardRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<JobRepository>();
builder.Services.AddScoped<TimecardRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<EmployeeRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();