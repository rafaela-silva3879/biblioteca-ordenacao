using System.Text.Json;

namespace Biblioteca.Service.Configuration
{
    /// <summary>
    /// Responsável por carregar as configurações de ordenação a partir de arquivo JSON.
    /// </summary>
    public static class OrdenacaoConfigLoader
    {
        public static OrdenacaoConfig Carregar(string caminhoArquivo)
        {
            var json = File.ReadAllText(caminhoArquivo);
            return JsonSerializer.Deserialize<OrdenacaoConfig>(json);
        }
    }
}
