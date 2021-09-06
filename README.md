# ibpt


Biblioteca gratuita em C# para manipulação dos dados da tabela IBPT

O projeto importa os dados da tabela IBPT formato CSV e cria serviço de consulta das aliquotas de impostos pelo NCM e UF do produto.

**Como usar:**
------------------
### Injeção de Dependencia

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


