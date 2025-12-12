# Pay Flow API

## Arquitetura
Este projeto adotou o padrão de arquitetura DDD pelos seguintes motivos:

- Baixo acoplamento. Em uma eventual necessidade de troca de frameworks, o dominio da aplicação pode ser reutilizado facilmente
- Escalabilidade. É um padrão de projeto que permite escalabilidade de acordo com o crescimento da demanda
- Facil implementação. O Projeto é simples de dar manutenção e de criar novas funcionalidades, apenas incluindo novos endpoints e novos serviços sem a necessidade de alterações drásticas no core do sistema

## ORM

Este projeto utiliza o Entity Framework como ORM, uma vez que o mesmo facilita as atividades padrão de CRUD no banco de dados, aumentando a performance na criação de novas features na aplicação

## Banco de dados

Este projeto utiliza o banco de dados SQL Server como seu banco padrão

## Configurações

Este projeto esta configurado para rodar tanto via debug atraves da IDE de sua preferencia, quanto via docker compose.
O unico ajuste manual necessário é alterar a string de conexão que encontra-se dentro do arquivo appsettings.json no projeto PayFlow.API e no arquivo DesignTimeDbContextFactory dentro do projeto PayFlow.Infra.
Após inserir uma string de conexão valida para um banco sql server, basta dar o play na solução, ou caso queira rodar via docker compose, basta abrir o terminal na pasta onde encontra-se o arquivo docker-compose.yml no projeto PayFlow.API e rodar o seguinte comando:
```console
docker compose up --build -d
```
Quando quiser parar, basta executar o comando:

```console
docker compose down
```

OBS: Para rodar a aplicação via docker compose é necessário ter o docker e o docker compose previamente instalado em seu ambiente

Caso o comando funcione, deve ser exibido um retorno parecido com o abaixo em seu terminal:

`[+] Running 3/3 `

` ✔ payflow.api:latest                  Built   `                                                                                                           
` ✔ Container payflowapi-payflow.api-1  Started `                                                                                                           
` ✔ Container payflowapi-migrator-1     Started `

Após isso, basta acessar a URL http://localhost:8080/swagger que irá ter acesso ao swagger para verificar se as APIs estão de acordo com o esperado.

