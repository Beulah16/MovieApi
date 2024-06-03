using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieApi.Data;
using MovieApi.Interfaces;
using MovieApi.Models;
using MovieApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<MovieDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMovieRepo, MovieRepo>();
builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
builder.Services.AddScoped<IGenreRepo, GenreRepo>();
builder.Services.AddScoped<IWatchListRepo, WatchListRepo>();
builder.Services.AddScoped<ISubscriptionPlanRepo, SubscriptionPlanRepo>();
;

builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<MovieDbContext>();
builder.Services.AddAuthorization();

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGroup("/api/auth").MapCustomIdentityApi<User>().WithTags("Auth");
app.Run();
