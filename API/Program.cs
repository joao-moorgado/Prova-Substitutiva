using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

/*builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);*/

var app = builder.Build();

app.MapPost("/api/aluno/cadastrar", ([FromBody] Aluno aluno, [FromServices] AppDataContext ctx) =>
{
    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Created($"/api/aluno/obter/{aluno.Id}", aluno);
});

app.MapPost("/api/imc/cadastrar", ([FromBody] IMC imc, [FromServices] AppDataContext ctx) =>
{
    ctx.IMCs.Add(imc);
    ctx.SaveChanges();
    return Results.Created($"/api/imc/obter/{imc.Id}", imc);
});

//app.UseCors("Acesso Total");
app.Run();