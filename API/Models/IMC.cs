namespace API.Models;

public class IMC
{
    public string Id { get; set; }
    public double Altura { get; set; }
    public int Peso { get; set; }
    public double Valor => Peso / (Altura * Altura);
    public string Classificacao
    {
        get
        {
            if (Valor < 18.5)
            {
                return "Magreza";
            }
            else if (Valor < 24.9)
            {
                return "Normal";
            }
            else if (Valor < 29.9)
            {
                return "Sobrepeso";
            }
            else if (Valor < 39.9)
            {
                return "Obesidade";
            }
            else
            {
                return "Obesidade Grave";
            }
        }
    }
    public string GrauObesidade
    {
        get
        {
            if (Valor < 18.5)
            {
                return "0";
            }
            else if (Valor < 24.9)
            {
                return "0";
            }
            else if (Valor < 29.9)
            {
                return "I";
            }
            else if (Valor < 39.9)
            {
                return "II";
            }
            else
            {
                return "III";
            }
        }
    }
    public string AlunoId { get; set; }
    public Aluno Aluno { get; set; }

    public IMC() { 
        Id = Guid.NewGuid().ToString();
    }

    public IMC(double altura, int peso, string alunoId)
    {
        Id = Guid.NewGuid().ToString();
        Altura = altura;
        Peso = peso;
        AlunoId = alunoId;
    }
}