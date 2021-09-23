using System;
using System.IO;
using System.Windows.Forms;
class Dicionario
{
    bool[] acerto = new bool[15];
    int indice;

    const int inicioPalavra = 0,
              tamanhoPalavra = 15,
              inicioDica = inicioPalavra + tamanhoPalavra,
              tamanhoDica = 20;
              
    string  palavra, dica;
    
    public string Palavra { get => palavra; set => palavra = value; }
    public string Dica { get => dica; set => dica = value; }

    public Dicionario(string palavra, string dica)
  {    
    Palavra = palavra.Trim();
    Dica = dica.Trim().PadLeft(15,' ');
    for (int i = 0; i < acerto.Length; i++)
        {
            acerto[i] = false;
        }
    }
    public Dicionario()
    {
        Palavra = "" ;
        Dica = "";
        for(int i = 0; i < acerto.Length; i++)
        {
            acerto[i] = false;
        }
    }
  public void LerDados(StreamReader arq) 
  { 
    if (!arq.EndOfStream) 
    { 
       String linha = arq.ReadLine(); 
       Palavra = linha.Substring(inicioPalavra, tamanhoPalavra);
       Dica = linha.Substring(inicioDica); 
    } 
  }
  public String FormatoDeArquivo() 
  {
        return Palavra.ToString().PadLeft(tamanhoPalavra, ' ') +
               Dica.ToString().PadLeft(tamanhoDica, ' ');
  }
    public bool AcertoErro(char letra)
    {
        bool acertou = false;
        for (int i = 0; i < palavra.Length; i++)
        {
            if (palavra[i] == letra)
            {
                acerto[i] = true;
                acertou = true;
            }
        }
        return acertou;
    }
    public void ExibirLetras(DataGridView data)//Método que exibe as letras que o usuário acertou
    {
        for (int h = 0; h < palavra.Trim().Length; h++)
        {
            if(acerto[h])
            {
                data.Rows[0].Cells[h].Value = palavra[h];
            }
        }
    }
}