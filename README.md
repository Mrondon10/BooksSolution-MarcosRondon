Books API - Prueba Técnica Marcos Rondon
 
Este repositorio contiene la implementación de un Backend en ASP.NET Core WebApi que cumple con los siguientes requerimientos:

Endpoints (CRUD) para Books:

GET /api/Books

GET /api/Books/{id}

POST /api/Books

PUT /api/Books/{id}

DELETE /api/Books/{id}

Retorno de HttpStatusCode según el estándar REST.

Consumo de un servicio REST externo (Fakerestapi) usando HttpClient.

Capa de servicio (IBookService, BookService) opcional: implementada.

Tests unitarios (opcional): implementados con xUnit y Moq.

Repositorio en GitHub con GitFlow (opcional): implementado.

Nota: Fakerestapi no persiste cambios; sin embargo, este backend envía las peticiones y maneja las respuestas (status codes).

1. Requerimientos Técnicos
C# (ASP.NET Core 7.0).
HttpClient para llamar al endpoint externo de Fakerestapi.
xUnit para pruebas unitarias.
Ningún wizard o Scaffolding de Visual Studio he utilizado.
2. Pasos para Ejecutar

Clona este repositorio:
git clone git remote add origin https://github.com/Mrondon10/BooksSolution-MarcosRondon.git
cd BooksSolution

Restaura los paquetes:
dotnet restore

Ejecuta el proyecto WebApi:
cd BooksApi
dotnet run
Usualmente se inicia en http://localhost:5000.
Probar los endpoints con Postman o tu navegador:

GET http://localhost:5000/api/Books

GET http://localhost:5000/api/Books/1

POST http://localhost:5000/api/Books (enviando un JSON con el Book)

PUT http://localhost:5000/api/Books/{id}

DELETE http://localhost:5000/api/Books/{id}

3. Tests Unitarios
   
El proyecto BooksApi.Tests usa xUnit y Moq:

 Desde la carpeta raíz
 
-dotnet test-

Esto ejecutará las pruebas unitarias.

4. Uso de GitFlow
   
El flujo de trabajo lo realize con GitFlow:

Ramas principales:

master (producción)

develop (desarrollo)

Ramas feature:

feature/create-base-project: cree la solución y el proyecto WebApi.

feature/add-model-and-service: agrege el modelo Book.cs y la capa de servicio IBookService, BookService.

feature/add-books-controller: implemente el controlador BooksController con el CRUD.

feature/add-tests (opcional): añadi el proyecto de pruebas unitarias xUnit y configure los tests de BookService.

Cada rama de feature se finalizó con:

git flow feature finish ""

lo cual hizo un merge a develop y eliminó la rama local. Finalmente, se realizó un merge a la rama master.

5. Frameworks, Herramientas y Plugins Utilizados
   
ASP.NET Core 7: para desarrollar el WebApi.

HttpClient: para consumir la API externa.

xUnit + Moq: para realizar pruebas unitarias.

GitFlow: para administrar las ramas y el ciclo de vida de desarrollo.


7. Notas Finales
   
Este backend cumple con la prueba técnica solicitada: CRUD + StatusCodes, uso de Fakerestapi, capa de servicio opcional, tests unitarios opcionales, repositorio en GitHub y GitFlow.

Fakerestapi no persiste los cambios, pero responde con códigos 200, 201, etc., para simular el CRUD.


¡Gracias por revisar este proyecto!
