using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.Configuration
{
    /// <summary>
    /// Define um critério de ordenação.
    /// </summary>
    public class CriterioOrdenacao
    {
        /// <summary>
        /// Nome da propriedade do livro a ser ordenada.
        /// </summary>
        public string Propriedade { get; set; }

        /// <summary>
        /// Direção da ordenação (Ascendente ou Descendente).
        /// </summary>
        public DirecaoOrdenacao Direcao { get; set; }
    }
}

