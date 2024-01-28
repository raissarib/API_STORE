# Projeto API Farmácia PM  

  

## Visão Geral  

Este projeto implementa uma API para gerenciamento de uma farmácia, incluindo funcionalidades para lojas e produtos.  

  

## Tecnologias Utilizadas  

- C++  

- Docker  

- .NET Core para EF Migrations  

- ASP.NET Core para Controllers  

  

## Como Executar  

- Utilize ```make all``` para configurar, aplicar as migrações e executar o projeto.  

- Utilize ```make setup``` para levantar o ambiente usando Docker.  

- Utilize ```make migrations``` para executar as migrações do Entity Framework.  

- Utilize ```make run``` para iniciar a aplicação.  

- Ou se preferir rode os seguintes comandos: 
    ```docker-compose up -d```
    ```dotnet ef migrations add Migrations```
    ```dotnet ef database update```
    ```dotnet run```



## Estrutura do Projeto  

- 'Controllers': Contém os controladores para Lojas e Produtos.  

- 'Repositories': Implementa a lógica de acesso ao banco de dados para Lojas, Produtos, Preços e Estoques.  

- 'Requests': Define os formatos das requisições para as operações da API.  

  

## Endpoints da API 
- Cadastro de Produtos: 'POST /api/Product/create' 
- Cadastro de Lojas: 'POST /api/Store/create' 
- Buscar Produtos: 'GET /api/Product/{id}' 
- Buscar Lojas: 'GET /api/Store/{id}' 
- Atualizar Produtos: 'PUT /api/Product/update' 
- Atualizar Lojas: 'PUT /api/Store/update' 
- Deletar Produtos: 'DELETE /api/Product/{id}' 
- Deletar Lojas: 'DELETE /api/Store/{id}' 
- Buscar Produtos por Loja: 'GET /api/Product/stock-product/{storeId}/' 

 
 
## Observações 

Para conseguir excluir um produto, é necessário garantir que o produto não esteja em estoque e não possua preço vinculado a ele. Portanto, antes de excluir o produto, você deve primeiro excluir qualquer estoque e preço associados a ele. 

Da mesma forma, para excluir uma loja, é fundamental certificar-se de que a loja não tenha nenhum estoque vinculado a ela. Antes de excluir a loja, é necessário excluir qualquer estoque relacionado. 

Dessa forma, a sequência correta para excluir um produto seria: Excluir o estoque vinculado ao produto; Excluir o preço vinculado ao produto; Excluir o produto. 

E para a loja: Excluir o estoque vinculado à loja; Excluir a loja. 

Isso garantirá que não haja dependências antes de excluir os itens desejados. 

 

 
