El objetivo de esta solución es realizar la logica detras de un Libro de Contactos (solo backend).
La Solución se divide en 4 sub-proyectos:

- API 
- CORE
- DATA
- APITEST

<API> En este proyecto encontramos el controlador principal de la Api este se encarga de realizar las consultas a la base de datos mediante el metodo HTTP (Get, Put, Post, Delete), este proyecto inyecta las siguientes dependecias [CORE], [DATA].
Además en el archivo appsettings.json encontramos el connection string a la base de datos MySql que es utilizado en el archivo Startup.cs,
en este archivo de ejecucion automatica al iniciar, en este mismo archivo se declaran la utilización de los repositorios utilizados en el proyecto CORE.

<CORE> En este proyecto se utiliza la inyeccion de dependencia al proyecto DATA, en este encontramos el repositorio de los servicios de contacto, 
tenemos la interfaz y la implementacion correspondiente que utiliza la interfaz y el contexto de la base de datos para crear la logica detras del controlador.

<DATA> En el proyecto encontramos el contexto de nuestra base de datos que utiliza los modelos de contacto y ciudad para crear una relación entre ellos mediante una clave foranea. 
Luego se crea la migracion correspondiente y se sube la actualizacion a la base de datos.

<APITEST> En este proyecto utilizo MStest para realizar testeos unitarios de cada metodo del controlador. Este proyecto inyecta dependecias de los 3 proyectos (API, DATA, CORE).

