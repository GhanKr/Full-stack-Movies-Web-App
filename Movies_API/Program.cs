using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Movies_API.ConfigurationBindingClasses;
using Movies_API.Model;
using Movies_API.MovieRepository.MongoDbMovieRepository;
using Movies_API.MovieRepository.SqlServerRepository;
using Movies_API.MovieStagingArea;
using Movies_API.Services;
using System.Net.WebSockets;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseConfiguration>("SqlServer", 
                 builder.Configuration.GetSection("DatabaseConfiguration:SqlServerDatabase"));

builder.Services.Configure<DatabaseConfiguration>("MongoDb", 
                 builder.Configuration.GetSection("DatabaseConfiguration:MongoDbDatabase"));

builder.Services.AddDbContext<MovieDbContext>(
    options => options.UseSqlServer(
        builder.Configuration["DatabaseConfiguration:SqlServerDatabase:ConnectionString"]));

builder.Services.AddScoped<MongoDbMovieContext>();


builder.Services.AddScoped<IMovieMethods, MovieMethodsMongoDb>();

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction => 
{
    setupAction.SwaggerDoc("v1", new()
    {
        Title ="Movie Api",
        Version ="1",
        Description="This is My personal hobby project to simulate a movies api \n using ASP.NET CORE 6.0 and MongoDb and SqlServer as database which will provide the movies details, Hope you will like it and please provide some suggestions!",
        Contact = new()
        {
            Name="Ghanshyam Kumar",
            Url= new Uri("https://github.com/GhanKr")
        }

    });

    var commetsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var commentFullPath = Path.Combine(AppContext.BaseDirectory, commetsFile);
    setupAction.IncludeXmlComments(commentFullPath);

}) ;



if (builder.Environment.IsProduction())
{
    builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["AzureKeyVault"]}.vault.azure.net"),
    new DefaultAzureCredential());

}

var app = builder.Build();


// Configure the HTTP request pipeline.


app.UseSwagger();

app.UseSwaggerUI(setupAction =>
{
    setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Api");
    setupAction.RoutePrefix = string.Empty;
});



app.UseCors();
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
