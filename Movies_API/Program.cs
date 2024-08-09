using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Movies_API.ConfigurationBindingClasses;
using Movies_API.Entities;
using Movies_API.MongoDbMovieSource;
using Movies_API.MovieDbContexts;
using Movies_API.MovieStagingArea;
using Movies_API.Services;

var builder = WebApplication.CreateBuilder(args);




builder.Services.Configure<DatabaseConfiguration>("SqlServer", builder.Configuration.GetSection("DatabaseConfiguration:SqlServerDatabase"));

builder.Services.Configure<DatabaseConfiguration>("MongoDb", builder.Configuration.GetSection("DatabaseConfiguration:MongoDbDatabase"));

builder.Services.AddDbContext<MovieDbContext>(options =>
                                            options.
                                            UseSqlServer(
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
builder.Services.AddSwaggerGen();



if (builder.Environment.IsProduction())
{
    builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["AzureKeyVault"]}.vault.azure.net"),
    new DefaultAzureCredential());

}

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
