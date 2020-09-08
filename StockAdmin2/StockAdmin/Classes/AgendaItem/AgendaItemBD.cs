/*****************************************************************************
* Nome           : AgendaItemBD
* Classe         : Representação da classe que se conecta com o banco através 
*                  da entidade AgendaItem
* Data  Criação  : 18/11/2019
* Data Alteração : -
* Escrito por    : Mfacine (Monstro)
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

namespace AppTatoo
{
    class AgendaItemBD
    {
        //18/11/2019 - Mfacine - ToDo: criar uma classe de funções gerais (FuncGeral)

        /*****************************************************************************
        * Nome           : Incluir
        * Procedimento   : Responsável por incluir o Objeto na Base de Dados
        *                  Método para inclui um registro na tabela AgendaItem
        * Parametros     : Objeto da Classe AgendaItem
        * Data  Criação  : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Mfacine (Monstro)
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public int Incluir(AgendaItem aobj_AgendaItem)
        {
            //18/11/2019 - Mfacine - Criar objeto de conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //18/11/2019 - Mfacine - Criar a variável que contém a instrução SQL
            string varSql = "INSERT INTO TB_AGENDAITEM " +
                            "(" +
                            " I_COD_AGENDA,   " +
                            " I_COD_TATUAGEM,  " +
                            " S_LOC_AGENDAITEM  " +
                            ")" +
                            "VALUES " +
                            "(" +
                            " @I_COD_AGENDA,   " +
                            " @I_COD_TATUAGEM,  " +
                            " @S_LOC_AGENDAITEM  " +
                            "); " +
                            "SELECT ident_current('TB_AGENDAITEM') as 'id'";

            //18/11/2019 - mfacine - Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_AGENDA", aobj_AgendaItem.COD_AGENDA);
            objCmd.Parameters.AddWithValue("@I_COD_TATUAGEM ", aobj_AgendaItem.COD_TATUAGEM);
            objCmd.Parameters.AddWithValue("@S_LOC_AGENDAITEM", aobj_AgendaItem.LOC_AGENDAITEM);

            try
            {
                //18/11/2019 - mfacine - Abrir a conexão com o banco de dados
                objCon.Open();

                //18/11/2019 - mfacine - Executar o comando Escalar
                int _id = Convert.ToInt16(objCmd.ExecuteScalar());

                //(18/11/2019-mfacine) fechar a conexão
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
        *                  Método para Alteração de um registro na tabela AgendaItem
        * Parametros     : Objeto da Classe AgendaItem
        * Data  Criação  : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Mfacine (Monstro)
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Alterar(AgendaItem aobj_AgendaItem)
        {


            if (aobj_AgendaItem.COD_AGENDAITEM != -1)
            {
                //(18/11/2019-mfacine) Criar objeto de conexão com o banco de dados
                SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

                //(18/11/2019-mfacine) Criar a variável que contém a instrução SQL
                string varSql = " UPDATE TB SET TB_AGENDAITEM" +
                                " I_COD_AGENDA     = @I_COD_AGENDA,    " +
                                " I_COD_TATUAGEM   = @I_COD_TATUAGEM,  " +
                                " S_LOC_AGENDAITEM = @S_LOC_AGENDAITEM " +
                                " WHERE I_COD_AGENDAITEM = @I_COD_AGENDAITEM";

                //(18/11/2019-mfacine) Criar objeto para executar o comando
                SqlCommand objCmd = new SqlCommand(varSql, objCon);
                objCmd.Parameters.AddWithValue("@I_COD_AGENDA", aobj_AgendaItem.COD_AGENDA);
                objCmd.Parameters.AddWithValue("@I_COD_TATUAGEM", aobj_AgendaItem.COD_TATUAGEM);
                objCmd.Parameters.AddWithValue("@S_LOC_AGENDAITEM", aobj_AgendaItem.LOC_AGENDAITEM);

                try
                {
                    //(18/11/2019-mfacine) Abrir a conexão com o banco de dados
                    objCon.Open();

                    //(18/11/2019-mfacine) Executar o comando
                    objCmd.ExecuteNonQuery();

                    //(18/11/2019-mfacine) fechar a conexão
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
        * Parametros     : Objeto da Classe AgendaItem
        * Data  Criação  : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Mfacine (Monstro)
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Excluir(AgendaItem aobj_AgendaItem)
        {
            //(18/11/2019-mfacine) Criar objeto para conexão com o banco de dados
            SqlConnection ObjCon = new SqlConnection(Connection.ConnectionPath());

            //(18/11/2019-mfacine) Criar uma váriavel que contém a instrução SQL
            string varSql = " DELETE FROM TB_AGENDAITEM " +
                            " WHERE I_COD_AGENDAITEM = @I_COD_AGENDAITEM";

            //(18/11/2019-mfacine) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, ObjCon);
            objCmd.Parameters.AddWithValue("@I_COD_AGENDAITEM", aobj_AgendaItem.COD_AGENDAITEM);

            try
            {
                //(18/11/2019-mfacine) Abrir a conexão com o banco de dados
                ObjCon.Open();

                //(18/11/2019-mfacine) Executar o comando para excluir o registro
                objCmd.ExecuteNonQuery();

                //(18/11/2019-mfacine) Fechar a conexão com o banco de dados
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
        * Nome           : FindByCodAgendaItem
        * Procedimento   : Responsável por encontrar o Objeto na Base de Dados
        *                  Método para Buscar um registro na tabela TB_AGENDAITEM
        * Parametros     : Objeto da Classe AgendaItem
        * Data  Criação  : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Mfacine (Monstro)
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public AgendaItem FindByCodAgendaItem(AgendaItem aobj_AgendaItem)
        {
            //(18/11/2019-Mfacine) Criar objeto para conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //(18/11/2019-Mfacine) Criar uma váriavel que contém a instrução SQL
            string varSql = " SELECT * FROM TB_AGENDAITEM " +
                            " WHERE I_COD_AGENDAITEM = @I_COD_AGENDAITEM ";

            //(18/11/2019-Mfacine) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            objCmd.Parameters.AddWithValue("@I_COD_AGENDAITEM", aobj_AgendaItem.COD_AGENDAITEM);

            try
            {
                //(18/11/2019-Mfacine) Abrir a conexão com o banco de dados
                objCon.Open();

                //(18/11/2019-Mfacine) Criar um objeto DataReader que irá receber os dados
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    //Ler os dados que estão no objeto DataReader 
                    objDtr.Read();

                    //(18/11/2019-mfacine) Recupero os valores (Tipo um Popula Objeto)

                    aobj_AgendaItem.COD_AGENDAITEM = Convert.ToInt16(objDtr["@I_COD_AGENDAITEM"]);
                    aobj_AgendaItem.COD_TATUAGEM   = Convert.ToInt16(objDtr["@S_TIT_AGENDAITEM"]);
                    aobj_AgendaItem.COD_AGENDAITEM = Convert.ToInt16(objDtr["@T_DESC_AGENDAITEM"]);
                    aobj_AgendaItem.LOC_AGENDAITEM = objDtr["@T_DESC_AGENDAITEM"].ToString();

                }

                objCon.Close();
                objDtr.Close();
                return aobj_AgendaItem;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return aobj_AgendaItem;
            }
        }


        /****************************************************************************
        * Nome           : FindAllAgendaItem
        * Procedimento   : Responsável por encontrar todos os Objetos na Base de Dados
        *                   Método para Buscar uma lista de registros 
        * Parametros     : Objeto da Classe AgendaItem
        * Data Criação   : 18/11/2019
        * Data Alteração : -
        * Escrito por    : Mfacine(Monstro)
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public List<AgendaItem> FindAllAgendaItem()
        {
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());
            string varSql = " SELECT * FROM TB_AGENDAITEM ";
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<AgendaItem> aLista = new List<AgendaItem>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        AgendaItem aobj_AgendaItem = new AgendaItem();

                        aobj_AgendaItem.COD_AGENDAITEM = Convert.ToInt16(objDtr["@I_COD_AGENDAITEM"]);
                        aobj_AgendaItem.COD_TATUAGEM = Convert.ToInt16(objDtr["@S_TIT_AGENDAITEM"]);
                        aobj_AgendaItem.COD_AGENDAITEM = Convert.ToInt16(objDtr["@T_DESC_AGENDAITEM"]);
                        aobj_AgendaItem.LOC_AGENDAITEM = objDtr["@T_DESC_AGENDAITEM"].ToString();

                        aLista.Add(aobj_AgendaItem);

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
