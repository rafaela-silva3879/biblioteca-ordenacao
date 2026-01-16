using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.Configuration
{
    /// <summary>
    /// Guarda as regras de ordenação dos livros.
    /// </summary>
    public class OrdenacaoConfig
    {
        /// <summary>
        /// Cada item da lista representa uma regra de ordenação.
        /// O primeiro item é aplicado primeiro.
        /// </summary>
        public List<CriterioOrdenacao> Criterios { get; set; } = new();
    }
}


