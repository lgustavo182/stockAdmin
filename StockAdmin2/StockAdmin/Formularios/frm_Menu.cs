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
    public partial class frm_Menu : Form
    {
        public frm_Menu()
        {
            InitializeComponent();
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
        
        
        private void btn_Usuario_Click(object sender, EventArgs e)
        {
            frm_Usuario obj_frm_Usuario = new frm_Usuario();
            obj_frm_Usuario.ShowDialog();
        }

        
        private void btn_Movimentacao_Click(object sender, EventArgs e)
        {
            frm_Movimentacao obj_frm_Movimentacao = new frm_Movimentacao();
            obj_frm_Movimentacao.ShowDialog();
        }
        
        
        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

 
    }
}
