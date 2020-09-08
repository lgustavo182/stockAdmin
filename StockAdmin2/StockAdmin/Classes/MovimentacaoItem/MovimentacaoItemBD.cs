/*****************************************************************************
* Nome           : MovimentacaoItemBD
* Classe         : Representação da classe que se conecta com o banco através 
*                  da entidade MovimentacaoItem
* Data  Criação  : 18/11/2019
* Data Alteração : -
* Escrito por    : Luis Gustavo de Almeida Monteiro
* Observações    : 
* ***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Dynamic;



namespace PROJETO_UC10
{ 
    class MovimentacaoItemBD
    {
        //18/11/2019 - Luis Gustavo de Almeida Monteiro - ToDo: criar uma classe de funções gerais (FuncGeral)

        /*****************************************************************************
        * Nome           : Incluir
        * Procedimento   : Responsável por incluir o Objeto na Base de Dados
        *                  Método para inclui um registro na tabela MovimentacaoItem
        * Parametros     : Objeto da Classe MovimentacaoItem
        * Data  Criação  : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Luis Gustavo de Almeida Monteiro
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public int Incluir(MovimentacaoItem aobj_MovimentacaoItem)
        {
            //18/11/2019 - Luis Gustavo de Almeida Monteiro - Criar objeto de conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //18/11/2019 - Luis Gustavo de Almeida Monteiro - Criar a variável que contém a instrução SQL
            string varSql = "INSERT INTO TB_MOVIMENTACAOITEM " +
                            "(" +
                            " I_COD_MOVIMENTACAO,   " +
                            " I_COD_PRODUTO,  " +
                            " D_VL_MOVIMENTACAOITEM  " +
                            ")" +
                            "VALUES " +
                            "(" +
                            " @I_COD_MOVIMENTACAO,   " +
                            " @I_COD_PRODUTO,  " +
                            " @D_VL_MOVIMENTACAOITEM  " +
                            "); " +
                            "SELECT ident_current('TB_MOVIMENTACAOITEM') as 'id'";

            //18/11/2019 - Luis Gustavo de Almeida Monteiro - Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_MOVIMENTACAOITEM", aobj_MovimentacaoItem.COD_MOVIMENTACAOITEM);
            objCmd.Parameters.AddWithValue("@I_COD_PRODUTO ", aobj_MovimentacaoItem.COD_PRODUTO);
            objCmd.Parameters.AddWithValue("@D_VL_MOVIMENTACAOITEM", aobj_MovimentacaoItem.VL_MOVIMENTACAOITEM);

            try
            {
                //18/11/2019 - Luis Gustavo de Almeida Monteiro - Abrir a conexão com o banco de dados
                objCon.Open();

                //18/11/2019 - Luis Gustavo de Almeida Monteiro - Executar o comando Escalar
                int _id = Convert.ToInt16(objCmd.ExecuteScalar());

                //(18/11/2019-Luis Gustavo de Almeida Monteiro) fechar a conexão
                objCon.Close();

                return _id;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        /*****************************************************************************
        * Nome           : Alterar
        * Procedimento   : Responsável por editar o Objeto na Base de Dados
        *                  Método para Alteração de um registro na tabela MovimentacaoItem
        * Parametros     : Objeto da Classe MovimentacaoItem
        * Data  Criação  : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Luis Gustavo de Almeida Monteiro
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Alterar(MovimentacaoItem aobj_MovimentacaoItem)
        {


            if (aobj_MovimentacaoItem.COD_MOVIMENTACAOITEM != -1)
            {
                //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar objeto de conexão com o banco de dados
                SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

                //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar a variável que contém a instrução SQL
                string varSql = " UPDATE TB SET TB_MOVIMENTACAOITEM" +
                                " I_COD_MOVIMENTACAO     = @I_COD_MOVIMENTACAO,    " +
                                " I_COD_PRODUTO   = @I_COD_PRODUTO,  " +
                                " D_VL_MOVIMENTACAOITEM = @D_VL_MOVIMENTACAOITEM " +
                                " WHERE I_COD_MOVIMENTACAOITEM = @I_COD_MOVIMENTACAOITEM";

                //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar objeto para executar o comando
                SqlCommand objCmd = new SqlCommand(varSql, objCon);
                objCmd.Parameters.AddWithValue("@I_COD_MOVIMENTACAO", aobj_MovimentacaoItem.COD_MOVIMENTACAO);
                objCmd.Parameters.AddWithValue("@I_COD_PRODUTO", aobj_MovimentacaoItem.COD_PRODUTO);
                objCmd.Parameters.AddWithValue("@D_VL_MOVIMENTACAOITEM", aobj_MovimentacaoItem.TIT_CATEGORIA);

                try
                {
                    //(18/11/2019-Luis Gustavo de Almeida Monteiro) Abrir a conexão com o banco de dados
                    objCon.Open();

                    //(18/11/2019-Luis Gustavo de Almeida Monteiro) Executar o comando
                    objCmd.ExecuteNonQuery();

                    //(18/11/2019-Luis Gustavo de Almeida Monteiro) fechar a conexão
                    objCon.Close();

                    return true;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


        /*****************************************************************************
        * Nome           : Excluir
        * Procedimento   : Responsável por Apagar o Objeto na Base de Dados
        *                  Método para deletar um registro na tabela Receita
        * Parametros     : Objeto da Classe MovimentacaoItem
        * Data  Criação  : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Luis Gustavo de Almeida Monteiro
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Excluir(MovimentacaoItem aobj_MovimentacaoItem)
        {
            //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar objeto para conexão com o banco de dados
            SqlConnection ObjCon = new SqlConnection(Connection.ConnectionPath());

            //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar uma váriavel que contém a instrução SQL
            string varSql = " DELETE FROM TB_MOVIMENTACAOITEM " +
                            " WHERE I_COD_MOVIMENTACAOITEM = @I_COD_MOVIMENTACAOITEM";

            //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, ObjCon);
            objCmd.Parameters.AddWithValue("@I_COD_MOVIMENTACAOITEM", aobj_MovimentacaoItem.COD_MOVIMENTACAOITEM);

            try
            {
                //(18/11/2019-Luis Gustavo de Almeida Monteiro) Abrir a conexão com o banco de dados
                ObjCon.Open();

                //(18/11/2019-Luis Gustavo de Almeida Monteiro) Executar o comando para excluir o registro
                objCmd.ExecuteNonQuery();

                //(18/11/2019-Luis Gustavo de Almeida Monteiro) Fechar a conexão com o banco de dados
                ObjCon.Close();

                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /*****************************************************************************
        * Nome           : FindByCodMovimentacaoItem
        * Procedimento   : Responsável por encontrar o Objeto na Base de Dados
        *                  Método para Buscar um registro na tabela TB_MOVIMENTACAOITEM
        * Parametros     : Objeto da Classe MovimentacaoItem
        * Data  Criação  : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Luis Gustavo de Almeida Monteiro
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public MovimentacaoItem FindByCodMovimentacaoItem(MovimentacaoItem aobj_MovimentacaoItem)
        {
            //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar objeto para conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar uma váriavel que contém a instrução SQL
            string varSql = " SELECT * FROM TB_MOVIMENTACAOITEM " +
                            " WHERE I_COD_MOVIMENTACAOITEM = @I_COD_MOVIMENTACAOITEM ";

            //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            objCmd.Parameters.AddWithValue("@I_COD_MOVIMENTACAOITEM", aobj_MovimentacaoItem.COD_MOVIMENTACAOITEM);

            try
            {
                //(18/11/2019-Luis Gustavo de Almeida Monteiro) Abrir a conexão com o banco de dados
                objCon.Open();

                //(18/11/2019-Luis Gustavo de Almeida Monteiro) Criar um objeto DataReader que irá receber os dados
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    //Ler os dados que estão no objeto DataReader 
                    objDtr.Read();

                    //(18/11/2019-Luis Gustavo de Almeida Monteiro) Recupero os valores (Tipo um Popula Objeto)

                    aobj_MovimentacaoItem.COD_MOVIMENTACAOITEM = Convert.ToInt16(objDtr["@I_COD_MOVIMENTACAOITEM"]);
                    aobj_MovimentacaoItem.COD_MOVIMENTACAO   = Convert.ToInt16(objDtr["@I_COD_MOVIMENTACAO"]);
                    aobj_MovimentacaoItem.COD_PRODUTO = Convert.ToInt16(objDtr["@I_COD_PRODUTO"]);
                    aobj_MovimentacaoItem.VL_MOVIMENTACAOITEM = Convert.ToDouble(objDtr["@D_VL_MOVIMENTACAOITEM"]);

                }

                objCon.Close();
                objDtr.Close();
                return aobj_MovimentacaoItem;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return aobj_MovimentacaoItem;
            }
        }


        /****************************************************************************
        * Nome           : FindAllMovimentacaoItem
        * Procedimento   : Responsável por encontrar todos os Objetos na Base de Dados
        *                   Método para Buscar uma lista de registros 
        * Parametros     : Objeto da Classe MovimentacaoItem
        * Data Criação   : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Luis Gustavo de Almeida Monteiro(Monstro)
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public List<MovimentacaoItem> FindAllMovimentacaoItem()
        {
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());
            string varSql = " SELECT * FROM TB_MOVIMENTACAOITEM ";
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<MovimentacaoItem> aLista = new List<MovimentacaoItem>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        MovimentacaoItem aobj_MovimentacaoItem = new MovimentacaoItem();

                        aobj_MovimentacaoItem.COD_MOVIMENTACAOITEM = Convert.ToInt16(objDtr["@I_COD_MOVIMENTACAOITEM"]);
                        aobj_MovimentacaoItem.COD_MOVIMENTACAO = Convert.ToInt16(objDtr["@I_COD_MOVIMENTACAO"]);
                        aobj_MovimentacaoItem.COD_PRODUTO = Convert.ToInt16(objDtr["@I_COD_PRODUTO"]);
                        aobj_MovimentacaoItem.VL_MOVIMENTACAOITEM = Convert.ToDouble(objDtr["@D_VL_MOVIMENTACAOITEM"]);

                        aLista.Add(aobj_MovimentacaoItem);

                    }

                    objCon.Close();
                    objDtr.Close();
                    return aLista;

                }
                else
                {
                    objCon.Close();
                    objDtr.Close();
                    return null;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
