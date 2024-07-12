using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();

app.MapPost("/api/aluno/cadastrar", ([FromBody] Aluno aluno, [FromServices] AppDataContext ctx) =>
{

    Aluno? alunoBuscado = ctx.Alunos
        .FirstOrDefault(a => a.Nome == aluno.Nome && a.Sobrenome == aluno.Sobrenome);
    if (alunoBuscado != null)
    {
        return Results.BadRequest("Aluno já cadastrado");
    }

    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Ok("Aluno cadastrado com sucesso");
});

app.MapPost("/api/imc/cadastrar", ([FromBody] IMC imc, [FromServices] AppDataContext ctx) =>
{

    imc.Aluno = ctx.Alunos.
        Find(imc.AlunoId);
    if (imc.Aluno == null)
    {
        return Results.BadRequest("Aluno não encontrado");
    }

    ctx.IMCs.Add(imc);
    ctx.SaveChanges();
    return Results.Ok("IMC cadastrado com sucesso");
});

app.MapGet("/api/aluno/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Alunos.Any()) 
    {
        return Results.Ok(ctx.Alunos.ToList());
    }
    return Results.NotFound("Nenhum aluno encontrado");
});

app.MapGet("/api/imc/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.IMCs.Any()) 
    {
        return Results.Ok(ctx.IMCs.ToList());
    }
    return Results.NotFound("Nenhum IMC encontrado");
});

app.MapGet("/api/imc/aluno/listar", ([FromServices] AppDataContext ctx) =>
{

});

app.MapPatch("/api/imc/alterar/{id}", ([FromBody] IMC imc, [FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    var imcDB = ctx.IMCs.Find(id);
    if (imcDB == null)
    {
        return Results.NotFound("IMC não encontrado");
    }
    imcDB.Altura = imc.Altura;
    imcDB.Peso = imc.Peso;
    ctx.SaveChanges();
    return Results.Ok(imcDB);
});

app.UseCors("Acesso Total");
app.Run();