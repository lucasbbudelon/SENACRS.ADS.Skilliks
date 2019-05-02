# skilliks-backend

**Descrição:** Trata-se do server side. Este projeto usa [.net core](https://pt.stackoverflow.com/questions/40671/o-que-%C3%A9-o-net-core) como tecnologia base e a linguagem C#. O backend do projeto é totalmente isolado do frontend, sendo assim, a unica forma de comunicação é via http seguindo o padrão [restfull](https://pt.stackoverflow.com/questions/45783/o-que-%C3%A9-rest-e-restful). O conceito de api deve ser seguido, afim de manter o backend isolado, de forma que possa ser reutilizado por outros clientes.

## Ambiente de Desenvolvimento

- [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads)
- [POSTMAN](https://www.getpostman.com/downloads)
- [IIS](https://pt.stackoverflow.com/questions/185603/como-ativar-o-iis-no-windows-10) (Opcional)

### Quick start

- Clonar repositório (git clone https://github.com/lucasbbudelon/SENACRS.ADS.Skilliks.git)
- Entar na pasta (skilliks-backend)
- Abrir a solução do projeto (SENACRS.ADS.Skilliks.Backend.sln)
- Rodar o projeto (Clicar no botão IIS Express, simbolo de play verde na barra superior de ferramentar)

## Arquitetura

O projeto possui as seguitnes camadas: WebApi, Domain e Repository.

### WebApi

Camada responsável por expor as rotas da api e comunicar-se com o client. Seria o canal de entrada e saída dos dados.

### Domain

Nesta camada estão todas as entidades da aplicação, bem como seus contratos de dados e demais classes de domínio.

### Repository
Camada de persistência de dados, reponsável por comunicar-se com o banco de dados.

#### SGBD
Visando praticidade, agilidade e custos, este projeto está utilizando [sqlite](https://www.sqlite.org/index.html) como SGBD. Para manipular os dados, basta importar o arquivo ".sqlite" no [sqlitebrowser](https://sqlitebrowser.org/).
 
#### ORM
Este projeto está utilizando o micro ORM [dapper](https://dapper-tutorial.net/), devido sua praticidade e performace.

