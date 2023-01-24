using AccountingSolutions.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//   scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate;
//}

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
