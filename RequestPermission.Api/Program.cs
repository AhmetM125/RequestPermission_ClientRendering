using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RequestPermission.Api;
using RequestPermission.Api.Cors;
using RequestPermission.Api.DependencyInjection;
using RequestPermission.Api.Infrastracture;
using RequestPermission.Api.Infrastracture.SwaggerSetup;
using System.Text;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"], //  "http://yurdalcompany.com"
        ValidAudience =   builder.Configuration["Jwt:Audience"], //"http://yurdalcompany.com", // builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])), 
    };
});


builder.Services.AddSwaggerSetup();

builder.Services.AddControllers();
builder.Services.AddDependencyInjection();

builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddCorsConfiguration();
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

app.UseMiddleware<Middleware>();
app.UseHttpsRedirection();
app.UseSwaggerSetup();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
