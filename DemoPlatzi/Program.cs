using DemoPlatzi.Middlewares;
using DemoPlatzi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectamos nuestras dependencias
//builder.Services.AddScoped<IHelloWorldService, HelloWorldServices>();
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Llamada a middlewares propios y de terceros
// app.UseWelcomePage();
// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
