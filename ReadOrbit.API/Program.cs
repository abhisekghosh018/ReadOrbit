using Microsoft.EntityFrameworkCore;
using ReadOrbit.API.Middleware;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.APPLICATION.RedisCache;
using ReadOrbit.APPLICATION.Services;
using ReadOrbit.INFRASTRUCTURE.Caching;
using ReadOrbit.INFRASTRUCTURE.DB;
using ReadOrbit.INFRASTRUCTURE.Repository;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"), options => options.CommandTimeout(300)));

// repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IReaderProfileRepository, ReaderProfileRepository>();
builder.Services.AddScoped<IBookReaderRepository, BookReaderRepository>();
builder.Services.AddScoped<IReaderGroupRepository, ReaderGroupRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

//test
builder.Services.AddScoped<ITest, Test>();
//Redis Cache
var redisConnection = builder.Configuration.GetConnectionString("Redis");

if (string.IsNullOrWhiteSpace(redisConnection))
{
    throw new InvalidOperationException(
        "RedisConnection is not configured.");
}

builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(redisConnection));

builder.Services.AddScoped<ICacheService, RedisCacheService>();



// serices
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<ReaderProfileService>();
builder.Services.AddScoped<ReaderService>();
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<TestService>();


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
