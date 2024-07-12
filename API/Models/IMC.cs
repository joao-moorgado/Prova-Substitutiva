namespace API.Models;

public class IMC
{
    public string Id { get; set; }
    public int Altura { get; set; }
    public int Peso { get; set; }
    public string AlunoId { get; set; }
    public Aluno Aluno { get; set; }
}