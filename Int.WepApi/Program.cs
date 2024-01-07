using Core.Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Persistence.Auth;
using Core.Persistence.Context;
using Core.Persistence.Extension;
using Core.Utility.Security.Encryption;
using Core.Utility.Security.JWT;
using Int.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowHost",
               builder => builder
                   .WithOrigins("http://localhost:3000")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials());
});

builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                Claim? userIdClaim = context.Principal.FindFirst(ClaimTypes.NameIdentifier);
                Claim? userName = context.Principal.FindFirst(ClaimTypes.Name);
                List<Claim> userRoles = context.Principal.FindAll(ClaimTypes.Role).ToList();

                if (Guid.TryParse(userIdClaim.Value, out Guid userId))
                {
                    AuthUser authUser = new AuthUser
                    {
                        Id = userId,
                        Name = context.Principal.FindFirst(ClaimTypes.Name)?.Value,
                        Roles = userRoles.Select(x => x.Value).ToList()
                    };
                    context.HttpContext.Items["AuthUser"] = authUser;
                }

                return Task.CompletedTask;
            }
        };
    });

CoreContext.Configure(
    builder.Services.BuildServiceProvider().GetService<IHttpContextAccessor>());

var app = builder.Build();

app.UseCors("AllowHost");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();
app.UseMiddleware<HttpMiddleware>();
app.MapControllers();

app.Run();
