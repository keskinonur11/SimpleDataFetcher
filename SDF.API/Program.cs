using Microsoft.AspNetCore.Diagnostics;
using SDF.Business;
using SDF.Business.Interfaces;
using SDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.CreateInfrastructureDependencies();
builder.Services.CreateBusinessDependencies();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;
    var response = new { error = exception.Message };
    await context.Response.WriteAsJsonAsync(response);
}));

//Populate In memory database
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<IQuoteService>().FillInMemoryDatabase();
}

app.Run();

public partial class Program { }