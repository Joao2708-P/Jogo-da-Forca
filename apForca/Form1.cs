using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
//João Guilherme Pereira dos Santos - 21238
//Kauan Gustavo dias Fernandes - 21243
namespace apForca
{
    public partial class Form1 : Form
    {
        VetorDicionario osDic;
        int posicaoDeInclusao;
        Dicionario palavraSorteada;
        int pontos = 0;
        int erro = 0;
        int tempor = 100;
        bool ganhou;
        SerialPort sp = new SerialPort("COM3",9600);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int indice = 0;
            tsBotoes.ImageList = imlBotoes;
            foreach (ToolStripItem item in tsBotoes.Items)
                if (item is ToolStripButton) // se não é separador:
                    (item as ToolStripButton).ImageIndex = indice++;

            osDic = new VetorDicionario(20); // instancia com vetor dados com 20 posições

            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                var arquivo = new StreamReader(dlgAbrir.FileName);
                while (!arquivo.EndOfStream)
                {
                    Dicionario dadoLido = new Dicionario();
                    dadoLido.LerDados(arquivo); // método da classe Dicionario
                    osDic.Incluir(dadoLido);   // método de VetorDicionario – inclui ao final
                }
                arquivo.Close();
                osDic.PosicionarNoPrimeiro(); // posiciona no 1o registro a visitação nos dados
                AtualizarTela();               // mostra na tela as informações do registro visitado agora 
            }
        }

        private void AtualizarTela()
        {
            if (!osDic.EstaVazio)
            {
                int indice = osDic.PosicaoAtual;
                edPalavra.Text = osDic[indice].Palavra;
                edDica.Text = osDic[indice].Dica;
                TestarBotoes();
                toolStripStatusLabel2.Text = "Registro 1 / 4   Inspirado em http://www.velhosamigos.com.br/jogos/forca.htm" + (osDic.PosicaoAtual + 1) + "/" + osDic.Tamanho;
            }
        }

        private void TestarBotoes()
        {
            btnInicio.Enabled = true;
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnUltimo.Enabled = true;
            if (osDic.EstaNoInicio)
            {
                btnInicio.Enabled = false;
                btnAnterior.Enabled = false;
            }

            if (osDic.EstaNoFim)
            {
                btnProximo.Enabled = false;
                btnUltimo.Enabled = false;
            }

        }

        private void LimparTela()
        {
            edPalavra.Clear();
            edDica.Clear();
        }

        //BOTÕES Cadastro
        private void btnInicio_Click(object sender, EventArgs e)
        {
            osDic.PosicionarNoPrimeiro();
            AtualizarTela();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            osDic.RetrocederPosicao();
            AtualizarTela();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            osDic.AvancarPosicao();
            AtualizarTela();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            osDic.PosicionarNoUltimo();
            AtualizarTela();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dlgAbrir.FileName != "")
                osDic.GravarDados(dlgAbrir.FileName);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            osDic.SituacaoAtual = Situacao.pesquisando;  // entramos no modo de busca
            LimparTela();
            edPalavra.ReadOnly = false;
            edPalavra.Focus();
            ssMensagem.Text = "Digite o número da matrícula procurada.";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            osDic.SituacaoAtual = Situacao.incluindo;
            LimparTela();
            edPalavra.ReadOnly = false;
            edPalavra.Focus();
            tsBotoes.Text = "Digite o número de matrícula do novo funcionário.";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            osDic.SituacaoAtual = Situacao.editando;
            edDica.Focus();
            tsBotoes.Text = "Digite novo nome e/ou novo salário e pressione [Salvar].";
            btnSalvar.Enabled = true;
            edPalavra.ReadOnly = true;  // não deixamos usuário alterar matrícula (chave primária)
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            osDic.SituacaoAtual = Situacao.navegando;
            AtualizarTela();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            osDic.ExibirDados(dataGridView2);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                osDic.Excluir(osDic.PosicaoAtual);
                if (osDic.PosicaoAtual >= osDic.Tamanho)
                    osDic.PosicionarNoUltimo();
                AtualizarTela();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (osDic.SituacaoAtual == Situacao.incluindo) // Modo de busca, vai incluir a nova palavra 
            {
                //Aqui será criado a nova palavra com sua dica
                var novaPalavra = new Dicionario(edPalavra.Text, edDica.Text);
                osDic.Incluir(novaPalavra, posicaoDeInclusao);

                osDic.SituacaoAtual = Situacao.navegando; //Retorna ao modo de busca
                osDic.PosicaoAtual = posicaoDeInclusao;
                AtualizarTela();
            }
            else
                if (osDic.SituacaoAtual == Situacao.editando) // Modo de busca, vai incluir a nova palavra 
            {
                //Aqui será criado a nova palavra com sua dica
                var edicao = new Dicionario(edPalavra.Text, edDica.Text);
                osDic.Excluir(osDic.PosicaoAtual);
                osDic.Incluir(edicao, osDic.PosicaoAtual);

                osDic.SituacaoAtual = Situacao.navegando; //Retorna ao modo de busca
                osDic.PosicaoAtual = posicaoDeInclusao;
                AtualizarTela();
            }
        }
        //Código da Forca
        private void btnLetra_Click(object sender, EventArgs e)
        {
            char letra = (sender as Button).Text[0];
            bool guardarPontos = palavraSorteada.AcertoErro(letra);
            palavraSorteada.ExibirLetras(dataPalavra);
            (sender as Button).Enabled = false;
            tmrTempo.Enabled = true;
            if (guardarPontos)
            {
                ganhou = true;
                for (int i = 0; i < dataPalavra.ColumnCount; i++)
                {
                    if (dataPalavra.Rows[0].Cells[i].Value == null)
                    {
                        ganhou = false;
                    }
                }

                if (ganhou)
                {
                    Vencedor();
                    if (MessageBox.Show("Booa campeão, a vitória é sua!...uma revanche, o que acha?", "Vitoria", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        ReiniciarJogo();
                        Limpar();
                    }
                    else
                    {
                        Close();
                    }
                }
                pontos++;
                lbPonto.Text = "Pontos: " + pontos;
            }

            else
            {
                pontos--;
                lbPonto.Text = "Pontos: " + pontos;
                erro++;
                lbErro.Text = "Erros(8): " + erro;
                CadaErro();
                sp.Write("1");
            }

            if (erro == 8)
            {
                if (MessageBox.Show("Essa não, você perdeu! Reinicie o programa e tente de novo!...deseja jogar novamente?", "Perdeu", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ReiniciarJogo();
                    Limpar();
                }

                else
                {
                    Close();
                }
            }
        }
        public void ReiniciarJogo()
        {
            //Habilitar botões para reiniciar o jogo
            btnLetra.Enabled = true;
            button1.Enabled =  true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button2.Enabled =  true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
            button25.Enabled = true;
            button26.Enabled = true;
            button27.Enabled = true;
            button28.Enabled = true;
            button29.Enabled = true;
            button3.Enabled =  true;
            button30.Enabled = true;
            button31.Enabled = true;
            button32.Enabled = true;
            button33.Enabled = true;
            button34.Enabled = true;
            button35.Enabled = true;
            button37.Enabled = true;
            button38.Enabled = true;
            button39.Enabled = true;
            button4.Enabled =  true;
            button40.Enabled = true;
            button5.Enabled =  true;
            button6.Enabled =  true;
            button7.Enabled =  true;
            button8.Enabled =  true;
            button9.Enabled =  true;
            //--------------------//
            osDic.PosicionarNoPrimeiro();
            AtualizarTela();
            tabControl1.TabPages.Remove(tabPage2);
            //tabControl1.TabPages.Insert(1,tabPage2);//
            Random federal = new Random();
            int indice = federal.Next(osDic.Tamanho);
            palavraSorteada = osDic[indice];
            tmrTempo.Enabled = true;
            if (cbxDica.Checked)
            {
                tmrTempo.Enabled = true;
                lbDica.Text = "Dica: " + palavraSorteada.Dica;
            }
            dataPalavra.RowCount = 1;
            dataPalavra.ColumnCount = palavraSorteada.Palavra.Trim().Length;
            for (int i = 0; i < dataPalavra.ColumnCount; i++)
            {
                dataPalavra.Columns[i].Width = 30;
                dataPalavra.Rows[0].Cells[i].Value = null;
            }

            erro = 0;
            pontos = 0;

            lbPonto.Text = "Pontos:____";
            lbErro.Text = "Erros(8):___";
            sp.Write("s"); // Quando o arduino receber o Caracter "s", ele irá desligar os leds
            dataPalavra.Rows[0].Height = 30;
            dataPalavra.Width = 30 * dataPalavra.ColumnCount;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            tmrTempo.Enabled = true;
            osDic.PosicionarNoPrimeiro();
            AtualizarTela();
            tabControl1.TabPages.Remove(tabPage2);
            //tabControl1.TabPages.Insert(1,tabPage2);//
            Random federal = new Random();
            int indice = federal.Next(osDic.Tamanho);
            palavraSorteada = osDic[indice];
            if (cbxDica.Checked)
            {
                tmrTempo.Enabled = true;
                lbDica.Text = "Dica: " + palavraSorteada.Dica;
            }
            dataPalavra.RowCount = 1;
            dataPalavra.ColumnCount = palavraSorteada.Palavra.Trim().Length;
            for (int i = 0; i < dataPalavra.ColumnCount; i++)
            {
                dataPalavra.Columns[i].Width = 30;
            }

            dataPalavra.Rows[0].Height = 30;
            dataPalavra.Width = 30 * dataPalavra.ColumnCount;
            txtNome.ReadOnly = true;
        }


        private void Vencedor()
        {
            pbxFeliz.Visible = true;
            pbxBarriga.Visible = true;
            pbxBracoEsquerdo.Visible = true;
            pbxCintura.Visible = true;
            pbxPernaDireita.Visible = true;
            pbxPernaEsquerda.Visible = true;
            pbxPescoco.Visible = true;
            pbxBracoDireito.Visible = true;
            pbxPescoco.Visible = true;
            pbxBandeira1.Visible = true;
            pbxBandeira2.Visible = true;
            pbxBracoDireito.BringToFront();
            pbxPernaDireita.BringToFront();
            pbxPernaEsquerda.BringToFront();
        }

        private void Derrota()
        {
            pbxMorreu.Visible = true;
            pbxBarriga.Visible = true;
            pbxBracoEsquerdo.Visible = true;
            pbxCintura.Visible = true;
            pbxPernaDireita.Visible = true;
            pbxPernaEsquerda.Visible = true;
            pbxPescoco.Visible = true;
            pbxBracoDireito.Visible = true;
            pbxPescoco.Visible = true;
            pbxFantasma.Visible = true;
        }

        private void tmrTempo_Tick(object sender, EventArgs e)
        {
            if (tempor > 0)
            {
                tempor = tempor - 1;
                lbTempo.Text = $"Tempo restante:{tempor}s";
            }
            else
            {
                tmrTempo.Stop();
                lbTempo.Text = "Tempo restante: 0s";
                MessageBox.Show("Essa não! O tempo acabou, reinicie o programa para jogar de novo");
                Close();
            }
        }
        private void CadaErro() //Método de aparição de imagens na derrota
        {
            switch (erro)

            {
                case 1:
                    pbxCabeca.Visible = true;
                    pbxCabeca.BringToFront();
                    pbxPescoco.Visible = true;
                    pbxPescoco.BringToFront();
                    break;

                case 2:
                    pbxBarriga.Visible = true;
                    pbxBarriga.BringToFront();
                    break;

                case 3:
                    pbxBracoDireito.Visible = true;
                    pbxBracoDireito.BringToFront();
                    break;

                case 4:
                    pbxBracoEsquerdo.Visible = true;
                    pbxBracoEsquerdo.BringToFront();
                    break;

                case 5:
                    pbxCintura.Visible = true;
                    pbxCintura.BringToFront();
                    break;

                case 6:
                    pbxPernaDireita.Visible = true;
                    pbxPernaDireita.BringToFront();
                    break;
                case 7:
                    pbxPernaEsquerda.Visible = true;
                    pbxPernaEsquerda.BringToFront();
                    break;

                case 8:
                    pbxCabeca.Visible = false;
                    pbxMorreu.Visible = true;
                    pbxMorreu.BringToFront();
                    Derrota();
                    break;
            }
        }

        //limpeza do jogo ocorrido anteriormente 
        private void Limpar()
        {
            pbxFeliz.Visible = false;
            pbxBarriga.Visible = false;
            pbxBracoEsquerdo.Visible = false;
            pbxCintura.Visible = false;
            pbxPernaDireita.Visible = false;
            pbxPernaEsquerda.Visible = false;
            pbxPescoco.Visible = false;
            pbxBracoDireito.Visible = false;
            pbxBandeira1.Visible = false;
            pbxBandeira2.Visible = false;
            pbxMorreu.Visible = false;
            pbxFantasma.Visible = false;
            pbxCabeca.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sp.PortName = txtArd.Text;
            sp.Open();
        }

        private void cbxArduino_CheckedChanged(object sender, EventArgs e)
        {
            txtArd.Enabled = true;
            button13.Enabled = true;
        } 
    }
}