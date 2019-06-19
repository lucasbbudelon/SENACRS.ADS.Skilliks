# skilliks-frontend

**Descrição:** Trata-se do client side. Este projeto usa [Angular](https://angular.io) como tecnologia base e a linguagem Type Script/Java Script. O frontend do projeto é totalmente isolado do backend, sendo assim, a unica forma de comunicação é via http seguindo o padrão [restfull](https://pt.stackoverflow.com/questions/45783/o-que-%C3%A9-rest-e-restful).

## Ambiente de Desenvolvimento

- [vscode](https://code.visualstudio.com/download)
- [NodeJS](https://nodejs.org/en/download)
- Google Chrome

### Quick start

- Clonar repositório (git clone https://github.com/lucasbbudelon/SENACRS.ADS.Skilliks.git)
- Abrir a pasta do repositório no terminar e executar os seguintes comandos:
```console
cd skilliks-frontend
npm install -g @angular/cli
npm install
ng serve -o
```

## Arquitetura

O projeto esta dividido da seguinte forme: components, layouts, pages,.

### components

Trata-se dos componentes comuns a aplicação todo, ex.: menu, cabeçalho, rodapé, etc.

### layouts

São o "template" que as páginas vao seguire, ex.: a página principal possui menu na lateral esquerda, cabeçalho e um rodapé. Os layouts utilizam os camponents para criar o "template" que as páginas vao seguir, deixando um espaço "miolo" para que as paginas sejam inseridas.

### pages

Corresponde aos conteúdos das páginas, como por exemplo a listagem de usuários.
