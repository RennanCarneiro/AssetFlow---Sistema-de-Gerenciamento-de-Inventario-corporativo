using Microsoft.EntityFrameworkCore;
using AssetFlow.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//injeção de dependencia
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=assetflow.db")); //configuração do sqlite
builder.Services.AddControllers(); //para procurar na pasta controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty; // Isso faz o Swagger abrir direto no localhost:5037/
    });
}

app.UseHttpsRedirection();
app.Run();