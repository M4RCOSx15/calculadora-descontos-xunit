# 🏷️ CalculadoraDescontos

**Categorização de clientes, cálculo de descontos e validação de cupom, com testes parametrizados em xUnit.**

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![xUnit](https://img.shields.io/badge/tests-xUnit-5E2D91)
![Testes](https://img.shields.io/badge/testes-9%20execu%C3%A7%C3%B5es-brightgreen)
![Licença](https://img.shields.io/badge/licen%C3%A7a-MIT-blue)

## 📑 Sumário

- [Sobre o projeto](#-sobre-o-projeto)
- [Tecnologias](#-tecnologias)
- [Estrutura da solução](#-estrutura-da-solução)
- [Pré-requisitos](#-pré-requisitos)
- [Como executar](#-como-executar)
- [Métodos implementados](#-métodos-implementados--descontoservice)
- [Diferença entre Fact e Theory](#-diferença-entre-fact-e-theory)
- [Cobertura de testes](#-cobertura-de-testes)
- [Como a solução foi criada](#-como-a-solução-foi-criada)
- [Equipe](#-equipe)
- [Licença](#-licença)

## 📖 Sobre o projeto

Projeto desenvolvido na disciplina **Garantia da Qualidade de Software** (Gestão e Qualidade de Software), sob orientação do professor **Daniel Henrique Matos de Paiva**.

O objetivo é compreender a diferença entre `[Fact]` (teste único, sem parâmetros) e `[Theory]` (teste parametrizado que roda várias vezes com dados do `[InlineData]`), aplicando os dois conceitos em uma solução .NET 10 criada via linha de comando. Os métodos cobrem entradas e retornos dos tipos `string`, `int` e `bool`.

## 🛠️ Tecnologias

| Tecnologia | Uso |
|---|---|
| [.NET 10](https://dotnet.microsoft.com/) | Plataforma da aplicação e dos testes |
| C# | Linguagem de programação |
| [xUnit](https://xunit.net/) | Framework de testes unitários |
| Git e GitHub | Versionamento e colaboração |

## 📦 Estrutura da solução

```
CalculadoraDescontos.slnx
├── CalculadoraDescontos.App      -> código de produção (classe DescontoService)
├── CalculadoraDescontos.Tests    -> testes unitários (classe DescontoServiceTests)
├── .gitignore                    -> arquivos ignorados pelo Git (padrão .NET)
├── LICENSE                       -> licença MIT
└── README.md                     -> documentação do projeto
```

- **CalculadoraDescontos.App**: projeto console (`net10.0`) com as regras de negócio.
- **CalculadoraDescontos.Tests**: projeto xUnit (`net10.0`) que referencia o projeto `App` e testa cada método.

## ✅ Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

Para conferir a instalação:

```bash
dotnet --version
```

## ▶️ Como executar

```bash
# 1. Clonar o repositório
git clone https://github.com/M4RCOSx15/calculadora-descontos-xunit.git

# 2. Entrar na pasta
cd calculadora-descontos-xunit

# 3. Executar os testes
dotnet test
```

Para ver cada `[InlineData]` listado individualmente:

```bash
dotnet test --logger "console;verbosity=detailed"
```

Resultado esperado: **9 testes aprovados, 0 falhas**.

## 🔧 Métodos implementados — `DescontoService`

| Método | Retorno | Regra |
|---|---|---|
| `ObterCategoriaCliente(int totalCompras)` | `string` | `"BRONZE"` para menos de 5 compras, `"PRATA"` de 5 a 10 (inclusive) e `"OURO"` para mais de 10 |
| `CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)` | `int` | Retorna o valor final com o desconto aplicado |
| `EValidoParaCupom(int idade, bool primeiraCompra)` | `bool` | `true` se a idade for 18 ou mais **ou** se for a primeira compra; caso contrário, `false` |

### Exemplos de entrada e saída

| Chamada | Resultado | Observação |
|---|---|---|
| `ObterCategoriaCliente(2)` | `"BRONZE"` | Menos de 5 compras |
| `ObterCategoriaCliente(7)` | `"PRATA"` | Entre 5 e 10 |
| `ObterCategoriaCliente(15)` | `"OURO"` | Mais de 10 |
| `CalcularDescontoPorPercentual(100, 10)` | `90` | 10% de desconto sobre 100 |
| `CalcularDescontoPorPercentual(200, 20)` | `160` | 20% de desconto sobre 200 |
| `CalcularDescontoPorPercentual(50, 0)` | `50` | Sem desconto |
| `EValidoParaCupom(20, false)` | `true` | Maior de idade |
| `EValidoParaCupom(16, true)` | `true` | Primeira compra |
| `EValidoParaCupom(17, false)` | `false` | Menor de idade e não é primeira compra |

## 📚 Diferença entre Fact e Theory

| | `[Fact]` | `[Theory]` |
|---|---|---|
| Parâmetros | Não recebe | Recebe, via `[InlineData]` |
| Execuções | Uma | Uma por `[InlineData]` |
| Quando usar | Cenário fixo e único | Mesma lógica com vários conjuntos de dados |

Com `[Theory]`, em vez de escrever vários métodos quase idênticos, escreve-se um só e listam-se os cenários. Cada `[InlineData]` aparece como um teste individual no resultado:

```csharp
[Theory]
[InlineData(2, "BRONZE")]
[InlineData(7, "PRATA")]
[InlineData(15, "OURO")]
public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(int totalCompras, string esperado)
{
    Assert.Equal(esperado, _service.ObterCategoriaCliente(totalCompras));
}
```

Isso evita duplicação de código e facilita acrescentar novos cenários: basta incluir mais uma linha `[InlineData]`.

## 🧪 Cobertura de testes

Os testes ficam na classe `DescontoServiceTests`: 3 métodos `[Theory]`, cada um com 3 `[InlineData]`, totalizando **9 execuções**.

| Método testado | Tipo | `[InlineData]` (entradas → esperado) |
|---|---|---|
| `ObterCategoriaCliente` | `string` | `(2, "BRONZE")`, `(7, "PRATA")`, `(15, "OURO")` |
| `CalcularDescontoPorPercentual` | `int` | `(100, 10, 90)`, `(200, 20, 160)`, `(50, 0, 50)` |
| `EValidoParaCupom` | `bool` | `(20, false, true)`, `(16, true, true)`, `(17, false, false)` |

## 🧱 Como a solução foi criada

```bash
dotnet new sln -n CalculadoraDescontos
dotnet new console -n CalculadoraDescontos.App -f net10.0
dotnet new xunit -n CalculadoraDescontos.Tests -f net10.0
dotnet sln add CalculadoraDescontos.App/CalculadoraDescontos.App.csproj
dotnet sln add CalculadoraDescontos.Tests/CalculadoraDescontos.Tests.csproj
dotnet add CalculadoraDescontos.Tests/CalculadoraDescontos.Tests.csproj reference CalculadoraDescontos.App/CalculadoraDescontos.App.csproj
```

## 👥 Equipe

Projeto desenvolvido de forma colaborativa por:

| Nome | GitHub |
|---|---|
| Marcos | [@M4RCOSx15](https://github.com/M4RCOSx15) |
| Michelle | MicheleUai (https://github.com/MicheleUai) |
| Vinícius Henrique Diniz Bento | [@Viniciushdb](https://github.com/Viniciushdb) |

### Fluxo de colaboração

O trabalho foi organizado com Git e GitHub: cada melhoria é feita em uma branch própria (por exemplo, `docs/Aprimorar-README`) e integrada à `main` por meio de **Pull Request**, com descrição das alterações e revisão antes do merge.

## 📝 Licença

Este projeto está sob a licença [MIT](LICENSE).
