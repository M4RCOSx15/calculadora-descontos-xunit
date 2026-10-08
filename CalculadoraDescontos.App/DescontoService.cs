namespace CalculadoraDescontos.App;

/// <summary>
/// Serviço responsável pelas regras de desconto e categorização de clientes.
/// </summary>
public class DescontoService
{
    /// <summary>
    /// Retorna a categoria do cliente com base no total de compras realizadas.
    /// </summary>
    /// <param name="totalCompras">Número total de compras do cliente.</param>
    /// <returns>"BRONZE" (menos de 5), "PRATA" (5 a 10), "OURO" (mais de 10).</returns>
    public string ObterCategoriaCliente(int totalCompras)
    {
        if (totalCompras < 5)
            return "BRONZE";

        if (totalCompras <= 10)
            return "PRATA";

        return "OURO";
    }

    /// <summary>
    /// Calcula o valor final após aplicar um percentual de desconto.
    /// </summary>
    /// <param name="valorOriginal">Valor original do produto/serviço.</param>
    /// <param name="percentualDesconto">Percentual de desconto a aplicar (0-100).</param>
    /// <returns>Valor final com desconto aplicado.</returns>
    /// <example>CalcularDescontoPorPercentual(100, 10) → 90</example>
    public int CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)
    {
        return valorOriginal - (valorOriginal * percentualDesconto / 100);
    }

    /// <summary>
    /// Verifica se o cliente é elegível para receber um cupom de desconto.
    /// Elegível se tiver 18 anos ou mais OU se for a primeira compra.
    /// </summary>
    /// <param name="idade">Idade do cliente.</param>
    /// <param name="primeiraCompra">Indica se é a primeira compra do cliente.</param>
    /// <returns>True se elegível; False caso contrário.</returns>
    public bool EValidoParaCupom(int idade, bool primeiraCompra)
    {
        return idade >= 18 || primeiraCompra;
    }
}
