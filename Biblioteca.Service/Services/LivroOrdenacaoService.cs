using Biblioteca.Service.Configuration;
using Biblioteca.Service.Models;
using Biblioteca.Service.Services.Interfaces;

namespace Biblioteca.Service.Services
{
    /// <summary>
    /// Serviço responsável por ordenar livros conforme critérios configurados.
    /// </summary>
    public class LivroOrdenacaoService : ILivroOrdenacaoService
    {
        private readonly OrdenacaoConfig _config;

        /// <summary>
        /// Inicializa o serviço com as configurações de ordenação.
        /// </summary>
        public LivroOrdenacaoService(OrdenacaoConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Ordena a lista de livros conforme os critérios definidos.
        /// </summary>
        public List<Livro> Ordenar(List<Livro> livros)
        {
            if (livros == null)
                throw new Exception("Conjunto de livros não pode ser nulo.");

            if (livros.Count == 0)
                return livros;

            IOrderedEnumerable<Livro>? ordenado = null;

            foreach (var criterio in _config.Criterios)
            {
                if (criterio.Propriedade == "Titulo")
                {
                    ordenado = AplicarOrdenacao(
                        ordenado,
                        livros,
                        l => l.Titulo,
                        criterio.Direcao);
                }

                if (criterio.Propriedade == "Autor")
                {
                    ordenado = AplicarOrdenacao(
                        ordenado,
                        livros,
                        l => l.Autor,
                        criterio.Direcao);
                }

                if (criterio.Propriedade == "Edicao")
                {
                    ordenado = AplicarOrdenacao(
                        ordenado,
                        livros,
                        l => l.Edicao,
                        criterio.Direcao);
                }
            }

            return ordenado?.ToList() ?? livros;
        }

        /// <summary>
        /// Aplica ordenação simples usando LINQ padrão.
        /// </summary>
        private static IOrderedEnumerable<Livro> AplicarOrdenacao<TKey>(
            IOrderedEnumerable<Livro>? ordenado,
            List<Livro> livros,
            Func<Livro, TKey> chave,
            DirecaoOrdenacao direcao)
        {
            if (ordenado == null)
            {
                return direcao == DirecaoOrdenacao.Ascendente
                    ? livros.OrderBy(chave)
                    : livros.OrderByDescending(chave);
            }

            return direcao == DirecaoOrdenacao.Ascendente
                ? ordenado.ThenBy(chave)
                : ordenado.ThenByDescending(chave);
        }
    }
}
