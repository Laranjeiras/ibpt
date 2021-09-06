# ibpt

[![Pack Dominio + Push no NuGet](https://github.com/Laranjeiras/ibpt/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Laranjeiras/ibpt/actions/workflows/dotnet.yml)

[![Issues](https://img.shields.io/github/issues/Laranjeiras/ibpt.svg)](https://github.com/Laranjeiras/ibpt/issues)

![Nuget](https://img.shields.io/nuget/dt/ibpt.core)
[![Nuget count](http://img.shields.io/nuget/v/Ibpt.Core.svg)](http://www.nuget.org/packages/Ibpt.Core/)

Biblioteca gratuita em C# para manipulação dos dados da tabela IBPT

O projeto importa os dados da tabela IBPT formato CSV (arquivo oficial obtido através do site www.deolhonoimposto.ibpt.org.br) e disponibiliza um repositório para consulta das aliquotas de impostos pelo NCM do produto e UF da empresa emitente da NFe

**Como usar:**
------------------
### Injeção de Dependência

Startup.cs
```cs
public void ConfigureServices(IServiceCollection services) 
{
  // diretório contendo os arquivos padrão IBPT
  var diretorio = @"E:\Downloads\tabela-ibpt-21_2_A";
  var versao = "21.2";
  services.AddSingleton<IIbptRepositorio>(x => new IbptCsvRepositorio(diretorio, versao));
}
```

Classe.cs
```cs
public class Classe {
  private readonly IIbptRepositorio repositorio;
  
  public Classe(IIbptRepositorio repositorio) 
  {
    this.repositorio = repositorio;  
  }
  
  public void ConsultarAliquota(string ncm, eUF uf) {
    var aliquota = repositorio.ObterPorNcm("27101932", Core.Tipos.eUF.RJ);
  }
}
```
--------------


