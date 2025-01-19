
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RossBoiler.Application.Data;
using RossBoiler.Application.WebAPI.Middleware;
using RossBoiler.Application.WebAPI.Utils;
using RossBoiler.Common;
using System.Reflection;
using System.Text;
//using Asp.Versioning;

//namespace RossBoiler.Application.WebAPI
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//var builder = WebApplication.CreateBuilder(args);
//            // Add services
//            //builder.Services.AddApiVersioning(options =>
//            //{
//            //    options.ReportApiVersions = true;
//            //    options.AssumeDefaultVersionWhenUnspecified = true;
//            //    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
//            //});
//            builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseInMemoryDatabase("ItemsDb"));

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();
//            //builder.Services.AddMediatR(typeof(Program));
//            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));



//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
});



//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseInMemoryDatabase("ItemsDb"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Add JWT Authentication
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by a space and your JWT token.\nExample: Bearer <your-token>"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
});

// Configure CORS
builder.Services.AddCors(options =>
{
    // Policy for allowing all origins
    //options.AddPolicy("AllowAll", policy =>
    //{
    //    policy.AllowAnyOrigin()
    //          .AllowAnyMethod()
    //          .AllowAnyHeader();
    //});

    // Policy for allowing specific IPs
    options.AddPolicy("AllowSpecific", policy =>
    {
        policy.WithOrigins("http://192.168.1.2", "http://192.168.1.101") // Replace with your specific IPs
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("RossBoiler.Application.Commands"), Assembly.Load("RossBoiler.Application.Queries")));
builder.Services.AddSingleton<ICorrelationIdProvider, CorrelationIdProvider>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
    };
});
builder.Services.AddSingleton<JwtTokenService>();
builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();

}

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();