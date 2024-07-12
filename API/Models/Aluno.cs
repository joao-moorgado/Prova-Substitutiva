namespace API.Models;

public class Aluno
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public Aluno()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Aluno(string nome, string sobrenome)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Sobrenome = sobrenome;
    }
}