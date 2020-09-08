/**********************************************************************************
 * NOME:            MovimentacaoItem
 * CLASSE:          Representação da entidade MovimentacaoItem 
 * DT CRIAÇÃO:      04/11/2019
 * DT ALTERAÇÃO:    -
 * ESCRITA POR:     Luis Gustavo de Almeida Monteiro (Monstro)
 * OBSERVAÇÕES:     Atributos privados com métodos Get e Set públicos
 * ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_UC10
{
    class MovimentacaoItem
    {
        //(Luis Gustavo de Almeida Monteiro - 01/11/2019) Metodo de Destruição da Classe
        ~MovimentacaoItem()
        {
        }

        //(Luis Gustavo de Almeida Monteiro - 01/11/2019) Atributos/Propriedades Privadas Encapsuladas
        int VCOD_MOVIMENTACAOITEM = -1;
        int VCOD_MOVIMENTACAO = -1;
        int VCOD_PRODUTO = -1;
        int VCOD_CATEGORIA = -1; 
        double VVL_MOVIMENTACAOITEM = -1;     
        string VTIT_CATEGORIA = null;
    

        //(Luis Gustavo de Almeida Monteiro - 01/11/2019) Metodos Públicos

        /***********************************************************************
        * NOME:            COD_MOVIMENTACAOITEM     
        * METODO:          Representação do atributo Código MovimentacaoItem com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      04/11/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        **********************************************************************/
        public int COD_MOVIMENTACAOITEM
        {
            get { return VCOD_MOVIMENTACAOITEM; }
            set { VCOD_MOVIMENTACAOITEM = value; }
        }

        /***********************************************************************
        * NOME:            COD_MOVIMENTACAO   
        * METODO:          Representação do atributo código da Movimentação com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      04/11/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        **********************************************************************/
        public int COD_MOVIMENTACAO
        {
            get { return VCOD_MOVIMENTACAO; }
            set { VCOD_MOVIMENTACAO = value; }
        }


        /***********************************************************************
        * NOME:            COD_PRODUTO     
        * METODO:          Representação do atributo Código Produto com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      04/11/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        **********************************************************************/
        public int COD_PRODUTO
        {
            get { return VCOD_PRODUTO; }
            set { VCOD_PRODUTO = value; }
        }

        /***********************************************************************
       * NOME:            COD_CATEGORIA    
       * METODO:          Representação do atributo Código Categoria com os métodos 
       *                  Get e Set          
       * DT CRIAÇÃO:      04/11/2019    
       * DT ALTERAÇÃO:    -
       * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
       **********************************************************************/
        public int COD_CATEGORIA
        {
            get { return VCOD_CATEGORIA; }
            set { VCOD_CATEGORIA = value; }
        }
        /***********************************************************************
      * NOME:            TIT_CATEGORIA     
      * METODO:          Representação do atributo Título Categoria com os métodos 
      *                  Get e Set          
      * DT CRIAÇÃO:      04/11/2019    
      * DT ALTERAÇÃO:    -
      * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
      **********************************************************************/
        public string TIT_CATEGORIA
        {
            get { return VTIT_CATEGORIA; }
            set { VTIT_CATEGORIA = value; }
        }


        /***********************************************************************
        * NOME:            VLV_MOVIMENTACAOITEM     
        * METODO:          Representação do atributo Valor de Venda com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      04/11/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
        **********************************************************************/
        public double VL_MOVIMENTACAOITEM
        {
            get { return VVL_MOVIMENTACAOITEM; }
            set { VVL_MOVIMENTACAOITEM = value; }
        }

        /***********************************************************************
      * NOME:            VLC_MOVIMENTACAOITEM     
      * METODO:          Representação do atributo Valor de Compra com os métodos 
      *                  Get e Set          
      * DT CRIAÇÃO:      04/11/2019    
      * DT ALTERAÇÃO:    -
      * ESCRITA POR:     Luis Gustavo de Almeida Monteiro
      **********************************************************************/
        public double VLC_PRODUTO
        {
            get { return VLC_PRODUTO; }
            set { VLC_PRODUTO = value; }
        }
    }
}
