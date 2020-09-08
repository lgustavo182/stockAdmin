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
    public partial class frm_Categoria : Form
    {

        FuncGeral obj_FuncGeral = new FuncGeral();
        Categoria Categoria_Principal = new Categoria();

        public frm_Categoria()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 1);
            obj_FuncGeral.HabilitaTela(this, false);
        }

        /**********************************************************************************
        * NOME:            PopulaLista
        * PROCEDIMENTO:    Preenche o ListBox com os dados que estão na TB_Categoria
        * DT CRIAÇÃO:      02/12/2019
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Mfacine (Monstro)
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private void PopulaLista()
        {
            // Instância do objeto CategoriaBD
            CategoriaBD obj_CategoriaBD = new CategoriaBD();

            // Instância do objeto Lista
            List<Categoria> Lista = new List<Categoria>();

            // Limpando o ListBox
            lbox_Categorias.Items.Clear();

            Lista = obj_CategoriaBD.FindAllCategoria();

            if (Lista != null)
            {
                for (int i = 0; i <= Lista.Count - 1; i++)
                {
                    lbox_Categorias.Items.Add(Lista[i].COD_CATEGORIA.ToString() + "-" + Lista[i].TIT_CATEGORIA);
                }
            }
        }

        private void lbox_Categorias_Click(object sender, EventArgs e)
        {
            if (lbox_Categorias.SelectedIndex != -1)
            {
                CategoriaBD obj_CategoriaBD = new CategoriaBD();

                string sLinha = lbox_Categorias.Items[lbox_Categorias.SelectedIndex].ToString();

                int ipos = 0;

                for (int t = 0; t <= sLinha.Length; t++)
                {
                    if (sLinha.Substring(t, 1) == "-")
                    {
                        ipos = t;
                        break;
                    }
                }

                Categoria_Principal.COD_CATEGORIA = Convert.ToInt16(sLinha.Substring(0, ipos));

                Categoria_Principal = obj_CategoriaBD.FindByCodCategoria(Categoria_Principal);

                PopulaTela(Categoria_Principal);

                obj_FuncGeral.StatusBtn(this, 2);

            }
        }

        /**********************************************************************************
        * NOME:            PopulaTela
        * PROCEDIMENTO:    Preenche a tela com os dados do Objeto Principal
        * DT CRIAÇÃO:      02/12/2019
        * DT ALTERAÇÃO:    -
        * PARAMETRO:       
        * ESCRITA POR:     Mfacine (Monstro)
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private void PopulaTela(Categoria aobj_Categoria)
        {
            if (aobj_Categoria.COD_CATEGORIA != -1)
            {
                tbox_Cod_Categoria.Text = aobj_Categoria.COD_CATEGORIA.ToString();
                tbox_Tit_Categoria.Text = aobj_Categoria.TIT_CATEGORIA;
                tbox_Desc_Categoria.Text = aobj_Categoria.DESC_CATEGORIA;
            }
        }


        /**********************************************************************************
        * NOME:            PopulaObjeto
        * PROCEDIMENTO:    Preenche o objeto com os dados da  tela 
        * DT CRIAÇÃO:      02/12/2019
        * DT ALTERAÇÃO:    -
        * PARAMETRO:       
        * ESCRITA POR:     Mfacine (Monstro)
        * OBSERVAÇÕES:     
        * ********************************************************************************/
        private Categoria PopulaObjeto()
        {
            Categoria aobj_Categoria = new Categoria();

            if (tbox_Cod_Categoria.Text != "")
            {
                aobj_Categoria.COD_CATEGORIA = Convert.ToInt16(tbox_Cod_Categoria.Text);
            }
            aobj_Categoria.TIT_CATEGORIA = tbox_Tit_Categoria.Text;
            aobj_Categoria.DESC_CATEGORIA = tbox_Desc_Categoria.Text;

            return aobj_Categoria;
        }


        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            CategoriaBD obj_CategoriaBD = new CategoriaBD();

            Categoria_Principal = PopulaObjeto();

            if (Categoria_Principal.COD_CATEGORIA != -1)
            {
                obj_CategoriaBD.Alterar(Categoria_Principal);
                MessageBox.Show("Categoria alterada com sucesso. ", "Alteração da Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Categoria_Principal.COD_CATEGORIA = obj_CategoriaBD.Incluir(Categoria_Principal);
                MessageBox.Show("Categoria Incluida com sucesso. ", "Inclusão da Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulaTela(Categoria_Principal);
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
            tbox_Tit_Categoria.Focus();

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, false);

            if (Categoria_Principal.COD_CATEGORIA != -1)
            {
                PopulaTela(Categoria_Principal);
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
            tbox_Tit_Categoria.Focus();

        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            CategoriaBD obj_CategoriaBD = new CategoriaBD();
            DialogResult varResp = MessageBox.Show("Confirma a Exclusão?", "Exclusão da Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (varResp == DialogResult.Yes)
            {
                if (obj_CategoriaBD.Excluir(Categoria_Principal))
                {
                    MessageBox.Show("Categoria excluida com sucesso. ", "Exclusão da Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 1);
                PopulaLista();


            }

        }

    }
}
