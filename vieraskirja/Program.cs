using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using vieraskirja.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", corsBuilder =>
    {
        corsBuilder.WithOrigins("https://vieraskirja.mariapori.fi");
    });
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VieraskirjaContext>(options =>
{
    options.UseMySql(configuration.GetConnectionString("Default"),ServerVersion.AutoDetect(configuration.GetConnectionString("Default")));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseCors("cors");
app.MapControllers();

app.Run();
