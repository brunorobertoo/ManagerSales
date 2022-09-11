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