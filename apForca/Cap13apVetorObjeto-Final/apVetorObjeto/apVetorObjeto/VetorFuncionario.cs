using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

public enum Situacao
{
  navegando, incluindo, pesquisando, editando, excluindo
}
class VetorFuncionario
{
  Funcionario[] dados;  // vetor de Funcionario
  int qtosDados;        // tamanho lógico
  int posicaoAtual;     // índice que estamos visitando, no momento, no vetor dados
  Situacao situacaoAtual;  // o que está sendo feito com os dados no momento atual

  public Situacao SituacaoAtual // esta propriedade permite acessar o atributo
  {                             // situacaoAtual para consulta e ajuste
    get => situacaoAtual;
    set => situacaoAtual = value;
  }

  public bool EstaVazio // permite à aplicação saber se o vetor dados está vazio
  {
    get => qtosDados <= 0; // se qtosDados <= 0, retorna true
  }
  public int PosicaoAtual // permite à aplicação saber qual a posição do registro
  {                       // visível na tela ou reposicionar o registro atualmente
    get => posicaoAtual;  // acessado
    set
    {
      if (value >= 0 && value < qtosDados)
         posicaoAtual = value;
    }
  }
  public int Tamanho { get => qtosDados; }

  public VetorFuncionario(int tamanhoMaximo) 
  {
    dados         = new Funcionario[tamanhoMaximo];
    qtosDados     = 0;   // vetor vazio, no momento de sua instanciação
    posicaoAtual  = -1;  // indica que não estamos posicionados em nenhum registro do vetor
    situacaoAtual = Situacao.navegando;
  }

  public Funcionario this[int indice]
  {
    get
    {
      if (indice < 0 || indice > qtosDados - 1)      // testamos a validade do indice passado
         throw new Exception("Índice fora dos limites de armazenamento!");

      return dados[indice]; // se o índice passado é válido, retornamos o dado armazenado na posicao indice do vetor dados
    }
    set
    {
      if (indice >= 0 && indice < qtosDados)
        dados[indice] = value;
      else
        throw new Exception("Índice fora dos limites do vetor!");
    }
  }
  public void PosicionarNoPrimeiro()
  {
    if (!EstaVazio)
       posicaoAtual = 0; // primeira posição do vetor em uso
    else
      posicaoAtual = -1; // indica antes do vetor vazio
  }

  public void RetrocederPosicao()
  {
    if (posicaoAtual > 0)
       posicaoAtual--;
  }

  public void AvancarPosicao()
  {
    if (posicaoAtual < qtosDados - 1)
       posicaoAtual++;
  }

  public void PosicionarNoUltimo()
  {
    if (!EstaVazio)
       posicaoAtual = qtosDados - 1; // índice da última posição usada do vetor
    else
      posicaoAtual = -1; // indica antes do vetor vazio
  }

  public bool EstaNoInicio
  {
    get => posicaoAtual <= 0; // primeiro índice
  }
  public bool EstaNoFim
  {
    get => posicaoAtual >= qtosDados - 1; // último índice
  }
  public Funcionario ValorDe(int indice) 
  {
    if (indice >= 0 && indice < qtosDados)
       return dados[indice];

    throw new Exception("Índice fora dos limites de armazenamento!");
  }

  public void GravarDados(string nomeArquivo)
  {
    var arquivo = new StreamWriter(nomeArquivo);
    
    for (int indice = 0; indice < qtosDados; indice++)
      arquivo.WriteLine(dados[indice].FormatoDeArquivo());

    arquivo.Close();
  }


  // pesquisa sequencial em vetor desordenado
  public bool ExisteSemOrdem(int codigoProcurado, out int ondeEsta)  // pesquisa sequencial em vetor desordenado
  {
    bool achou = false;
    ondeEsta = 0;
    while (!achou && ondeEsta < qtosDados)
    {
      if (dados[ondeEsta].Matricula == codigoProcurado)
         achou = true; // achamos chave igual à procurada, então paramos o while (achou valerá true) 
      else
        ondeEsta++;    // como não achamos chave igual à procurada, avançamos no vetor para procurar
    }

    return achou;   // retorna true (se existe, achou) ou false (não achou)
  }

