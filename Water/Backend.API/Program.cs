using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;
using Backend.Core.Services.Interfaces;
using Backend.Core.Services;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.BusinessObjects;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Water",
            ValidAudience = "User",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("theforceisstringwithyoumastercodastringindeed"))
        };
    });
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter 'Bearer Authorization'"
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
builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDOFactory, DOFactory>();
builder.Services.AddScoped<IServicesFactory, ServicesFactory>();
builder.Services.AddScoped<ISecurityBO, SecurityBO>();
builder.Services.AddScoped<IBasketBO,  BasketBO>();
builder.Services.AddScoped<IStoreBO, StoreBO>();
builder.Services.AddScoped<ILibraryBO, LibraryBO>();



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
