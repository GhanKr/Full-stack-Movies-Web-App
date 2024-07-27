using Microsoft.EntityFrameworkCore;
using Movies_API.Entities;
using Movies_API.MongoDbMovieSource;
using Movies_API.MovieDbContexts;
using Movies_API.MovieStagingArea;
using Movies_API.Services;

var builder = WebApplication.CreateBuilder(args);


var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

builder.Services.AddDbContext<MovieDbContext>(options =>
                                            options.UseSqlServer(config["DbConnectionString"]));

builder.Services.AddScoped<MongoDbMovieContext>();

builder.Services.AddScoped<IMovieMethods, MovieMethodsMongoDb>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
