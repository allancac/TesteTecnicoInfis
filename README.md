
# API de Cálculo de Impostos

## 1.  Visão Geral

Este projeto é a minha solução para um desafio técnico para o processo seletivo da empresa [INFIS Consultoria](https://infisconsultoria.com.br/).
Desenvolvi uma **API RESTful** em **.NET 9** com foco em boas práticas de arquitetura e documentação. O objetivo é calcular impostos (ICMS, PIS e COFINS) sobre pedidos compostos por uma lista de produtos.

A solução segue o padrão **DDD (Domain-Driven Design) em camadas**, com separação clara entre:

- Controllers (API)
- Application Services (regra de orquestração)
- Domain Services (regra de negócio)
- DTOs
- Exceptions customizadas

## 2. Tecnologias e linguagem de programação utilizadas

- .NET 9
- ASP.NET Core Web API
- Swashbuckle.AspNetCore (Swagger)
- C#

## 3. Boas Práticas Implementadas

- Injeção de Dependências via IoC
- Tratamento de exceções customizadas (ApplicationServiceException)
- Uso de **DTOs separados para entrada e saída**
- Documentação de **todos os DTOs e Controllers com XML Comments**
- Exemplo de payload via **IExamplesProvider<>**
- Separação clara entre camada de aplicação e de domínio

## 4. Estrutura do Projeto

```
CalculoImposto.Api
├── Controllers     (Responsável por receber as requisições HTTP e delegar o processamento para a camada de Application)
├── Application     (Camada de aplicação - Contém regras de orquestração e comunicação com o domínio)
│   ├── DTOs        (Modelos de transferência de dados entre a API e o cliente)
│   ├── Interfaces  (Interfaces que a camada Application expõe e usa para comunicação com a Domain)
│   ├── Services    (Implementações das interfaces da Application, chamando os serviços do domínio)
│   └── Exceptions  (Exceções específicas da camada de aplicação)
├── Domain          (Camada de domínio - Onde estão as regras de negócio puras)
│   ├── Entities    (Modelos de domínio, como Pedido e Produto)
│   ├── Interfaces  (Contratos de serviços de domínio)
│   ├── Services    (Implementações das regras de negócio)
│   └── Exceptions  (Exceções de domínio para tratar erros específicos da lógica de negócio)
└── Program.cs      (Configuração da aplicação, injeção de dependências, Swagger e pipeline HTTP)

```

## 5. Como Executar o Projeto

Compile o projeto com:

    dotnet build

Rode a API com:

    dotnet run


##  6. Principais Funcionalidades da API

### Endpoint: `POST /api/v1/CalculoImposto`

### Descrição:
Recebe um pedido contendo UF de origem, UF de destino, data e lista de produtos. Calcula os impostos conforme flags de query string.

### Funcionalidades:
- Cálculo de ICMS, PIS e COFINS a partir de um pedido com múltiplos produtos.

- Endpoint para cálculo de impostos via POST com parâmetros de query string para indicar quais impostos calcular.

- Tratamento de exceções específicas de aplicação e domínio.

- Documentação automática via Swagger (OpenAPI).

### Exemplo de chamada:

```
POST https://localhost:{porta}/api/v1/CalculoImposto?icms=true&pis=true&cofins=true
```

### Exemplos de Body:

#### Exemplo 1:

```json
{
  "id": 1,
  "ufOrigem": "SP",
  "ufDestino": "RJ",
  "data": "2025-06-14",
  "produtos": [
    { "id": 1, "nome": "Mouse", "valor": 100.35 },
    { "id": 2, "nome": "Teclado", "valor": 200.0 },
    { "id": 3, "nome": "Monitor", "valor": 895.25 }

  ]
}
```

#### Exemplo 2:

```json
{
  "id": 3,
  "ufOrigem": "RJ",
  "ufDestino": "RJ",
  "data": "2025-06-15",
  "produtos": [
    { "id": 1, "nome": "Mouse", "valor": 100.35 },
    { "id": 2, "nome": "Monitor", "valor": 895.25 }
  ]
}
```

## 7. Documentação Swagger

- **Swagger UI disponível em:**  
  http://localhost:{{porta}}/swagger/index.html

- Inclui:
  - Descrição de endpoints
  - Parâmetros de Query e Body
  - Documentação XML extraída dos comentários do código




## 8. Testes Automatizados

O projeto inclui testes unitários, organizados por camadas e namespaces, garantindo a cobertura das principais regras de negócio e orquestração.
## 8.1. Projeto de Testes: CalculoImposto.Tests
### 8.1.1. Application Services

Classe: CalculoImpostosApplicationServiceTests

    Teste: CalcularImpostoCOFINS_DeveRetornarValoresCorretos

    Teste: CalcularImpostoICMS_DeveRetornarValoresCorretos

    Teste: CalcularImpostoPIS_DeveRetornarValoresCorretos

    Teste: CalcularImpostos_DeveRetornarValoresCorretos

    Teste: CalcularImpostos_NenhumImpostoSelecionado_DeveLancarExcecao

    Teste: CalcularImpostos_ProdutoValorNaoPositivo_DeveLancarPilhaExcecoes

### 8.1.2. Controllers

Classe: CalculoImpostoControllerTests

    Teste: CalcularImpostos_DeveRetornarOk

### 8.1.3. Domain Entities

Classe: PedidoTests

    Teste: AdicionarProduto_DeveLancarExcecaoParaPrecoNaoPositivo

    Teste: ValorTotal_DeveRetornarSomaDosProdutos

Classe: ProdutoTests

    Teste: PrecoNegativo_DeveLancarDomainException

    Teste: ProdutosComMesmoId_DevemSerIguais

    Teste: ToString_DeveRetornarJson

### 8.1.4. Domain Services

Classe: CalculoImpostoDomainServiceTests

    Teste: CofinsTests

    Teste: IcmsDifUFTests

    Teste: IcmsMesmaUFTests

    Teste: PisTests

## 9. Postman
[Postman](https://app.getpostman.com/join-team?invite_code=686dd91f55c3b646f9bd938094321435334a1401722ec50bbdb3a2ede586e94c&target_code=2a6faf227df37fe0bbff3621a132d4fc)

## 10. Melhorias Futuras

- Implementação de Middlewares para tratamento global de erros
- Mapeamento entre entidades e DTOs através do Automapper.

