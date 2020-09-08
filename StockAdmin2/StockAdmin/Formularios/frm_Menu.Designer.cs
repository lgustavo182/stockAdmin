namespace PROJETO_UC10
{
    partial class frm_Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Menu));
            this.btn_Produto = new System.Windows.Forms.Button();
            this.btn_Categoria = new System.Windows.Forms.Button();
            this.btn_Usuario = new System.Windows.Forms.Button();
            this.btn_Movimentacao = new System.Windows.Forms.Button();
            this.btn_Sair = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Produto
            // 
            this.btn_Produto.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_Produto.BackColor = System.Drawing.Color.Transparent;
            this.btn_Produto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Produto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Produto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Produto.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Produto.ForeColor = System.Drawing.Color.White;
            this.btn_Produto.Image = ((System.Drawing.Image)(resources.GetObject("btn_Produto.Image")));
            this.btn_Produto.Location = new System.Drawing.Point(120, 132);
            this.btn_Produto.Name = "btn_Produto";
            this.btn_Produto.Size = new System.Drawing.Size(98, 101);
            this.btn_Produto.TabIndex = 0;
            this.btn_Produto.Text = "Cadastrar Produto";
            this.btn_Produto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Produto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Produto.UseCompatibleTextRendering = true;
            this.btn_Produto.UseVisualStyleBackColor = false;
            this.btn_Produto.Click += new System.EventHandler(this.btn_Produto_Click);
            // 
            // btn_Categoria
            // 
            this.btn_Categoria.BackColor = System.Drawing.Color.Transparent;
            this.btn_Categoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Categoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Categoria.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Categoria.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Categoria.Image = ((System.Drawing.Image)(resources.GetObject("btn_Categoria.Image")));
            this.btn_Categoria.Location = new System.Drawing.Point(338, 135);
            this.btn_Categoria.Name = "btn_Categoria";
            this.btn_Categoria.Size = new System.Drawing.Size(119, 98);
            this.btn_Categoria.TabIndex = 1;
            this.btn_Categoria.Text = "Cadastrar Categoria";
            this.btn_Categoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Categoria.UseVisualStyleBackColor = false;
            this.btn_Categoria.Click += new System.EventHandler(this.btn_Categoria_Click);
            // 
            // btn_Usuario
            // 
            this.btn_Usuario.BackColor = System.Drawing.Color.Transparent;
            this.btn_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Usuario.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btn_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Usuario.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Usuario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Usuario.Image = ((System.Drawing.Image)(resources.GetObject("btn_Usuario.Image")));
            this.btn_Usuario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Usuario.Location = new System.Drawing.Point(112, 291);
            this.btn_Usuario.Name = "btn_Usuario";
            this.btn_Usuario.Size = new System.Drawing.Size(106, 98);
            this.btn_Usuario.TabIndex = 0;
            this.btn_Usuario.Text = "Cadastrar Usuário";
            this.btn_Usuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Usuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Usuario.UseMnemonic = false;
            this.btn_Usuario.UseVisualStyleBackColor = false;
            this.btn_Usuario.UseWaitCursor = true;
            this.btn_Usuario.Click += new System.EventHandler(this.btn_Usuario_Click);
            // 
            // btn_Movimentacao
            // 
            this.btn_Movimentacao.BackColor = System.Drawing.Color.Transparent;
            this.btn_Movimentacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Movimentacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Movimentacao.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Movimentacao.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Movimentacao.Image = ((System.Drawing.Image)(resources.GetObject("btn_Movimentacao.Image")));
            this.btn_Movimentacao.Location = new System.Drawing.Point(338, 291);
            this.btn_Movimentacao.Name = "btn_Movimentacao";
            this.btn_Movimentacao.Size = new System.Drawing.Size(119, 98);
            this.btn_Movimentacao.TabIndex = 3;
            this.btn_Movimentacao.Text = "Movimentar Estoque";
            this.btn_Movimentacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Movimentacao.UseVisualStyleBackColor = false;
            this.btn_Movimentacao.Click += new System.EventHandler(this.btn_Movimentacao_Click);
            // 
            // btn_Sair
            // 
            this.btn_Sair.BackColor = System.Drawing.Color.Transparent;
            this.btn_Sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Sair.Font = new System.Drawing.Font("Microsoft New Tai Lue", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sair.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Sair.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sair.Image")));
            this.btn_Sair.Location = new System.Drawing.Point(585, 212);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(130, 118);
            this.btn_Sair.TabIndex = 4;
            this.btn_Sair.Text = "Sair";
            this.btn_Sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Sair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Sair.UseVisualStyleBackColor = false;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(544, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 162);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frm_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(746, 479);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Sair);
            this.Controls.Add(this.btn_Movimentacao);
            this.Controls.Add(this.btn_Usuario);
            this.Controls.Add(this.btn_Categoria);
            this.Controls.Add(this.btn_Produto);
            this.Name = "frm_Menu";
            this.Text = "frm_Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Produto;
        private System.Windows.Forms.Button btn_Categoria;
        private System.Windows.Forms.Button btn_Movimentacao;
        private System.Windows.Forms.Button btn_Sair;
        private System.Windows.Forms.Button btn_Usuario;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}