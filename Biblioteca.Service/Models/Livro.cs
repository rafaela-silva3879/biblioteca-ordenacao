using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.Models
{

    /// <summary>
    /// Representa um livro da biblioteca.
    /// </summary>
    public class Livro
    {
        /// <summary>
        /// Título do livro.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Autor do livro.
        /// </summary>
        public string Autor { get; set; }

        /// <summary>
        /// Edição do livro.
        /// </summary>
        public int Edicao { get; set; }

    }

}
