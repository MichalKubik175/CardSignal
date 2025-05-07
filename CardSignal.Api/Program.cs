using System.Reflection;
using CardSignal.Api.Swagger;
using CardSignal.Application;
using CardSignal.Application.Mapping;
using CardSignal.Application.Options;
using CardSignal.DataAccess;
using Kirpichyov.FriendlyJwt.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddMySqlContext(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(CardLinkProfile).Assembly);

builder.Services.AddControllers()
    .AddFriendlyJwtAuthentication(configuration =>
    {
        var jwtOptions = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
        
        configuration.Issuer = jwtOptions.Issuer;
        configuration.Audience = jwtOptions.Audience;
        configuration.Secret = jwtOptions.Secret;
    }, jwtPostSetupDelegate:T =>
    {
        T.Events = new JwtBearerEvents()
        {
            OnAuthenticationFailed = context =>
            {
                return Task.CompletedTask;
            },
        };
    });

builder.Services.AddFriendlyJwt();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = HeaderNames.Authorization,
            Type = SecuritySchemeType.ApiKey,
            In = ParameterLocation.Header,
            Description = "Obtained JWT. (Example: 'Bearer your_token_here')",
        });
    
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "CardSignalR API", 
        Version = "v1",
        Description = "API for managing card links",
        Contact = new OpenApiContact { Name = "Developer", Email = "dev@example.com" }
    });
    
    c.OperationFilter<AuthOperationFilter>();
    
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();