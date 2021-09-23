using System;
using System.IO;
class Funcionario
{
  const int inicioMatricula = 0,
            tamanhoMatricula = 5,
            inicioNome = inicioMatricula + tamanhoMatricula,
            tamanhoNome = 30,
            inicioSalario = inicioNome + tamanhoNome,
            tamanhoSalario = 10;

  int     matricula;
  string  nome;
  double  salario;

  public Funcionario(int mat, string nome, double sal)
  {
    Matricula = mat;
    this.Nome = nome;
    Salario = sal;
  }

  public Funcionario()
  {
    Matricula = 1;
    Nome      = " ";
    Salario   = 0;
  }

  public int Matricula
  {
    get => matricula;
    set
    {
      if (value < 1 && value > 99999)
        throw new InvalidDataException("Matrícula inválida!");
      matricula = value;
    }
  }
  public string Nome 
  { 
    get => nome; 
    set 
    { 
      if (value.Length > tamanhoNome) 
         value = value.Substring(0, tamanhoNome); 
      nome = value.PadRight(tamanhoNome, ' '); 
    } 
  }
  public double Salario 
  { 
    get => salario; 
    set 
    { 
      if (value < 0) 
         throw new InvalidDataException("Salário inválido!"); 
      salario = value; 
    } 
  }
  public void LerDados(StreamReader arq) 
  { 
    if (!arq.EndOfStream) 
    { 
      String linha = arq.ReadLine(); 
      Matricula = int.Parse(linha.Substring(inicioMatricula, tamanhoMatricula));
      Nome = linha.Substring(inicioNome, tamanhoNome); 
      Salario = double.Parse(linha.Substring(inicioSalario, tamanhoSalario)); 
    } 
  }
  public String FormatoDeArquivo() 
  {
    return Matricula.ToString().PadLeft(tamanhoMatricula, ' ') + 
           Nome +
           Math.Round(Salario, 2).ToString().PadLeft(tamanhoSalario,' '); 
  }

}

