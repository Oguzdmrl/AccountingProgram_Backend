using AccountingSolutions.Application.Services.AppServices;
using AccountingSolutions.Domain.AppEntities.Identity;
using AccountingSolutions.Persistance.Context;
using AccountingSolutions.Persistance.Services.AppServices;
using AccountingSolutions.Presentation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(typeof(AccountingSolutions.Application.AssemblyReference).Assembly);
builder.Services.AddAutoMapper(typeof(AccountingSolutions.Persistance.AssemblyReference).Assembly);

builder.Services.AddControllers().AddApplicationPart(typeof(AssemblyReferance).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecuritySheme,Array.Empty<string>() }
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

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
