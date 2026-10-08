using CalculadoraDescontos.App;

namespace CalculadoraDescontos.Tests;

public class DescontoServiceTests
{
    private readonly DescontoService _service = new DescontoService();

    // ─────────────────────────────────────────────────────────────
    // TODO (Colega 2): Teste 1 — ObterCategoriaCliente (retorno string)
    // Use [Theory] + [InlineData] para os 3 cenários abaixo:
    //   [InlineData(2,  "BRONZE")]
    //   [InlineData(7,  "PRATA")]
    //   [InlineData(15, "OURO")]
    // Valide com Assert.Equal(categoriaEsperada, resultado)
    // ─────────────────────────────────────────────────────────────
    [Theory]
[InlineData(2, "BRONZE")]
[InlineData(7, "PRATA")]
[InlineData(15, "OURO")]
public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(
    int totalCompras,
    string categoriaEsperada)
{
    var resultado = _service.ObterCategoriaCliente(totalCompras);

    Assert.Equal(categoriaEsperada, resultado);
}


    // ─────────────────────────────────────────────────────────────
    // TODO (Colega 2): Teste 2 — CalcularDescontoPorPercentual (retorno int)
    // Use [Theory] + [InlineData] para os 3 cenários abaixo:
    //   [InlineData(100, 10,  90)]
    //   [InlineData(200, 20, 160)]
    //   [InlineData(50,   0,  50)]
    // Valide com Assert.Equal(valorEsperado, resultado)
    // ─────────────────────────────────────────────────────────────
    [Theory]
[InlineData(100, 10, 90)]
[InlineData(200, 20, 160)]
[InlineData(50, 0, 50)]
public void CalcularDescontoPorPercentual_DeveRetornarValorCorreto(
    int valorOriginal,
    int percentualDesconto,
    int valorEsperado)
{
    var resultado = _service.CalcularDescontoPorPercentual(
        valorOriginal,
        percentualDesconto);

    Assert.Equal(valorEsperado, resultado);
}


    // ─────────────────────────────────────────────────────────────
    // TODO (Colega 2): Teste 3 — EValidoParaCupom (retorno bool)
    // Use [Theory] + [InlineData] para os 3 cenários abaixo:
    //   [InlineData(20, false, true)]   // maior de idade, não primeira compra → true
    //   [InlineData(16, true,  true)]   // menor de idade, primeira compra     → true
    //   [InlineData(17, false, false)]  // menor de idade, não primeira compra  → false
    // Valide com Assert.Equal(esperado, resultado)
    // ─────────────────────────────────────────────────────────────

    [Theory]
[InlineData(20, false, true)]
[InlineData(16, true, true)]
[InlineData(17, false, false)]
public void EValidoParaCupom_DeveRetornarResultadoCorreto(
    int idade,
    bool primeiraCompra,
    bool esperado)
{
    var resultado = _service.EValidoParaCupom(
        idade,
        primeiraCompra);

    Assert.Equal(esperado, resultado);
}

}
