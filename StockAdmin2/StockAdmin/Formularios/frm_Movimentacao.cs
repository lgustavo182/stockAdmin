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
    public partial class frm_Movimentacao : Form
    {

        FuncGeral obj_FuncGeral = new FuncGeral();
        Movimentacao Movimentacao_Principal = new Movimentacao();

        public frm_Movimentacao()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 1);
            obj_FuncGeral.HabilitaTela(this, false);
            lv_Titulos();
        }


        /**********************************************************************************
        * NOME:            lv_Titulos
        * PROCEDIMENTO:    Preenche os nomes das colunas na Grid da Lv_MovimentacaoItem
        * DT CRIAÇÃO:      06/03/2020
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private void lv_Titulos()
        {
            ltv_MovimentacaoItem.View = View.Details;
            ltv_MovimentacaoItem.Columns.Add("Código", 50);
            ltv_MovimentacaoItem.Columns.Add("Nome do Produto", 120);
            ltv_MovimentacaoItem.Columns.Add("Titulo da Categoria", 120);
            ltv_MovimentacaoItem.Columns.Add("Quantidade", 120);
            ltv_MovimentacaoItem.Columns.Add("Valor", 120);
            ltv_MovimentacaoItem.Columns.Add("Data", 15);
        }


        /**********************************************************************************
        * NOME:            PopulaLista
        * PROCEDIMENTO:    Preenche o ListBox com os dados que estão na TB_Movimentacao
        * DT CRIAÇÃO:      06/03/2020
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private void PopulaLista()
        {
            Produto obj_Produto = new Produto();
            ProdutoBD obj_ProdutoBD = new ProdutoBD();

            Categoria obj_Categoria = new Categoria();
            CategoriaBD obj_CategoriaBD = new CategoriaBD();

            // Instância do objeto MovimentacaoBD
            MovimentacaoBD obj_MovimentacaoBD = new MovimentacaoBD();

            // Instância do objeto Lista
            List<Movimentacao> Lista = new List<Movimentacao>();

            // Limpando o ListBox
            lbox_Movimentacao.Items.Clear();

            Lista = obj_MovimentacaoBD.FindAllMovimentacao();

            if (Lista != null)
            {
                for (int i = 0; i <= Lista.Count - 1; i++)
                {
                    obj_Produto.COD_PRODUTO = Lista[i].COD_PRODUTO;
                    obj_Categoria.TIT_CATEGORIA = Lista[i].TIT_CATEGORIA;

                    lbox_Movimentacao.Items.Add(Lista[i].COD_MOVIMENTACAO.ToString() + "-" + obj_ProdutoBD.FindByCodProduto(obj_Produto).COD_PRODUTO + "-" + obj_ProdutoBD.FindByCodProduto(obj_Produto).NM_PRODUTO);
                }
            }
        }

        private void lbox_Movimentacao_Click(object sender, EventArgs e)
        {
            if (lbox_Movimentacao.SelectedIndex != -1)
            {
                MovimentacaoBD obj_MovimentacaoBD = new MovimentacaoBD();

                string sLinha = lbox_Movimentacao.Items[lbox_Movimentacao.SelectedIndex].ToString();

                int ipos = 0;

                for (int t = 0; t <= sLinha.Length; t++)
                {
                    if (sLinha.Substring(t, 1) == "-")
                    {
                        ipos = t;
                        break;
                    }
                }

                Movimentacao_Principal.COD_MOVIMENTACAO = Convert.ToInt16(sLinha.Substring(0, ipos));

                Movimentacao_Principal = obj_MovimentacaoBD.FindByCodMovimentacao(Movimentacao_Principal);

                PopulaTela(Movimentacao_Principal);

                obj_FuncGeral.StatusBtn(this, 2);

            }
        }

        /**********************************************************************************
        * NOME:            PopulaTela
        * PROCEDIMENTO:    Preenche a tela com os dados do Objeto Principal
        * DT CRIAÇÃO:      06/03/2020
        * DT ALTERAÇÃO:    -
        * PARAMETRO:       
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private void PopulaTela(Movimentacao aobj_Movimentacao)
        {
            if (aobj_Movimentacao.COD_MOVIMENTACAO != -1)
            {
                ProdutoBD obj_ProdutoBD = new ProdutoBD();
                Produto obj_Produto = new Produto();

                CategoriaBD obj_CategoriaBD = new CategoriaBD();
                Categoria obj_Categoria = new Categoria();

                tbox_Cod_Movimentacao.Text = aobj_Movimentacao.COD_MOVIMENTACAO.ToString();
                mtbox_Dt_Movimentacao.Text = DateTime.Now.ToShortTimeString();

                obj_Produto.COD_PRODUTO = Movimentacao_Principal.COD_PRODUTO;
                tbox_Cod_Produto.Text = obj_Produto.COD_PRODUTO.ToString();
                lb_Nm_Produto.Text = obj_ProdutoBD.FindByCodProduto(obj_Produto).NM_PRODUTO;

                obj_Categoria.TIT_CATEGORIA = Movimentacao_Principal.TIT_CATEGORIA;
                lb_Tit_Categoria.Text = obj_CategoriaBD.FindByCodCategoria(obj_Categoria).TIT_CATEGORIA;

                tbox_Obs_Movimentacao.Text = aobj_Movimentacao.OBS_MOVIMENTACAO;

                PopulaMovimentacaoItem();

                //ToDo: Luis Gustavo - 06/03/2020 - falta popular os itens da agenda

            }
        }


        /**********************************************************************************
        * NOME:            PopulaObjeto
        * PROCEDIMENTO:    Preenche o objeto com os dados da  tela 
        * DT CRIAÇÃO:      06/03/2020
        * DT ALTERAÇÃO:    -
        * PARAMETRO:       
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private Movimentacao PopulaObjeto()
        {
            Movimentacao aobj_Movimentacao = new Movimentacao();

            if (tbox_Cod_Movimentacao.Text != "")
            {
                aobj_Movimentacao.COD_MOVIMENTACAO = Convert.ToInt16(tbox_Cod_Movimentacao.Text);
            }

            aobj_Movimentacao.DATA_MOVIMENTACAO = Convert.ToDateTime(mtbox_Dt_Movimentacao.Text);
            aobj_Movimentacao.COD_PRODUTO = Convert.ToInt16(tbox_Cod_Produto.Text);
            aobj_Movimentacao.TIT_CATEGORIA = lb_Tit_Categoria.Text;
            aobj_Movimentacao.OBS_MOVIMENTACAO = tbox_Obs_Movimentacao.Text;


            return aobj_Movimentacao;
        }


        /**********************************************************************************
        * NOME:            PopulaMovimentacaoItem
        * PROCEDIMENTO:    Preenche a Lista de itens da agenda
        * DT CRIAÇÃO:      10/02/2019
        * DT ALTERAÇÃO:    -
        * PARAMETRO:       
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private void PopulaMovimentacaoItem()
        {
            MovimentacaoItemBD obj_MovimentacaoItemBD = new MovimentacaoItemBD();
            Produto obj_Produto = new Produto();
            ProdutoBD obj_ProdutoBD = new ProdutoBD();

            Movimentacao obj_Movimentacao = new Movimentacao();
            MovimentacaoBD obj_MovimentacaoBD = new MovimentacaoBD();

            MovimentacaoItem obj_MovimentacaoItem = new MovimentacaoItem();


            List<MovimentacaoItem> ListMovimentacaoItem = new List<MovimentacaoItem>();

            ListMovimentacaoItem = obj_MovimentacaoItemBD.FindAllMovimentacaoItem();

            if (ListMovimentacaoItem != null)
            {
                for (int t = 0; t < ListMovimentacaoItem.Count; t++)
                {
                    obj_Produto.COD_PRODUTO = ListMovimentacaoItem[t].COD_PRODUTO;
                    obj_Produto = obj_ProdutoBD.FindByCodProduto(obj_Produto);
                    PopulaLinha(obj_Produto.COD_PRODUTO.ToString(), obj_Produto.NM_PRODUTO, ListMovimentacaoItem[t].TIT_CATEGORIA, obj_Movimentacao.QTD_PRODUTO.ToString(), obj_MovimentacaoItem.VL_MOVIMENTACAOITEM.ToString());

                }

            }



        }


        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            MovimentacaoBD obj_MovimentacaoBD = new MovimentacaoBD();
            MovimentacaoItemBD obj_MovimentacaoItemBD = new MovimentacaoItemBD();
            MovimentacaoItem obj_MovimentacaoItem = new MovimentacaoItem();

            Movimentacao_Principal = PopulaObjeto();

            if (Movimentacao_Principal.COD_MOVIMENTACAO != -1)
            {
                obj_MovimentacaoBD.Alterar(Movimentacao_Principal);
                MessageBox.Show("Movimentacao alterada com sucesso. ", "Alteração da Movimentacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Movimentacao_Principal.COD_MOVIMENTACAO = obj_MovimentacaoBD.Incluir(Movimentacao_Principal);
                MessageBox.Show("Movimentacao Incluida com sucesso. ", "Inclusão da Movimentacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulaTela(Movimentacao_Principal);
            }

            if (ltv_MovimentacaoItem.Items.Count != 0)
            {
                obj_MovimentacaoItem.COD_MOVIMENTACAO = Convert.ToInt16(tbox_Cod_Movimentacao.Text);

                obj_MovimentacaoItemBD.Excluir(obj_MovimentacaoItem);

                for (int i = 0; i < ltv_MovimentacaoItem.Items.Count; i++)
                {

                    obj_MovimentacaoItem.COD_MOVIMENTACAO = Convert.ToInt16(tbox_Cod_Movimentacao.Text);
                    obj_MovimentacaoItem.COD_PRODUTO = Convert.ToInt16(ltv_MovimentacaoItem.Items[i].SubItems[0].Text);
                    obj_MovimentacaoItem.VL_MOVIMENTACAOITEM = Convert.ToInt16(ltv_MovimentacaoItem.Items[i].SubItems[2].Text);
                    int cod = obj_MovimentacaoItemBD.Incluir(obj_MovimentacaoItem);

                }

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
            mtbox_Dt_Movimentacao.Focus();

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, false);

            if (Movimentacao_Principal.COD_MOVIMENTACAO != -1)
            {
                PopulaTela(Movimentacao_Principal);
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
            mtbox_Dt_Movimentacao.Focus();

        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            MovimentacaoBD obj_MovimentacaoBD = new MovimentacaoBD();
            DialogResult varResp = MessageBox.Show("Confirma a Exclusão?", "Exclusão da Movimentacao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (varResp == DialogResult.Yes)
            {
                if (obj_MovimentacaoBD.Excluir(Movimentacao_Principal))
                {
                    MessageBox.Show("Movimentacao excluida com sucesso. ", "Exclusão da Movimentacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 1);
                PopulaLista();


            }

        }

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            frm_Produto obj_frm_Produto = new frm_Produto();
            obj_frm_Produto.ShowDialog();
        }

        private void btn_Categoria_Click(object sender, EventArgs e)
        {
            frm_Categoria obj_frm_Categoria = new frm_Categoria();
            obj_frm_Categoria.ShowDialog();
        }

        private void tbox_Cod_Produto_Leave(object sender, EventArgs e)
        {
            ProdutoBD obj_ProdutoBD = new ProdutoBD();
            Produto obj_Produto = new Produto();
            if (tbox_Cod_Produto.Text != null)
            {
                obj_Produto.COD_PRODUTO = Convert.ToInt16(tbox_Cod_Produto.Text);
                lb_Nm_Produto.Text = obj_ProdutoBD.FindByCodProduto(obj_Produto).NM_PRODUTO;
            }
        }


        /**********************************************************************************
        * NOME:            PopulaLinha
        * PROCEDIMENTO:    Preenche a Linha do List View Movimentacao Item
        * DT CRIAÇÃO:      10/02/2019
        * DT ALTERAÇÃO:    -
        * PARAMETRO:       
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private void PopulaLinha(string codProd, string nmProd, string titCateg, string qtdProd, string vlMov)
        {
            ListViewItem item = new ListViewItem(new[] { codProd, nmProd, titCateg, qtdProd, vlMov });

            ltv_MovimentacaoItem.Items.Add(item);
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            var confimation = MessageBox.Show("Deseja retirar esta movimentação da lista?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confimation == DialogResult.Yes)
            {
                for (int i = 0; i < ltv_MovimentacaoItem.Items.Count; i++)
                {
                    if (ltv_MovimentacaoItem.Items[i].Selected)
                    {
                        tbox_Cod_Produto.Text = ltv_MovimentacaoItem.Items[i].SubItems[0].Text;
                        lb_Nm_Produto.Text = ltv_MovimentacaoItem.Items[i].SubItems[1].Text;
                        lb_Tit_Categoria.Text = ltv_MovimentacaoItem.Items[i].SubItems[2].Text;
                        tbox_Qtd_Produto.Text = ltv_MovimentacaoItem.Items[i].SubItems[3].Text;
                        lb_Vl_MovimentacaoItem.Text = ltv_MovimentacaoItem.Items[i].SubItems[4].Text;

                        ltv_MovimentacaoItem.Items[i].Remove();
                    }
                }
            }
        }
        private void btn_Down_Click(object sender, EventArgs e)
        {
            PopulaLinha(tbox_Cod_Produto.Text, lb_Nm_Produto.Text, lb_Tit_Categoria.Text, tbox_Qtd_Produto.Text, lb_Vl_MovimentacaoItem.Text);



        }



        private void tbox_Qtd_Produto_Leave(object sender, EventArgs e)
        {
            ProdutoBD obj_ProdutoBD = new ProdutoBD();
            Produto obj_Produto = new Produto();
            obj_Produto.COD_PRODUTO = Convert.ToInt16(tbox_Cod_Produto.Text);
            obj_Produto = obj_ProdutoBD.FindByCodProduto(obj_Produto);
            lb_Vl_MovimentacaoItem.Text = (obj_Produto.VLV_PRODUTO * Convert.ToDouble(tbox_Qtd_Produto.Text)).ToString();
        }

        private void tbox_Cod_Produto_TextChanged(object sender, EventArgs e)
        {
            ProdutoBD obj_ProdutoBD = new ProdutoBD();
            Produto obj_Produto = new Produto();

            CategoriaBD obj_CategoriaBD = new CategoriaBD();
            Categoria obj_Categoria = new Categoria();

            if (tbox_Cod_Produto.Text != "")
            {
                obj_Produto.COD_PRODUTO = Convert.ToInt16(tbox_Cod_Produto.Text);
                obj_Produto = obj_ProdutoBD.FindByCodProduto(obj_Produto);


                lb_Nm_Produto.Text = obj_Produto.NM_PRODUTO;

                obj_Categoria.COD_CATEGORIA = obj_Produto.COD_CATEGORIA;
                lb_Tit_Categoria.Text = obj_CategoriaBD.FindByCodCategoria(obj_Categoria).TIT_CATEGORIA;


                tbox_Qtd_Produto.Text = "0";
                lb_Vl_MovimentacaoItem.Text = "0";

            }
        }
    }
}




