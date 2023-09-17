using System.Reflection;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Awesome Books API",
        Description = "Get a dreamlike book shopping experience with our API",
        // TermsOfService = new Uri("https://example.com/terms"),
        // Contact = new OpenApiContact
        // {
            // Name = "Example Contact",
            // Url = new Uri("https://example.com/contact")
        // },
        // License = new OpenApiLicense
        // {
            // Name = "Example License",
            // Url = new Uri("https://example.com/license")
        // }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddSingleton<IRepository<Book>, BookRepository>();
builder.Services.AddSingleton<IRepository<Genre>, GenreRepository>();

var app = builder.Build();

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