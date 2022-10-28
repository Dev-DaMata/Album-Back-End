using Album_Copa.Controllers;
using Album_Copa.IRepository;
using Album_Copa.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITimesRepository, TimesRepository>();
builder.Services.AddScoped<IAtletasRepository, AtletasRepository>();
builder.Services.AddScoped<IFigurinhasRepository, FigurinhasRepository>();



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
