# Market
Repositorio creado para la alojar la prueba técnica para la empresa Tekton Labs en su cargo Lead NET Developer

### Consideraciones:
1.1. Crear un rest API en .net Core (última versión)
  RTA: Se utilizó Visial Studio 2022 y NET CORE 8 versión LST para la realización del proyecto que lo llamé MarketPlus (Una tienda deportiva)
  
#### 1.2. Documentar la API usando swagger.
  RTA: Se registra Swagger en  para el proyecto
  
#### 1.3. Usar patrones (ejemplo: mediator pattern, repository pattern, cqrs, etc).
  RTA: En este prueba se utilizan finalmente los patrones Mediator, UnitOfWork y CQRS.
  UnitOfWork para asegurar un conjunto de operaciones se ejecuten correctamente.
  Mediator para registrar la comunicación entre los commands, queries y sus respectivos handlers. De este modo se pueden injectar todos los objetos queries y handlres.
  CQRS se implementa con los Querys y handlers.
  
#### 1.4. Aplicar principios SOLID y Clean Code.
  -Se implementa un arquitectura limpia que es Domain-Driven-Desing (DDD). Se crean las capas de Dominio, Aplicación e infraestructura, todo estos siguiendo fielmente los principios de DDD.
  -Se puede evidenciar la utilización de principios SOLID en la inyección de dependencia. Cuando creamos el modelo *public sealed class Product* estoy utilizando uno de los principios solid que es el Single Responsability 
   Simple que me asegura que no va ser posible que otra clase herede de la clase de dominio product.
  -Siguiendo los principios de ddd notamos que las propiedades de la entidad product será accesible desde el exterior, pero solamente internamente se podrá setear o modificar(private set)
  -Se utilizan Object values por ejemplo para el Price y Currency. En conclusión se crea una entidad enriquecida.
  -entre otros

#### 1.5. Implementar la solución haciendo uso de TDD.
  -Prodía haber utilizado pruebas unitarias en Net Core que es muy fácil de usar, pero por temas de tiempo no se logra

#### 1.6. Usar buenos patrones para las validaciones del Request, y además considerar los HTTP Status Codes en cada petición realizada.
  RTA: Para validar los request se usa Fluentvalidators(Solo se valida que el campo no venga vacío) para Name, Description, entre otros.
       Los response con sus respectivos códigos usamos la interfaz IActionResult
       
#### 1.7. Estructurar el proyecto en N-capas.
  RTA: Se implementa DDD y se crean los proyecto Domain, Application, Infrastructure y la Api Web
  
#### 1.8. Agregar un archivo readme (README.md)
  OK
  
#### 1.9. Subir el proyecto a github de manera pública.
  OK
  
#### 2.1. Realizar Insert(POST), Update(PUT) y GetById(GET) de un maestro de productos.
  RTA: Se adjunta collección de POSTMAN PruebaTektonMarketPlus
  
#### 2.2. Loguear el tiempo de respuesta de cada request hecho en un archivo detexto plano.
  RTA: Logeo el tiempo de respuesta en un middleware personalizado llamado RequestTimeMiddleware.cs que me permitirá interceptar las solicitudes y sus respuestas. Este tiempo queda guardado en el archivo       
       request_time_log.txt en la carpeta del proyecto MarketPlus.Api
       
#### 2.3. Mantener en caché(5 min) un diccionario de estados del producto, cuyos valores son mostrados en el siguiente cuadro
  RTA: Para almacenar el diccionario en el cache utilizamos IMemoryCache dede la capa de infraestructura y lo inicializamos en Program.cs.
  NOTA: No olvidar que el caché solo dura 5 minutos
  
#### 2.4 Grabar la información del producto localmente
  RTA: Se graba en una bd local de SQlite llamada dbSqlite.db
  
#### 2.5 El método GetById debe retornar un producto con los siguientes campos:
  RTA: Se retorna según lo indicado. Sin embargo, por motivos de tiempo, para obtener el porcentaje de descuento genero un número aleatorio. Con un poco mas de tiempo, siguiendo los principios de DDD, el llamado al 
  servicio para obtener dicho valor se debería realizar desde la capa de infraestructura

### Notas Adicionales
1. Se utiliza code first, se configura la entidad product
2. Se crea una pequeña auditoria para identificar la fecha en que se crea un registro, se elimina o se modifica. Por eso las propiedades CreatedAt, UpdatedAt y DeletedAt de la entidad Product
3. Se adjunta una colección de POSTMAN al repo llamado PruebaTektonMarketPlus para facilitar las pruebas.

### Levantar el Proyecto
  Opción 1: Debería bastar con solo mapear el proyecto, abrirlo con Visual Studio y ejecutarlo. Asegurarse de tener instalado NET CORE 8
  Opción 2: Desde una consola y despues de mapeado el proyecto acceder al folder MarketPlus y ejecutar el comando *dotnet run --project MarketPlus/MarketPlus.Api*

Como se mencionó anteriormente el proyecto tiene seeders y ya que hay una BD local, no deberían tener problema para probar los servicios desde POSTMAN

### No dudar en escribirme en caso de problemas con la ejecución.
