using System.Data.SqlClient;
using System.Text.Json.Serialization;
using JobTimecardSystem.Data.Repositories;
using NHibernate;

var builder = WebApplication.CreateBuilder(args);

// 1. Force a fixed HTTP port so all clients connect reliably
builder.WebHost.UseUrls("http://localhost:5295");

// 2. Allow the Web Client (http://localhost:5100) to call this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=(localdb)\\MSSQLLocalDB;Database=JobTimecardDb;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=60;";

// 3. Automatically create JobTimecardDb (with retry if LocalDB is waking up)
var masterConnectionString = connectionString.Replace("Database=JobTimecardDb", "Database=master");
ISessionFactory? sessionFactory = null;

for (int attempt = 1; attempt <= 5; attempt++)
{
    try
    {
        using (var conn = new SqlConnection(masterConnectionString))
        {
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "IF DB_ID('JobTimecardDb') IS NULL CREATE DATABASE [JobTimecardDb];";
            cmd.ExecuteNonQuery();
        }

        sessionFactory = NHibernateHelper.CreateSessionFactory(connectionString);
        break;
    }
    catch when (attempt < 5)
    {
        Thread.Sleep(2000);
    }
}

// 4. Register NHibernate & Repositories
builder.Services.AddSingleton(sessionFactory!);
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

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();