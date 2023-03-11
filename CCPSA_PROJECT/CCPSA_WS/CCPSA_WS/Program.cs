using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "POLITICAS_CORS_CARIBE",
        policy =>
        {
            policy.WithOrigins("http://localhost:80", "http://localhost:4200").AllowAnyOrigin().AllowAnyMethod();
        });
});
builder.WebHost.ConfigureKestrel(options => options.ListenAnyIP(5100));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("POLITICAS_CORS_CARIBE");

app.UseAuthorization();

app.MapControllers();

app.Run();

