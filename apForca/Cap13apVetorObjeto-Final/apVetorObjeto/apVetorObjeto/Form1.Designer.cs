
namespace apVetorObjeto
{
  partial class FrmFunc
  {
    /// <summary>
    /// Variável de designer necessária.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpar os recursos que estão sendo usados.
    /// </summary>
    /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código gerado pelo Windows Form Designer

    /// <summary>
    /// Método necessário para suporte ao Designer - não modifique 
    /// o conteúdo deste método com o editor de código.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFunc));
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tpCadastro = new System.Windows.Forms.TabPage();
      this.txtSalario = new System.Windows.Forms.TextBox();
      this.txtNome = new System.Windows.Forms.TextBox();
      this.txtMatricula = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tpLista = new System.Windows.Forms.TabPage();
      this.tsBotoes = new System.Windows.Forms.ToolStrip();
      this.btnInicio = new System.Windows.Forms.ToolStripButton();
      this.btnAnterior = new System.Windows.Forms.ToolStripButton();
      this.btnProximo = new System.Windows.Forms.ToolStripButton();
      this.btnUltimo = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnProcurar = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.btnNovo = new System.Windows.Forms.ToolStripButton();
      this.btnEditar = new System.Windows.Forms.ToolStripButton();
      this.btnCancelar = new System.Windows.Forms.ToolStripButton();
      this.btnSalvar = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.btnExcluir = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.btnSair = new System.Windows.Forms.ToolStripButton();
      this.ssMensagem = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.stlbMensagem = new System.Windows.Forms.ToolStripStatusLabel();
      this.imlBotoes = new System.Windows.Forms.ImageList(this.components);
      this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
      this.dgvFuncionarios = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tabControl1.SuspendLayout();
      this.tpCadastro.SuspendLayout();
      this.tpLista.SuspendLayout();
      this.tsBotoes.SuspendLayout();
      this.ssMensagem.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionarios)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tpCadastro);
      this.tabControl1.Controls.Add(this.tpLista);
      this.tabControl1.Location = new System.Drawing.Point(0, 44);
      this.tabControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(703, 262);
      this.tabControl1.TabIndex = 0;
      // 
      // tpCadastro
      // 
      this.tpCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.tpCadastro.Controls.Add(this.txtSalario);
      this.tpCadastro.Controls.Add(this.txtNome);
      this.tpCadastro.Controls.Add(this.txtMatricula);
      this.tpCadastro.Controls.Add(this.label3);
      this.tpCadastro.Controls.Add(this.label2);
      this.tpCadastro.Controls.Add(this.label1);
      this.tpCadastro.Location = new System.Drawing.Point(4, 32);
      this.tpCadastro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tpCadastro.Name = "tpCadastro";
      this.tpCadastro.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tpCadastro.Size = new System.Drawing.Size(695, 226);
      this.tpCadastro.TabIndex = 0;
      this.tpCadastro.Text = "Cadastro";
      // 
      // txtSalario
      // 
      this.txtSalario.Location = new System.Drawing.Point(121, 130);
      this.txtSalario.MaxLength = 10;
      this.txtSalario.Name = "txtSalario";
      this.txtSalario.Size = new System.Drawing.Size(120, 30);
      this.txtSalario.TabIndex = 5;
      // 
      // txtNome
      // 
      this.txtNome.Location = new System.Drawing.Point(121, 79);
      this.txtNome.MaxLength = 30;
      this.txtNome.Name = "txtNome";
      this.txtNome.Size = new System.Drawing.Size(338, 30);
      this.txtNome.TabIndex = 4;
      // 
      // txtMatricula
      // 
      this.txtMatricula.Location = new System.Drawing.Point(121, 33);
      this.txtMatricula.MaxLength = 5;
      this.txtMatricula.Name = "txtMatricula";
      this.txtMatricula.ReadOnly = true;
      this.txtMatricula.Size = new System.Drawing.Size(69, 30);
      this.txtMatricula.TabIndex = 3;
      this.txtMatricula.Leave += new System.EventHandler(this.txtMatricula_Leave);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(18, 133);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(77, 23);
      this.label3.TabIndex = 2;
      this.label3.Text = "Salário:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(18, 82);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 23);
      this.label2.TabIndex = 1;
      this.label2.Text = "Nome:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 36);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(98, 23);
      this.label1.TabIndex = 0;
      this.label1.Text = "Matrícula:";
      // 
      // tpLista
      // 
      this.tpLista.Controls.Add(this.dgvFuncionarios);
      this.tpLista.Location = new System.Drawing.Point(4, 32);
      this.tpLista.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tpLista.Name = "tpLista";
      this.tpLista.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tpLista.Size = new System.Drawing.Size(695, 226);
      this.tpLista.TabIndex = 1;
      this.tpLista.Text = "Lista";
      this.tpLista.UseVisualStyleBackColor = true;
      this.tpLista.Enter += new System.EventHandler(this.tpLista_Enter);
      // 
      // tsBotoes
      // 
      this.tsBotoes.BackColor = System.Drawing.Color.Silver;
      this.tsBotoes.Font = new System.Drawing.Font("Arial", 9F);
      this.tsBotoes.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.tsBotoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.btnProximo,
            this.btnUltimo,
            this.toolStripSeparator1,
            this.btnProcurar,
            this.toolStripSeparator2,
            this.btnNovo,
            this.btnEditar,
            this.btnCancelar,
            this.btnSalvar,
            this.toolStripSeparator3,
            this.btnExcluir,
            this.toolStripSeparator4,
            this.btnSair});
      this.tsBotoes.Location = new System.Drawing.Point(0, 0);
      this.tsBotoes.Name = "tsBotoes";
      this.tsBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
      this.tsBotoes.Size = new System.Drawing.Size(703, 44);
      this.tsBotoes.TabIndex = 1;
      this.tsBotoes.Text = "Ultimo";
      // 
      // btnInicio
      // 
      this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
      this.btnInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnInicio.Name = "btnInicio";
      this.btnInicio.Size = new System.Drawing.Size(45, 41);
      this.btnInicio.Text = "Início";
      this.btnInicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.btnInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnInicio.ToolTipText = "Vai ao primeiro registro";
      this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
      // 
      // btnAnterior
      // 
      this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
      this.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAnterior.Name = "btnAnterior";
      this.btnAnterior.Size = new System.Drawing.Size(62, 41);
      this.btnAnterior.Text = "Anterior";
      this.btnAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnAnterior.ToolTipText = "Vai ao registro anterior";
      this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
      // 
      // btnProximo
      // 
      this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
      this.btnProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnProximo.Name = "btnProximo";
      this.btnProximo.Size = new System.Drawing.Size(66, 41);
      this.btnProximo.Text = "Próximo";
      this.btnProximo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnProximo.ToolTipText = "Vai ao registro seguinte";
      this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
      // 
      // btnUltimo
      // 
      this.btnUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btnUltimo.Image")));
      this.btnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnUltimo.Name = "btnUltimo";
      this.btnUltimo.Size = new System.Drawing.Size(53, 41);
      this.btnUltimo.Text = "Último";
      this.btnUltimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnUltimo.ToolTipText = "Vai ao último registro";
      this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
      // 
      // btnProcurar
      // 
      this.btnProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar.Image")));
      this.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnProcurar.Name = "btnProcurar";
      this.btnProcurar.Size = new System.Drawing.Size(59, 41);
      this.btnProcurar.Text = "Buscar";
      this.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnProcurar.ToolTipText = "Procura registro pela matrícula";
      this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
      // 
      // btnNovo
      // 
      this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
      this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNovo.Name = "btnNovo";
      this.btnNovo.Size = new System.Drawing.Size(45, 41);
      this.btnNovo.Text = "Novo";
      this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNovo.ToolTipText = "Inicia inclusão de novo registro";
      this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
      // 
      // btnEditar
      // 
      this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
      this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnEditar.Name = "btnEditar";
      this.btnEditar.Size = new System.Drawing.Size(50, 41);
      this.btnEditar.Text = "Editar";
      this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnEditar.ToolTipText = "Altera registro atual";
      this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
      // 
      // btnCancelar
      // 
      this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
      this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.Size = new System.Drawing.Size(71, 41);
      this.btnCancelar.Text = "Cancelar";
      this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnCancelar.ToolTipText = "Cancela a operação atual";
      this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
      // 
      // btnSalvar
      // 
      this.btnSalvar.Enabled = false;
      this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
      this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(53, 41);
      this.btnSalvar.Text = "Salvar";
      this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnSalvar.ToolTipText = "Armazena os valores atuais da tela";
      this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 44);
      // 
      // btnExcluir
      // 
      this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
      this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnExcluir.Name = "btnExcluir";
      this.btnExcluir.Size = new System.Drawing.Size(56, 41);
      this.btnExcluir.Text = "Excluir";
      this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnExcluir.ToolTipText = "Remove o registro atual";
      this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 44);
      // 
      // btnSair
      // 
      this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
      this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSair.Name = "btnSair";
      this.btnSair.Size = new System.Drawing.Size(38, 41);
      this.btnSair.Text = "Sair";
      this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnSair.ToolTipText = "Termina a execução deste programa";
      this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
      // 
      // ssMensagem
      // 
      this.ssMensagem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.ssMensagem.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.ssMensagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.stlbMensagem});
      this.ssMensagem.Location = new System.Drawing.Point(0, 306);
      this.ssMensagem.Name = "ssMensagem";
      this.ssMensagem.Padding = new System.Windows.Forms.Padding(2, 0, 19, 0);
      this.ssMensagem.Size = new System.Drawing.Size(703, 26);
      this.ssMensagem.TabIndex = 2;
      this.ssMensagem.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 20);
      this.toolStripStatusLabel1.Text = "Mensagem:";
      // 
      // stlbMensagem
      // 
      this.stlbMensagem.Name = "stlbMensagem";
      this.stlbMensagem.Size = new System.Drawing.Size(90, 20);
      this.stlbMensagem.Text = "Registro 0/0";
      // 
      // imlBotoes
      // 
      this.imlBotoes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBotoes.ImageStream")));
      this.imlBotoes.TransparentColor = System.Drawing.Color.Transparent;
      this.imlBotoes.Images.SetKeyName(0, "first.bmp");
      this.imlBotoes.Images.SetKeyName(1, "prior.bmp");
      this.imlBotoes.Images.SetKeyName(2, "next.bmp");
      this.imlBotoes.Images.SetKeyName(3, "last.bmp");
      this.imlBotoes.Images.SetKeyName(4, "Oeil2.bmp");
      this.imlBotoes.Images.SetKeyName(5, "Add.bmp");
      this.imlBotoes.Images.SetKeyName(6, "COPY.BMP");
      this.imlBotoes.Images.SetKeyName(7, "UNDO.BMP");
      this.imlBotoes.Images.SetKeyName(8, "Save.bmp");
      this.imlBotoes.Images.SetKeyName(9, "Minus.bmp");
      this.imlBotoes.Images.SetKeyName(10, "CLOSE1.BMP");
      this.imlBotoes.Images.SetKeyName(11, "about.bmp");
      this.imlBotoes.Images.SetKeyName(12, "abort.bmp");
      this.imlBotoes.Images.SetKeyName(13, "FIND.BMP");
      this.imlBotoes.Images.SetKeyName(14, "PRINTER5.BMP");
      this.imlBotoes.Images.SetKeyName(15, "REDO.BMP");
      this.imlBotoes.Images.SetKeyName(16, "WINNEXT.BMP");
      this.imlBotoes.Images.SetKeyName(17, "WINPREV.BMP");
      // 
      // dlgAbrir
      // 
      this.dlgAbrir.DefaultExt = "*.txt";
      // 
      // dgvFuncionarios
      // 
      this.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvFuncionarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
      this.dgvFuncionarios.Location = new System.Drawing.Point(87, 17);
      this.dgvFuncionarios.Name = "dgvFuncionarios";
      this.dgvFuncionarios.RowHeadersWidth = 51;
      this.dgvFuncionarios.RowTemplate.Height = 24;
      this.dgvFuncionarios.Size = new System.Drawing.Size(511, 193);
      this.dgvFuncionarios.TabIndex = 0;
      // 
      // Column1
      // 
      this.Column1.HeaderText = "Matrícula";
      this.Column1.MinimumWidth = 6;
      this.Column1.Name = "Column1";
      this.Column1.Width = 80;
      // 
      // Column2
      // 
      this.Column2.HeaderText = "Nome";
      this.Column2.MinimumWidth = 6;
      this.Column2.Name = "Column2";
      this.Column2.Width = 250;
      // 
      // Column3
      // 
      this.Column3.HeaderText = "Salário";
      this.Column3.MinimumWidth = 6;
      this.Column3.Name = "Column3";
      // 
      // FrmFunc
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(703, 332);
      this.Controls.Add(this.ssMensagem);
      this.Controls.Add(this.tsBotoes);
      this.Controls.Add(this.tabControl1);
      this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.Name = "FrmFunc";
      this.Text = "Manutenção de Cadastro de Funcionários";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFunc_FormClosing);
      this.Load += new System.EventHandler(this.FrmFunc_Load);
      this.tabControl1.ResumeLayout(false);
      this.tpCadastro.ResumeLayout(false);
      this.tpCadastro.PerformLayout();
      this.tpLista.ResumeLayout(false);
      this.tsBotoes.ResumeLayout(false);
      this.tsBotoes.PerformLayout();
      this.ssMensagem.ResumeLayout(false);
      this.ssMensagem.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionarios)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tpCadastro;
    private System.Windows.Forms.TabPage tpLista;
    private System.Windows.Forms.ToolStrip tsBotoes;
    private System.Windows.Forms.StatusStrip ssMensagem;
    private System.Windows.Forms.TextBox txtSalario;
    private System.Windows.Forms.TextBox txtNome;
    private System.Windows.Forms.TextBox txtMatricula;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ToolStripButton btnInicio;
    private System.Windows.Forms.ToolStripButton btnAnterior;
    private System.Windows.Forms.ToolStripButton btnProximo;
    private System.Windows.Forms.ToolStripButton btnUltimo;
    private System.Windows.Forms.ImageList imlBotoes;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnProcurar;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton btnNovo;
    private System.Windows.Forms.ToolStripButton btnEditar;
    private System.Windows.Forms.ToolStripButton btnCancelar;
    private System.Windows.Forms.ToolStripButton btnSalvar;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton btnExcluir;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripButton btnSair;
    private System.Windows.Forms.OpenFileDialog dlgAbrir;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel stlbMensagem;
    private System.Windows.Forms.DataGridView dgvFuncionarios;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
  }
}

