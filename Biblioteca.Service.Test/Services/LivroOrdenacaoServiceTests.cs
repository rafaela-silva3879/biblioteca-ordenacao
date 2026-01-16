using Biblioteca.Service.Configuration;
using Biblioteca.Service.Models;
using Biblioteca.Service.Services;
using Xunit;

namespace Biblioteca.Service.Test.Services
{
    public class LivroOrdenacaoServiceTests
    {
        private List<Livro> CriarLivros()
        {
            return new List<Livro>
    {
        new Livro
        {
            Titulo = "Java How to Program",
            Autor = "Deitel & Deitel",
            Edicao = 2007
        },
        new Livro
        {
            Titulo = "Patterns of Enterprise Application Architecture",
            Autor = "Martin Fowler",
            Edicao = 2002
        },
        new Livro
        {
            Titulo = "Head First Design Patterns",
            Autor = "Elisabeth Freeman",
            Edicao = 2004
        },
        new Livro
        {
            Titulo = "Internet & World Wide Web: How to Program",
            Autor = "Deitel & Deitel",
            Edicao = 2007
        }
    };
        }


        [Fact]
        public void Deve_Ordenar_Por_Titulo_Ascendente_E_Autor_Ascendente()
        {
            var config = new OrdenacaoConfig
            {
                Criterios = new List<CriterioOrdenacao>
                {
                    new CriterioOrdenacao
                    {
                        Propriedade = "Titulo",
                        Direcao = DirecaoOrdenacao.Ascendente
                    },
                    new CriterioOrdenacao
                    {
                        Propriedade = "Autor",
                        Direcao = DirecaoOrdenacao.Ascendente
                    }
                }
            };

            var service = new LivroOrdenacaoService(config);
            var livros = CriarLivros();

            var resultado = service.Ordenar(livros);

            Assert.Equal("Head First Design Patterns", resultado[0].Titulo); // Livro 3
            Assert.Equal("Internet & World Wide Web: How to Program", resultado[1].Titulo); // Livro 4
            Assert.Equal("Java How to Program", resultado[2].Titulo); // Livro 1
            Assert.Equal("Patterns of Enterprise Application Architecture", resultado[3].Titulo); // Livro 2
        }

        [Fact]
        public void Deve_Ordenar_Por_Titulo_Descendente_E_Autor_Ascendente()
        {
            var config = new OrdenacaoConfig
            {
                Criterios = new List<CriterioOrdenacao>
        {
            new CriterioOrdenacao
            {
                Propriedade = "Autor",
                Direcao = DirecaoOrdenacao.Ascendente
            },
            new CriterioOrdenacao
            {
                Propriedade = "Titulo",
                Direcao = DirecaoOrdenacao.Descendente
            }
        }
            };

            var service = new LivroOrdenacaoService(config);
            var livros = CriarLivros();

            var resultado = service.Ordenar(livros);

            Assert.Equal("Java How to Program", resultado[0].Titulo); // Livro 1
            Assert.Equal("Internet & World Wide Web: How to Program", resultado[1].Titulo); // Livro 4
            Assert.Equal("Head First Design Patterns", resultado[2].Titulo); // Livro 3
            Assert.Equal("Patterns of Enterprise Application Architecture", resultado[3].Titulo); // Livro 2
        }

        [Fact]
        public void Deve_Ordenar_Por_Edicao_Descendente_Autor_Descendente_Titulo_Ascendente()
        {
            var config = new OrdenacaoConfig
            {
                Criterios = new List<CriterioOrdenacao>
                {
                    new CriterioOrdenacao
                    {
                        Propriedade = "Edicao",
                        Direcao = DirecaoOrdenacao.Descendente
                    },
                    new CriterioOrdenacao
                    {
                        Propriedade = "Autor",
                        Direcao = DirecaoOrdenacao.Descendente
                    },
                    new CriterioOrdenacao
                    {
                        Propriedade = "Titulo",
                        Direcao = DirecaoOrdenacao.Ascendente
                    }
                }
            };

            var service = new LivroOrdenacaoService(config);
            var livros = CriarLivros();

            var resultado = service.Ordenar(livros);

            Assert.Equal("Internet & World Wide Web: How to Program", resultado[0].Titulo); // Livro 4
            Assert.Equal("Java How to Program", resultado[1].Titulo); // Livro 1
            Assert.Equal("Head First Design Patterns", resultado[2].Titulo); // Livro 3
            Assert.Equal("Patterns of Enterprise Application Architecture", resultado[3].Titulo); // Livro 2
        }
        [Fact]
        public void Deve_Lancar_Exception_Quando_Lista_For_Nula()
        {
            var config = new OrdenacaoConfig();
            var service = new LivroOrdenacaoService(config);

            Assert.Throws<Exception>(() => service.Ordenar(null));
        }
        [Fact]
        public void Deve_Retornar_Lista_Vazia_Quando_Conjunto_For_Vazio()
        {
            var config = new OrdenacaoConfig();
            var service = new LivroOrdenacaoService(config);

            var resultado = service.Ordenar(new List<Livro>());

            Assert.Empty(resultado);
        }
    }
}
