using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO_UC10
{
    public partial class frm_Produto : Form
    {

        FuncGeral obj_FuncGeral = new FuncGeral();
        Produto Produto_Principal = new Produto();

        public frm_Produto()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 1);
            obj_FuncGeral.HabilitaTela(this, false);
        }

        /**********************************************************************************
        * NOME:            PopulaLista
        * PROCEDIMENTO:    Preenche o ListBox com os dados que estão na TB_Produto
        * DT CRIAÇÃO:      17/02/2020
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro 
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private void PopulaLista()
        {
            // Instância do objeto ProdutoBD
            ProdutoBD obj_ProdutoBD = new ProdutoBD();

            // Instância do objeto Lista
            List<Produto> Lista = new List<Produto>();

            // Limpando o ListBox
            lbox_Produtos.Items.Clear();

            Lista = obj_ProdutoBD.FindAllProduto();

            if (Lista != null)
            {
                for (int i = 0; i <= Lista.Count - 1; i++)
                {
                    lbox_Produtos.Items.Add(Lista[i].COD_PRODUTO.ToString() + "-" + Lista[i].NM_PRODUTO);
                }
            }
        }

        private void lbox_Produtos_Click(object sender, EventArgs e)
        {
            if (lbox_Produtos.SelectedIndex != -1)
            {
                ProdutoBD obj_ProdutoBD = new ProdutoBD();

                string sLinha = lbox_Produtos.Items[lbox_Produtos.SelectedIndex].ToString();

                int ipos = 0;

                for (int t = 0; t <= sLinha.Length; t++)
                {
                    if (sLinha.Substring(t, 1) == "-")
                    {
                        ipos = t;
                        break;
                    }
                }

                Produto_Principal.COD_PRODUTO = Convert.ToInt16(sLinha.Substring(0, ipos));

                Produto_Principal = obj_ProdutoBD.FindByCodProduto(Produto_Principal);

                PopulaTela(Produto_Principal);

                obj_FuncGeral.StatusBtn(this, 2);

            }
        }

        /**********************************************************************************
        * NOME:            PopulaTela
        * PROCEDIMENTO:    Preenche a tela com os dados do Objeto Principal
        * DT CRIAÇÃO:      17/02/2020
        * DT ALTERAÇÃO:    -
        * PARAMETRO:       
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro .
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private void PopulaTela(Produto aobj_Produto)
        {
            if (aobj_Produto.COD_PRODUTO != -1)
            {
                CategoriaBD obj_CategoriaBD = new CategoriaBD();
                Categoria obj_Categoria = new Categoria();

                tbox_Cod_Produto.Text = aobj_Produto.COD_PRODUTO.ToString();
                tbox_Cod_Categoria.Text = aobj_Produto.COD_CATEGORIA.ToString();
                tbox_Nm_Produto.Text = aobj_Produto.NM_PRODUTO;
                tbox_Vlv_Produto.Text = aobj_Produto.VLV_PRODUTO.ToString(); ;
                tbox_Vlc_Produto.Text = aobj_Produto.VLC_PRODUTO.ToString();
                tbox_Nf_Produto.Text = Convert.ToString (aobj_Produto.NF_PRODUTO);


                obj_Categoria.COD_CATEGORIA = aobj_Produto.COD_CATEGORIA;

                lb_Tit_Categoria.Text = obj_CategoriaBD.FindByCodCategoria(obj_Categoria).TIT_CATEGORIA;
            }
        }


        /**********************************************************************************
        * NOME:            PopulaObjeto
        * PROCEDIMENTO:    Preenche o objeto com os dados da  tela 
        * DT CRIAÇÃO:      17/02/2020
        * DT ALTERAÇÃO:    -
        * PARAMETRO:       
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro .
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private Produto PopulaObjeto()
        {
            Produto aobj_Produto = new Produto();

            if (tbox_Cod_Produto.Text != "")
            {
                aobj_Produto.COD_PRODUTO = Convert.ToInt16(tbox_Cod_Produto.Text);
            }
            
            aobj_Produto.COD_CATEGORIA = Convert.ToInt16(tbox_Cod_Categoria.Text);
            aobj_Produto.NM_PRODUTO = tbox_Nm_Produto.Text;
            aobj_Produto.VLV_PRODUTO = Convert.ToDouble(tbox_Vlv_Produto.Text);
            aobj_Produto.VLC_PRODUTO = Convert.ToDouble(tbox_Vlc_Produto.Text);

            
            return aobj_Produto;
        }


        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            ProdutoBD obj_ProdutoBD = new ProdutoBD();

            Produto_Principal = PopulaObjeto();

            if (Produto_Principal.COD_PRODUTO != -1)
            {
                obj_ProdutoBD.Alterar(Produto_Principal);
                MessageBox.Show("Produto alterada com sucesso. ", "Alteração da Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Produto_Principal.COD_PRODUTO = obj_ProdutoBD.Incluir(Produto_Principal);
                MessageBox.Show("Produto Incluido com sucesso. ", "Inclusão da Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulaTela(Produto_Principal);
            }

            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);
            PopulaLista();

        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.LimpaTela(this);
            obj_FuncGeral.StatusBtn(this, 3);
            tbox_Nm_Produto.Focus();

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, false);

            if (Produto_Principal.COD_PRODUTO != -1)
            {
                PopulaTela(Produto_Principal);
                obj_FuncGeral.StatusBtn(this, 2);
            }
            else
            {
                obj_FuncGeral.StatusBtn(this, 1);
            }

        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.StatusBtn(this, 3);
            tbox_Nm_Produto.Focus();

        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            ProdutoBD obj_ProdutoBD = new ProdutoBD();
            DialogResult varResp = MessageBox.Show("Confirma a Exclusão?", "Exclusão do Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (varResp == DialogResult.Yes)
            {
                if (obj_ProdutoBD.Excluir(Produto_Principal))
                {
                    MessageBox.Show("Produto excluida com sucesso. ", "Exclusão do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 1);
                PopulaLista();


            }

        }

        private void btn_Categoria_Click(object sender, EventArgs e)
        {
            frm_Categoria obj_frm_Categoria = new frm_Categoria();
            obj_frm_Categoria.ShowDialog();
        }

        private void tbox_Cod_Categoria_Leave(object sender, EventArgs e)
        {
            if (tbox_Cod_Categoria.Text != "")
            {
                CategoriaBD obj_CategoriaBD = new CategoriaBD();
                Categoria obj_Categoria = new Categoria();

                obj_Categoria.COD_CATEGORIA = Convert.ToInt16(tbox_Cod_Categoria.Text);

                lb_Tit_Categoria.Text = obj_CategoriaBD.FindByCodCategoria(obj_Categoria).TIT_CATEGORIA;
            }
            else
            {
                lb_Tit_Categoria.Text = "";
            }
        }


    }
}
