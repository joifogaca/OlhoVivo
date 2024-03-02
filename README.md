# OlhoVivo

Baseando no desafio abaixo:

https://github.com/aikodigital/teste-desenvolvedor-net

### Instalando ferramenta para Migration

`dotnet tool install --global dotnet-ef`

`dotnet ef` ver a versão

### Criando a Migração

`dotnet ef migrations add <nome_arquivo>` gera o banco 

`dotnet ef database update` gera o script criado e executa no bvanco

## Dúvidas sobre o padrão RESTFull

https://www.brunobrito.net.br/api-restful-boas-praticas/

https://medium.com/@ramonrune/arquitetando-uma-api-restful-8ffcf892586a

## Regras Négocio

- Um veiculo é cadastro e depois ele e atribuido a uma linha
- Se um veiculo já possuir uma linha, ele devera se desassoriar da linha dessa linha para ser cadastrado em uma nova

## Futuras implementações

- A url PUT `/line/{id}/binds-bus-stop` receber uma lista de ids de BusStop
