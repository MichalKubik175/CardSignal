using System.Reflection;
using CardSignal.Application;
using CardSignal.Application.Mapping;
using CardSignal.DataAccess;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMySqlContext(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(CardLinkProfile).Assembly);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "CardSignalR API", 
        Version = "v1",
        Description = "API for managing card links",
        Contact = new OpenApiContact { Name = "Developer", Email = "dev@example.com" }
    });
    
    // Include XML comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CardSignalR API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();