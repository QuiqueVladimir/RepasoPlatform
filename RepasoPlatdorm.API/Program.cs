using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RepasoPlatdorm.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using RepasoPlatdorm.API.Shared.Infrastructure.Persistence.EFC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Configuration for Routing *************

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Configura Lowercase Urls ********
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Coneccion a la base de datos *********
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Configure Database Context and Logging levels

//builder.Services ****** continuar video 20 mayo min 40:02

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString == null) return;
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "RepasoPlatdorm.API",
            Version = "V1",
            Description = "Repaso para pc2", 
            TermsOfService = new Uri("https://repaso.com/tos"),
            Contact = new OpenApiContact{Name="Repaso", Email="u20202022365@upc.edu.pe"},
            License = new OpenApiLicense{Name = "Apache 2.0", Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")}
        });
    });
//Configure Lowercase Urls
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

/* 
 //verify database objects are created video 20 mayo min 46:26
 */
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();