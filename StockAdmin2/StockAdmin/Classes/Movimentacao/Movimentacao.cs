using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_UC10
{
    class Movimentacao
    {
        //(Gabriel Prado - 12/02/2020) Metodo de Destruição da Classe
        ~Movimentacao()
        {
        }

        //(Gabriel Prado - 12/02/2020) Atributos/Propriedades Privadas Encapsuladas
        int VCOD_MOVIMENTACAO = -1;
        int VQTD_PRODUTO = -1;
        string VTIT_CATEGORIA = null;
        string VNM_PRODUTO = null;
        int VCOD_PRODUTO = -1;
        string VOBS_MOVIMENTACAO = null;
        DateTime VDATA_MOVIMENTACAO = DateTime.MinValue;


        //(Gabriel Prado - 12/02/2020) Metodos Públicos

        /***********************************************************************
        * NOME:            COD_MOVIMENTACAO   
        * METODO:          Representação do atributo Código do Produto com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/


        public int COD_MOVIMENTACAO
        {
            get { return VCOD_MOVIMENTACAO; }
            set { VCOD_MOVIMENTACAO = value; }
        }

        //(Gabriel Prado - 12/02/2020) Metodos Públicos

        /***********************************************************************
        * NOME:            QTD_PRODUTO     
        * METODO:          Representação do atributo Quantidade do Produto com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/


        public int QTD_PRODUTO
        {
            get { return VQTD_PRODUTO; }
            set { VQTD_PRODUTO = value; }
        }


        /***********************************************************************
       * NOME:            TIT_CATEGORIA     
       * METODO:          Representação do atributo do Titulo da Categoria com os métodos 
       *                  Get e Set          
       * DT CRIAÇÃO:      12/02/2020    
       * DT ALTERAÇÃO:    -
       * ESCRITA POR:     Gabriel Prado
       **********************************************************************/
        public string TIT_CATEGORIA
        {
            get { return VTIT_CATEGORIA; }
            set { VTIT_CATEGORIA = value; }
        }

        /***********************************************************************
     * NOME:            NM_PRODUTO    
     * METODO:          Representação do atributo do Titulo da Categoria com os métodos 
     *                  Get e Set          
     * DT CRIAÇÃO:      14/02/2020    
     * DT ALTERAÇÃO:    -
     * ESCRITA POR:     Victor Henrique 
     **********************************************************************/
        public string NM_PRODUTO
        {
            get { return VNM_PRODUTO; }
            set { VNM_PRODUTO = value; }
        }


        /***********************************************************************
     * NOME:            MP_PRODUTO    
     * METODO:          Representação do atributo do Titulo da Categoria com os métodos 
     *                  Get e Set          
     * DT CRIAÇÃO:      14/02/2020    
     * DT ALTERAÇÃO:    -
     * ESCRITA POR:     Victor Henrique 
     **********************************************************************/
        public int COD_PRODUTO
        {
            get { return VCOD_PRODUTO; }
            set { VCOD_PRODUTO = value; }
        }

        /***********************************************************************
 * NOME:            DATA_MOVIMENTACAO  
 * METODO:          Representação do atributo do Titulo da Categoria com os métodos 
 *                  Get e Set          
 * DT CRIAÇÃO:      14/02/2020    
 * DT ALTERAÇÃO:    -
 * ESCRITA POR:     Victor Henrique 
 **********************************************************************/
        public DateTime DATA_MOVIMENTACAO
        {
            get { return VDATA_MOVIMENTACAO; }
            set { VDATA_MOVIMENTACAO = value; }

        }
        /***********************************************************************
       * NOME:            OBS_MOVIMENTACAO     
       * METODO:          Representação do atributo de Observação da Movimentação 
       *                  Get e Set          
       * DT CRIAÇÃO:      12/02/2020    
       * DT ALTERAÇÃO:    -
       * ESCRITA POR:     Gabriel Prado
       **********************************************************************/

        public string OBS_MOVIMENTACAO
        {
            get { return VOBS_MOVIMENTACAO; }
            set { VOBS_MOVIMENTACAO = value; }
        }
    }
    
}
