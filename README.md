\#  Biblioteca – Serviço de Ordenação de Livros



Este projeto implementa um serviço de ordenação de livros conforme critérios definidos externamente por configuração, sem necessidade de interface visual ou aplicação console.



A solução foi desenvolvida seguindo as restrições propostas no teste, priorizando simplicidade, clareza e desacoplamento.



---



\##  Objetivo



Ordenar uma lista de livros com base em múltiplos critérios, como:



\- Título

\- Autor

\- Edição



Os critérios e a direção da ordenação (\*\*ascendente\*\* ou \*\*descendente\*\*) são definidos por configuração, sem necessidade de alterar o código.



---



\##  Estrutura do Projeto



\### Models

\- \*\*Livro\*\*: representa a entidade livro



\### Configuration

\- \*\*OrdenacaoConfig\*\*: define os critérios de ordenação

\- \*\*CriterioOrdenacao\*\*: define propriedade e direção



\### Services

\- \*\*LivroOrdenacaoService\*\*: contém a lógica de ordenação



\### Tests

\- Testes unitários validando os diferentes cenários de ordenação



---



\##  Como funciona a ordenação



\- A ordenação utiliza apenas \*\*LINQ nativo do .NET\*\*

\- O primeiro critério usa `OrderBy` / `OrderByDescending`

\- Os critérios seguintes usam `ThenBy` / `ThenByDescending`

\- A ordem dos critérios respeita exatamente a configuração informada



\### Exemplo de configuração



```json

{

&nbsp; "criterios": \[

&nbsp;   { "propriedade": "Autor", "direcao": "Ascendente" },

&nbsp;   { "propriedade": "Titulo", "direcao": "Descendente" }

&nbsp; ]

}



