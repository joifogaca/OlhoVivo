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

## Repositorio Generico

https://marcionizzola.medium.com/criando-reposit%C3%B3rios-gen%C3%A9ricos-com-c-bb8c53177e13

https://dotnettutorials.net/lesson/generic-repository-pattern-csharp-mvc/#:~:text=The%20Generic%20Repository%20pattern%20in%20C%23%20is%20a,than%20having%20separate%20repositories%20for%20each%20entity%20type.

https://www.macoratti.net/21/06/aspnc_repuow1.htm
## Regras Négocio

- Um veiculo, linha e Ponto de ônibus não será removido, será apenas desativado.
- Um veiculo é cadastro e depois ele e atribuido a uma linha
- Se um veiculo já possuir uma linha, ele devera se desassoriar da linha dessa linha para ser cadastrado em uma nova

## Futuras implementações

- A url PUT `/line/{id}/binds-bus-stop` receber uma lista de ids de BusStop
