using System;
using System.IO;
using System.Windows.Forms;

namespace apVetorObjeto
{
  public partial class FrmFunc : Form
  {
    VetorFuncionario osFunc;
    int posicaoDeInclusao;
    public FrmFunc()
    {
      InitializeComponent();
    }

    private void btnSair_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void FrmFunc_Load(object sender, EventArgs e)
    {
      int indice = 0;
      tsBotoes.ImageList = imlBotoes;
      foreach (ToolStripItem item in tsBotoes.Items)
        if (item is ToolStripButton) // se não é separador:
          (item as ToolStripButton).ImageIndex = indice++;

      osFunc = new VetorFuncionario(20); // instancia com vetor dados com 20 posições

      if (dlgAbrir.ShowDialog() == DialogResult.OK)
      {
        var arquivo = new StreamReader(dlgAbrir.FileName);
        while (!arquivo.EndOfStream)
        {
          Funcionario dadoLido = new Funcionario();
          dadoLido.LerDados(arquivo); // método da classe Funcionario
          osFunc.Incluir(dadoLido);   // método de VetorFuncionario – inclui ao final
        }
        arquivo.Close();
        osFunc.PosicionarNoPrimeiro(); // posiciona no 1o registro a visitação nos dados
        AtualizarTela();               // mostra na tela as informações do registro visitado agora 
      }
    }

    private void btnInicio_Click(object sender, EventArgs e)
    {
      osFunc.PosicionarNoPrimeiro();
      AtualizarTela();
    }

    private void btnAnterior_Click(object sender, EventArgs e)
    {
      osFunc.RetrocederPosicao();
      AtualizarTela();
    }

    private void AtualizarTela()
    {
      if (!osFunc.EstaVazio)
      {
        int indice = osFunc.PosicaoAtual;
        txtMatricula.Text = osFunc[indice].Matricula + "";
        txtNome.Text = osFunc[indice].Nome;
        txtSalario.Text = osFunc[indice].Salario.ToString();
        TestarBotoes();
        stlbMensagem.Text = "Registro " + (osFunc.PosicaoAtual + 1) +
        "/" + osFunc.Tamanho;
      }
    }

    private void TestarBotoes()
    {
      btnInicio.Enabled   = true;
      btnAnterior.Enabled = true;
      btnProximo.Enabled  = true;
      btnUltimo.Enabled   = true;
      if (osFunc.EstaNoInicio)
      {   
        btnInicio.Enabled   = false;
        btnAnterior.Enabled = false;
      }

      if (osFunc.EstaNoFim)
      {
        btnProximo.Enabled = false;
        btnUltimo.Enabled = false;
      }
    }
    private void LimparTela()
    {
      txtMatricula.Clear();
      txtNome.Clear();
      txtSalario.Clear();
    }

    private void btnProximo_Click(object sender, EventArgs e)
    {
      osFunc.AvancarPosicao();
      AtualizarTela();
    }

    private void btnUltimo_Click(object sender, EventArgs e)
    {
      osFunc.PosicionarNoUltimo();
      AtualizarTela();
    }

    private void FrmFunc_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (dlgAbrir.FileName != "")  // foi selecionado um arquivo com dados
         osFunc.GravarDados(dlgAbrir.FileName);
    }

    private void btnNovo_Click(object sender, EventArgs e)
    {
      // saímos do modo de navegação e entramos no modo de inclusão:
      osFunc.SituacaoAtual = Situacao.incluindo;

      // preparamos a tela para que seja possível digitar dados do novo funcionário
      LimparTela();

      txtMatricula.ReadOnly = false;
      // colocamos o cursor no campo chave
      txtMatricula.Focus();

      // Exibimos mensagem no statusStrip para instruir o usuário a digitar dados
      stlbMensagem.Text = "Digite o número de matrícula do novo funcionário.";
    }

