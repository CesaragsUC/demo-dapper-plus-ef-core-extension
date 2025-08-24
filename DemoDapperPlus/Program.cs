using DemoDapperPlus.Abstractions;
using DemoDapperPlus.Infrasctructure;
using DemoDapperPlus.Repository;
using DemoDapperPlus.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddDbContext<PessoaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddScoped<IPessoaService,PessoaService>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<PessoaDbContext>();

builder.Services.AddSwaggerGen(cf =>
{
    cf.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo Dapper Plus", Version = "v1" });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