  // pesquisa sequencial em vetor ordenado
  public bool ExisteEmOrdem(int codigoProcurado, out int onde)  // pesquisa sequencial em vetor ordenado
  {
    bool fim, achou;
    onde = 0; // inicializa variáveis de controle da pesquisa
    achou = false;
    fim = false;
    while (!achou && !fim) // not (achou or fim) // De Morgan
      if (onde >= qtosDados) // condição i
         fim = true;
      else
        if (dados[onde].Matricula == codigoProcurado)
           achou = true; // condição ii
        else
          if (dados[onde].Matricula > codigoProcurado)
            fim = true; // condição iii
          else
            onde++; // como nenhuma das condições foi
                    // satisfeita, acessa o elemento
                    // seguinte no vetor.
    return achou;
  }

  //pesquisa binária
  public bool Existe(int codigoProcurado, out int onde)  // onde --> posicao onde achou ou onde deveria estar (inclusão)
  {
    onde = -1;   // o compilador exige que parâmetros out sejam iniciados

    bool achou = false;
    int inicio = 0;
    int fim    = qtosDados - 1;
    while (!achou && inicio <= fim)  // não achou a chave e ainda temos onde procurar
    {
      onde = (inicio + fim) / 2;
      if (codigoProcurado == dados[onde].Matricula)
        achou = true;  // a posição dessa matrícula no vetor é o índice "onde"
      else
        if (codigoProcurado < dados[onde].Matricula)
           fim = onde - 1;
        else
          inicio = onde + 1;
    }
    // tratar o caso em que nao encontramos a chave procurada. Nessa situação,
    // a pesquisa acima (while) terminou com inicio > fim, e o índice inicio
    // indica a posição em que a chave procurada deveria estar, caso existisse.
    // Fazemos o parâmetro onde receber inicio, para o caso de a aplicação
    // desejar incluir um registro com essa chave, na posição que manteria o
    // vetor em ordem crescente das chaves

    if (!achou )       // ou seja, saimos do while porque inicio > fim
       onde = inicio;  // o parâmetro onde retorna a posição de uma eventual inclusão em ordem

    return achou; // por fim, retornamos se encontramos ou não a chave procurada.
  }
  public void Excluir(int posicao) 
  {
    if (posicao < 0 ||  posicao >= qtosDados)                 // conferimos se a posição passada para exclusão
       throw new Exception("Posição de exclusão inválida!");  // está dentro do intervalo 0 a qtosDados-1
    
    qtosDados--;
    for (int indice = posicao; indice < qtosDados; indice++)
        dados[indice] = dados[indice + 1];

    dados[qtosDados]= null;
  }
  public void Incluir(Funcionario novoValor)  // inclui ao final do vetor
  {
    if (qtosDados < dados.Length)
    {
      dados[qtosDados] = novoValor;
      qtosDados++;
    }
    else
      throw new Exception("Espaço insuficiente para armazenamento dos dados!");
  }

  public void Incluir(Funcionario novoValor, int posicaoDeInclusao)  // incluir novoValor no índice posicaoDeInclusao 
  {
    if (posicaoDeInclusao < 0 && posicaoDeInclusao > qtosDados)
       throw new Exception("Posiçao de inclusao é inválida!");

    if (qtosDados >= dados.Length)
       throw new Exception("Espaço de armazenamento insuficente!");

    for (int indice = qtosDados; indice > posicaoDeInclusao; indice--)
        dados[indice] = dados[indice - 1];

    dados[posicaoDeInclusao] = novoValor;
    qtosDados++;  // expande tamanho lógico do vetor
  }

