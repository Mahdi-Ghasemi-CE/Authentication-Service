using Authentication_Service.Extensions.DependencyInjections;
using Authentication_Service.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Option Configuration
var configuration = builder.Configuration;
builder.Services.AddOptionConfiguration(configuration);

// DbContext Configuration
builder.Services.AddDbContext<AppDbContext>();

// Services
builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mapper service
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();