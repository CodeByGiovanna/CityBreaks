# CityBreaks.Web

Aplicação web em **ASP.NET Core Razor Pages (.NET 10)** com persistência em **SQLite** usando **Entity Framework Core**. Simula um portal de cadastro e consulta de propriedades turísticas.

Projeto desenvolvido no Teste de Performance 3 da disciplina **Desenvolvimento Web com .NET e Bases de Dados (DR4)**, INFNET.

## Funcionalidades

- Listagem de cidades com país e propriedades (`Include`)
- Página de detalhes da cidade pelo nome na URL, sem diferenciar maiúsculas/minúsculas (`EF.Functions.Collate` + `NOCASE`)
- Cadastro de propriedades com seleção de cidade (`SelectList`)
- Edição segura com `TryUpdateModelAsync`, que libera só os campos permitidos
- Exclusão lógica (soft delete) com o campo `DeletedAt`
- Busca com filtros dinâmicos por faixa de preço, cidade e nome (`IQueryable`)

## Tecnologias

- .NET 10 / ASP.NET Core Razor Pages
- Entity Framework Core 10 + SQLite
- Fluent API (`IEntityTypeConfiguration<T>`) e seed data com `HasData`
- Migrations via `dotnet-ef`

## Modelo de dados

```
Country 1 ── N City 1 ── N Property
```

| Entidade | Campos |
|----------|--------|
| Country  | Id, CountryCode, CountryName |
| City     | Id, Name, CountryId |
| Property | Id, Name, PricePerNight, CityId, DeletedAt |

## Migrations

1. `InitialCreate`
2. `AddCityEntity`
3. `AddPropertyEntity`
4. `ApplyFluentApiConfigurations`
5. `SeedInitialData`
6. `AddSoftDelete`

## Como rodar

Pré-requisitos: .NET 10 SDK e a ferramenta `dotnet-ef`.

```bash
dotnet tool install --global dotnet-ef --version "10.0.*"
cd CityBreaks
dotnet ef database update
dotnet run
```

O comando `dotnet ef database update` cria o arquivo `CityBreaks.db` com as tabelas e os dados de exemplo.

## Páginas

| Rota | Descrição |
|------|-----------|
| `/` | Lista de cidades |
| `/CityDetails/{nome}` | Detalhes da cidade (ex.: `/CityDetails/turin`) |
| `/CreateProperty` | Nova propriedade |
| `/EditProperty/{id}` | Edição de propriedade |
| `/FilterProperties` | Busca com filtros |

## Autora

Neuza de Oliveira
