using API.Extensions;
using API.Filters;
using API.Interface;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("dbConnection");
//Do not forget to add ConnectionStrings as "dbConnection" to the appsetting.json file
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddCors();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<IProfileRepository, ProfileRepository>();
builder.Services.AddTransient<IPasswordRepository, PasswordRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IDashboardRepository, DashboardRepository>();
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<IEmailHelper, EmailHelper>();
builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ReformatValidationProblemAttribute>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration[Jwt.Audience],
        ValidIssuer = builder.Configuration[Jwt.Issuer],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[Jwt.Key]))
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var logger = new LoggerConfiguration()
    .WriteTo.File($"../logs/WHYMIHN-api-{DateTime.Now:ddMMyyyy}.log", Serilog.Events.LogEventLevel.Error)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "WHYMIHN API";
    });
}

app.UseMiddleware<ExceptionMiddleware>();

// Shows UseCors with CorsPolicyBuilder.
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
