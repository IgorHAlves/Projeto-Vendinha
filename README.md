# Projeto full stack
## Vendinha

No projeto foi desenvolvida uma aplicação web do zero, que tem como função:
*  Cadastrar clientes;
*  Visualizar clientes cadastrados;
*  Adicionar pedidos;
*  visualizar pedidos;
*  Visualizar dívidas dos clientes (somatória de pedidos não pagos).

O desenvolvimento da aplicação rodou em torno da criação do banco de dados, desenvolvimento da API e o consumo da API no front-end.

O que usei?

*  PostgreSQL
  
    O Banco de dados foi criado no PostgreSQL, com comandos como create-table, chaves primárias e interações entre tabelas com chave estrangeira (foreing key).
*  C#
  
    A API para o CRUD no banco de dados foi desenvolvida em C#, onde utilizamos o modelo MVC para o controller, e também o NHibernate, para otimizar os comandos SQL.
*  HTML

    Foi utilizado HTML para a marcação de dados que seriam visíveis na página do front-end.

*  CSS

    CSS foi essencial para estilizar o HTML, mantendo as boas práticas para melhor identificação de cada marcação.

*  JavaScript

    O consumo da API foi no Javascript, utilizando o fetch e o .then para obter e tratar o json vindo do banco de dados, e também alterando para o method post, possilibtando adicionar novos elementos ao banco.

## Como executar a aplicação

Para exercutar a aplicação, será necesssário a criação do banco de dados, onde os comandos necessários estão no arquivo "bancodedados.sql" dentro da solução. 
Criarmos o banco de dados, devemos validar o código do mapeamento, para que os campos estejam identificados de forma correta e é valido confirmar se a ação de compilação dos campo estão como "Recurso Inserido" mesmo.
Feito isso, a API poderá ser iniciada, o que possibilitará o consumo da mesma no front-end, que está localizado no arquivo index.html dentro da pasta "front-end".