  public void Alterar(int indice, Funcionario novoDado)
  {
    if (indice >= 0 && indice < qtosDados)
       dados[indice] = novoDado;

    throw new Exception("Índice fora dos limites do vetor!");
  }
  public void ExibirDados(ListBox lista) 
  {
    lista.Items.Clear();
    for (int indice = 0; indice < qtosDados; indice++)
      lista.Items.Add(dados[indice].ToString());
    Application.DoEvents();
  }
  public void ExibirDados(ComboBox lista) 
  {
    lista.Items.Clear();
    for (int indice = 0; indice < qtosDados; indice++)
      lista.Items.Add(dados[indice].ToString());
    Application.DoEvents();
  }
  public void ExibirDados() 
  {
    Console.Clear();
    for (int indice = 0; indice < qtosDados; indice++)
      Console.WriteLine($"{indice} - {dados[indice]}");
  }
  public void ExibirDados(DataGridView grade) 
  {
    if (qtosDados > 0)
    {
      grade.RowCount = qtosDados; // ajustamos o numero de linhas do Grid
      for (int indice = 0; indice < qtosDados; indice++)
      {
        grade.Rows[indice].HeaderCell.Value = indice+"";
        grade[0, indice].Value = dados[indice].Matricula;
        grade[1, indice].Value = dados[indice].Nome;
        grade[2, indice].Value = dados[indice].Salario;
      }
    }
  }
  public void ExibirDados(TextBox lista) 
  {
    lista.Text = "";
    lista.Multiline = true;
    lista.ScrollBars = ScrollBars.Both;
    for (int indice = 0; indice < qtosDados; indice++)
      lista.AppendText(dados[indice] + Environment.NewLine);
    Application.DoEvents();
  }
   private void Trocar(int esquerdo, int direito)
  {
    Funcionario aux = dados[esquerdo];
    dados[esquerdo] = dados[direito];
    dados[direito]  = aux;
  }
  public void Ordenar(ListSortDirection qualOrdem)  // ordenação por seleção - Selection Sort
  {
    if (qualOrdem == ListSortDirection.Ascending)   // ordem crescente
    {
      for (int lento = 0; lento < qtosDados; lento++)
          for (int rapido = lento + 1; rapido < qtosDados; rapido++)
              if (dados[lento].Matricula.CompareTo(dados[rapido].Matricula) > 0) // matrículas fora de ordem
                 Trocar(lento, rapido);
    }
    else
      for (int lento = 0; lento < qtosDados; lento++)     // ordem decrescente
          for (int rapido = lento + 1; rapido < qtosDados; rapido++)
              if (dados[lento].Matricula.CompareTo(dados[rapido].Matricula) < 0) // matrículas fora de ordem
                 Trocar(lento, rapido);
  }

  public void OrdenarPorNome(ListSortDirection qualOrdem)
  {
    if (qualOrdem == ListSortDirection.Ascending)   // ordem crescente
    {
      for (int lento = 0; lento < qtosDados; lento++)
        for (int rapido = lento + 1; rapido < qtosDados; rapido++)
          if (dados[lento].Nome.CompareTo(dados[rapido].Nome) > 0) // nomes fora de ordem
            Trocar(lento, rapido);
    }
    else
      for (int lento = 0; lento < qtosDados; lento++)
        for (int rapido = lento + 1; rapido < qtosDados; rapido++)
          if (dados[lento].Nome.CompareTo(dados[rapido].Nome) < 0) // nomes fora de ordem
            Trocar(lento, rapido);
  }

  public void OrdenarPorSalario(ListSortDirection qualOrdem)
  {
    if (qualOrdem == ListSortDirection.Ascending)   // ordem crescente
    {
      for (int lento = 0; lento < qtosDados; lento++)
        for (int rapido = lento + 1; rapido < qtosDados; rapido++)
          if (dados[lento].Salario.CompareTo(dados[rapido].Salario) > 0) // salários fora de ordem
            Trocar(lento, rapido);
    }
    else
      for (int lento = 0; lento < qtosDados; lento++)
        for (int rapido = lento + 1; rapido < qtosDados; rapido++)
          if (dados[lento].Salario.CompareTo(dados[rapido].Salario) < 0) // salários fora de ordem
            Trocar(lento, rapido);
  }
}