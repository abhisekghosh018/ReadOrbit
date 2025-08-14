using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.APPLICATION.Services;
using ReadOrbit.INFRASTRUCTURE.DB;
using ReadOrbit.INFRASTRUCTURE.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// repositories
builder.Services.AddScoped<IBookRepository, ReadOrbit.INFRASTRUCTURE.Repository.BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IReaderProfileRepository, ReaderProfileRepository>();

// serices
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<ReaderProfileService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
