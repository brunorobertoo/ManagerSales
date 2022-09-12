# managerSales

## Como executar
Clone o Projeto para um diretório qualquer em seu computador

```bash
git clone https://github.com/brunorobertoo/managerSales
```

Crie um container para o banco de dados mysql
```bash
docker run --name managerSalesDB -p 3306:3306 -e MYSQL_ROOT_PASSWORD=123456 -d mysql
```
pré requisito = ter instalado o docker

Foi utilizado o migration do Entity Framework para criação de tabelas e o banco de dados em si e precisará rodar esses comandos:

Para instalar
```bash
dotnet tool install --global dotnet-ef
```

Para rodar a migration (Como já temos os arquivos prontos ele só irá executar os scripts e criar a base de dados)
```bash
dotnet ef database update
```

Uma vez criado o banco de dados vamos rodar a aplicação com o seguinte comando:

```bash
dotnet run
```

A aplicação irá iniciar na porta 5001 e para acessar basta acessar essa url: 

```bash
https://localhost:5001/swagger/index.html
```
## Tecnologias adotadas e seus motivos

Utilizamos como linguagem principal C# com framework dotnet net5.0 o qual tenho mais familiaridade nos meus estudos,
também utilizei o framework de banco de dados o entityframework pela facilidade em gerir os modelos de dados e executar migrações de scripts em sql,

## Mysql

banco relacional mysql pela facilidade da gestão do framework e pelas bibliotecas prontas como MySql.EntityFrameworkCore

## Docker

para criação do container do banco de dados, sem precisar fazer instalações de grande porte na máquina, apenas executar o comando e seu banco de dados estará pronto localmente para testes.

## Swagger com Swashbuckle

Swagger para documentação da api no contexto geral e para documentar os endpoints com suas respectivas respostas http e suas entradas de contratos/payload ou requests.

## AutoMapper

Em alguns momentos precisei transformar objetos de request em objetos de criação de dados no banco de dados, então utilizei a biblioteca AutoMapper que é de muito fácil utilização 
apenas configurando qual tipo de entrada e qual o tipo de saída e utilizando como no seguinte exemplo:

```bash
User user = _mapper.Map<User>(userRequest);
```

## Client - Newtonsoft

Criei um pacote apenas para o cliente onde foi utilizando a biblioteca Newtonsoft para fazer a conversão e deserealização de um tipo de dados para um especifico 
no qual eu garantiria obter os dados que eu precisava como a razão social por exemplo, temos esse exemplo:

```bash
return JsonConvert.DeserializeObject<CnpjResponse>(resp);
```

onde meu valor definitivo é o objeto CnpjResponse e por ele posso obter os dados no qual preciso.

## Lógica da roleta

Depois da requisição da api externa e realizar uma consulta no banco para obter os usuários baseado no dado do código do ibge a seguinte lógica foi aplicada.

1- é verificado se a lista de usuários tem algum dado se não tiver estoura uma Exception informando que não existem usuários para região
2 - Caso tenha dados é utilizado o foreach para verificar se os usuários tem oportunidades, o usuário que não tiver vai ser escolhido.
3 - Caso todos tenham oportunidades é obtido o primeiro da lista.
4 - Caso retorne apenas 1 usuário esse será cadastrado na oportunidade.