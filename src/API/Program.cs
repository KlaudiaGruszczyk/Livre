using Microsoft.Extensions.Configuration;
using Application;
using Application.Common.Interfaces;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Application.UsersCQRS.Commands.RegisterUser;
using Application.UsersCQRS.Commands.ChangeLogin;
using Application.UsersCQRS.Commands.ChangePassword;
using FluentAssertions.Common;
using Application.UsersCQRS.Commands.ChangeEmail;
using Application.UsersCQRS.Commands.CreateUser;
using Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Livre_DbConnection"), b => b.MigrationsAssembly("API")));
builder.Services.AddApplicationServices();
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ApplicationSeeder>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ApplicationMappingProfile>());
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IValidator<ChangeLoginCommand>, ChangeLoginCommandValidator>();
builder.Services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();
builder.Services.AddScoped<IValidator<ChangeEmailCommand>, ChangeEmailCommandValidator>();
builder.Services.AddScoped<IValidator<ChangePasswordCommand>, ChangePasswordCommandValidator>();
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddHttpContextAccessor();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("ModeratorOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Moderator"));
    options.AddPolicy("UserOnly", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Livre API", Version = "v1" });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
var scope = app.Services.CreateScope();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


var seeder = scope.ServiceProvider.GetRequiredService<ApplicationSeeder>();
seeder.Seed();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Livre API v1");
        c.RoutePrefix = "swagger";
    });
}



app.MapControllers();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
