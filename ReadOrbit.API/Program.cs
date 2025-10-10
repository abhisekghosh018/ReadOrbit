using Microsoft.EntityFrameworkCore;
using ReadOrbit.API.Middleware;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.APPLICATION.Services;
using ReadOrbit.INFRASTRUCTURE.DB;
using ReadOrbit.INFRASTRUCTURE.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IReaderProfileRepository, ReaderProfileRepository>();
builder.Services.AddScoped<IBookReaderRepository, BookReaderRepository>();
builder.Services.AddScoped<IReaderGroupRepository, ReaderGroupRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

// serices
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<ReaderProfileService>();
builder.Services.AddScoped<ReaderService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReadOrbit", policy =>
    {
        policy.WithOrigins("http://localhost:4200");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("ReadOrbit");
app.UseMiddleware<ExceptionsMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