    private void txtMatricula_Leave(object sender, EventArgs e)
    {
      if (osFunc.SituacaoAtual == Situacao.incluindo || 
          osFunc.SituacaoAtual == Situacao.pesquisando)
         if (txtMatricula.Text == "")
         {
           MessageBox.Show("Digite uma matrícula válida!");
           txtMatricula.Focus();
         }
         else  // temos um valor digitado no txtMatricula
         {
           int matriculaProcurada = int.Parse(txtMatricula.Text);
           int posicao;
           bool achouRegistro = osFunc.Existe(matriculaProcurada, out posicao);
           switch (osFunc.SituacaoAtual)
           {
              case Situacao.incluindo:
              if (achouRegistro)
              {
                MessageBox.Show("Matrícula repetida! Inclusão cancelada.");
                osFunc.SituacaoAtual = Situacao.navegando;
                AtualizarTela(); // exibe novamente o registro que estava na tela antes de esta ser limpa
              }
              else  // a matrícula não existe e podemos incluí-la no índice ondeIncluir
              {     // incluí-la no índice ondeIncluir do vetor interno dados de osFunc
                txtNome.Focus();
                stlbMensagem.Text = "Digite os demais dados e pressione [Salvar].";
                btnSalvar.Enabled = true;  // habilita quando é possível incluir
                posicaoDeInclusao = posicao;  // guarda índice de inclusão em variável global
              }
              break;
              
              case Situacao.pesquisando:
                if (achouRegistro)
                {
                  // a variável posicao contém o índice do funcionário que se buscou
                  osFunc.PosicaoAtual = posicao;   // reposiciona o índice da posição visitada
                  AtualizarTela();
                }
                else
                {
                  MessageBox.Show("Matrícula digitada não foi encontrada.");
                  AtualizarTela();  // reexibir o registro que aparecia antes de limparmos a tela
                }

                osFunc.SituacaoAtual = Situacao.navegando;
                txtMatricula.ReadOnly = true;
              break;
           }
         }
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
      if (osFunc.SituacaoAtual == Situacao.incluindo)  // só guarda novo funcionário no vetor se estiver incluindo
      {
        // criamos objeto com o registro do novo funcionário digitado no formulário
        var novoFunc = new Funcionario(int.Parse(txtMatricula.Text), txtNome.Text,
                                       double.Parse(txtSalario.Text));

        osFunc.Incluir(novoFunc, posicaoDeInclusao);

        osFunc.SituacaoAtual = Situacao.navegando;  // voltamos ao mode de navegação

        osFunc.PosicaoAtual = posicaoDeInclusao;

        AtualizarTela();
      }
      else
        if (osFunc.SituacaoAtual == Situacao.editando)
        {
          osFunc[osFunc.PosicaoAtual].Nome = txtNome.Text;
          osFunc[osFunc.PosicaoAtual].Salario = double.Parse(txtSalario.Text);
          osFunc.SituacaoAtual = Situacao.navegando;
        }
      btnSalvar.Enabled     = false;    // desabilita pois a inclusão terminou
      txtMatricula.ReadOnly = true;
    }

    private void btnExcluir_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Deseja realmente excluir?", "Exclusão",
          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
      {
        osFunc.Excluir(osFunc.PosicaoAtual);
        if (osFunc.PosicaoAtual >= osFunc.Tamanho)
           osFunc.PosicionarNoUltimo();
        AtualizarTela();
      }
    }

    private void btnProcurar_Click(object sender, EventArgs e)
    {
      osFunc.SituacaoAtual = Situacao.pesquisando;  // entramos no modo de busca
      LimparTela();
      txtMatricula.ReadOnly = false;
      txtMatricula.Focus();
      stlbMensagem.Text = "Digite o número da matrícula procurada.";
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      osFunc.SituacaoAtual = Situacao.navegando;
      AtualizarTela();
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
      // permitimos ao usuario editar o registro atualmente
      // exibido na tela
      osFunc.SituacaoAtual = Situacao.editando;
      txtNome.Focus();
      stlbMensagem.Text = "Digite novo nome e/ou novo salário e pressione [Salvar].";
      btnSalvar.Enabled = true;
      txtMatricula.ReadOnly = true;  // não deixamos usuário alterar matrícula (chave primária)
    }

    private void tpLista_Enter(object sender, EventArgs e)
    {
      osFunc.ExibirDados(dgvFuncionarios);
    }
  }
}
