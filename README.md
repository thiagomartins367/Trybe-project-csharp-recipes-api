# API de Receitas

Boas-vindas ao repositório do projeto `API de Receitas`

Nesse projeto foi desenvolvido uma API de receitas que retorna todas as receitas disponíveis, adiciona, remove e atualiza as mesmas, além de possuir um CRUD de usuários e recurso de comentários.

Desenvolvido durante o período de **Aceleração C#** da Trybe 🚀

Tem por objetivo a avaliação e prática dos conhecimentos adquiridos durante a aceleração, visando o cumprimento do requisitos solicitados!

## Uso no Docker 🐋
Se você possuir o [Docker](https://www.docker.com) e o [Docker compose](https://docs.docker.com/compose/install) instalados, você pode economizar muito trabalho na configuração do ambiente de produção.

⚠️ No ambiente Docker de produção a API não utiliza redirecionamento HTTPS por padrão a fim de diminuir a complexidade na inicialização local, já que seria nescessário configurar uma hosdagem no docker utilizando o HTTPS. Para saber como configurar essa hospedagem acesse a [Documentação Oficial](https://learn.microsoft.com/pt-br/aspnet/core/security/docker-compose-https?view=aspnetcore-6.0) do *ASP.NET*.

Para iniciar a API no ambiente Docker, basta executar 1 comando:
```
docker-compose -f docker-compose.prod.yml up -d
```
Assim que os containers estiverem funcionando, a API poderá ser acessada no `http://localhost`

Faça um teste acessando a rota `http://localhost/recipe` em seu navegador.

## Instalação e Uso 🖥️
⚠️ É necessário ter instalado o [.NET Framework](https://dotnet.microsoft.com/pt-br) (Windows) ou [.NET Core](https://dotnet.microsoft.com/pt-br/) (Linux/ Mac) em sua máquina para executar o sistema.

**Na raiz do projeto execute os comandos abaixo no seu terminal:**

1. Instale as dependências
```
dotnet restore ./src
```

2. Execute a aplicação
```
dotnet run --project ./src/recipes-api/recipes-api.csproj
```

## Desenvolvimento 🧑‍💻
Para desenvolver novos recursos ou refatorar é recomendado o uso do [Docker](https://www.docker.com) e do [Docker compose](https://docs.docker.com/compose/install), pois ele fornece um ambiente isolado e devidamente configurado no arquivo `docker-compose.dev.yml`.

⚠️ É necessário ter o [Git](https://git-scm.com) instalado em sua máquina para o controle de versão do sistema.

**Na raiz do projeto execute os comandos abaixo no seu terminal:**
1. Crie e entre em uma nova *branch* de desenvolvimento
```
git checkout -b nome-da-branch
```

2. Crie o ambiente Docker de desenvolvimento
```
docker-compose -f docker-compose.dev.yml up -d
```
Após esse processo a API estará disponível em seu `http://localhost:5057` e pronta para o desenvolvimento.

Para adicionar as alterações da nova branch de desenvolvimento na branch principal ```main``` é nescessário criar um *Pull Request* neste repositório.

Alterações diretas na branch ```main``` estão bloqueadas.

⚠️ NOTA: O uso dos comandos `make` listados no arquivo `Makefile` é recomendado para acelerar o processo de criação e remoção dos containers dev ou na execução de scripts `dotnet` no caso de não usar o docker como ambiente de desenvolvimento.

## Contribuidores 🤝

- [THIAGO MARTINS](https://github.com/thiagomartins367) - criador e mantenedor
