using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Interfaces;
using MovieApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
builder.Services.AddScoped<IMovieRepo, MovieRepo>();
builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<MovieDbContext>();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapGroup("/auth/user").MapCustomIdentityApi<User>().WithTags("Account");
app.Run();
