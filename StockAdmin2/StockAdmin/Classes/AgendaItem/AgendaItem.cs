/**********************************************************************************
 * NOME:            AgendaItem
 * CLASSE:          Representação da entidade AgendaItem 
 * DT CRIAÇÃO:      04/11/2019
 * DT ALTERAÇÃO:    -
 * ESCRITA POR:     Mfacine (Monstro)
 * OBSERVAÇÕES:     Atributos privados com métodos Get e Set públicos
 * ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTatoo
{
    class AgendaItem
    {
        //(Mfacine - 01/11/2019) Metodo de Destruição da Classe
        ~AgendaItem()
        {
        }

        //(Mfacine - 01/11/2019) Atributos/Propriedades Privadas Encapsuladas
        int VCOD_AGENDAITEM = -1;
        int VCOD_AGENDA = -1;
        int VCOD_PRODUTO = -1;
        string VLOC_AGENDAITEM = null;

        //(Mfacine - 01/11/2019) Metodos Públicos

        /***********************************************************************
        * NOME:            COD_AGENDAITEM     
        * METODO:          Representação do atributo Código AgendaItem com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      04/11/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Mfacine
        **********************************************************************/
        public int COD_AGENDAITEM
        {
            get { return VCOD_AGENDAITEM; }
            set { VCOD_AGENDAITEM = value; }
        }

        /***********************************************************************
        * NOME:            COD_TATUADOR     
        * METODO:          Representação do atributo código do tatuador com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      04/11/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Mfacine
        **********************************************************************/
        public int COD_AGENDA
        {
            get { return VCOD_AGENDA; }
            set { VCOD_AGENDA = value; }
        }


        /***********************************************************************
        * NOME:            COD_PRODUTO     
        * METODO:          Representação do atributo Código Agenda com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      04/11/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Mfacine
        **********************************************************************/
        public int COD_PRODUTO
        {
            get { return VCOD_PRODUTO; }
            set { VCOD_PRODUTO = value; }
        }


        

        /***********************************************************************
        * NOME:            LOC_AGENDAITEM     
        * METODO:          Representação do atributo Observação AgendaItem com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      04/11/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Mfacine
        **********************************************************************/
        public string LOC_AGENDAITEM
        {
            get { return VLOC_AGENDAITEM; }
            set { VLOC_AGENDAITEM = value; }
        }
    }
}
