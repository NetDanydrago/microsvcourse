using NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Interfaces;
using NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Options;
using NorthWind.BlazingPizza.GetSpecials.Core;
using NorthWind.BlazingPizza.GetSpecials.Entities.ValueObjects;
using NorthWind.BlazingPizza.GetSpecials.Repositories;
using NorthWind.BlazingPizza.GetSpecials.Repositories.Options;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGetSpecialCoreServices(getSpecialOptions =>
{
    builder.Configuration.GetRequiredSection(GetSpecialsOptions.SectionKey).
    Bind(getSpecialOptions);
});
builder.Services.AddRepositories(GetSpecialDbOptions =>
{
    builder.Configuration.GetRequiredSection(GetSpecialsDbOptions.SectionKey).
    Bind(GetSpecialDbOptions);

});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});

builder.Services.AddDistributedMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet(Endpoints.GetSpecials, async (IGetSpecialsController controller) =>
{
  return TypedResults.Ok(await controller.GetSpecialsAsync());
});

app.InitializeDB();

app.Run();