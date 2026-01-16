using Biblioteca.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.Services.Interfaces
{
    /// <summary>
    /// Define o serviço responsável por ordenar livros.
    /// </summary>
    public interface ILivroOrdenacaoService
    {
        /// <summary>
        /// Ordena uma lista de livros de acordo com critérios configurados.
        /// </summary>
        /// <param name="livros">Lista de livros a ser ordenada.</param>
        /// <returns>Lista de livros ordenada.</returns>
        List<Livro> Ordenar(List<Livro> livros);
    }
}

