using Microsoft.AspNetCore.Http;
using recipes_api.Models;
using recipes_api.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRecipeService, RecipeService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ICommentService, CommentService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var softwareLicenseUrl = Environment.GetEnvironmentVariable("SOFTWARE_LICENSE_URL");
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Recipes API",
        Description = "Projeto de desenvolvimento de uma API de receitas que retorna todas as receitas disponíveis, adiciona, remove e atualiza as mesmas, além de possuir um CRUD de usuários e recurso de comentários.",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Thiago Martins",
            Email = "thiago17thiago@gmail.com",
            Url = new Uri("https://thiagomartins367.github.io"),
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri(softwareLicenseUrl),
        }
    });
});
builder.Services.AddSwaggerGen(options =>
{
    string file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string path = Path.Combine(AppContext.BaseDirectory, file);
    options.IncludeXmlComments(path);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var useHttpsRedirection = Environment.GetEnvironmentVariable("USE_HTTPS_REDIRECTION");
if (useHttpsRedirection != "false")
    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
