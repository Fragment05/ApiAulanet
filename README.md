# API de Consulta de Datos

##  Descripción
API desarrollada en ASP.NET para la consulta y gestión de datos mediante endpoints HTTP.
Permite acceder a información almacenada en una base de datos SQL Server, facilitando la integración 
con aplicaciones frontend o servicios externos.

##  Tecnologías utilizadas
- C#
- ASP.NET Web API
- SQL Server

## Instalación

1. Clonar el repositorio:
   git clone https://github.com/Fragment0s/ApiAulanet

2. Configurar la cadena de conexión en:
   launchSettings.json


##  Base de datos

Los scripts se encuentran en la carpeta "/database" del proyecto 
-AulaNet_Nahuatl

##  Uso de la API

La API expone los siguientes endpoints:

###  Ejemplo:

#### GET api/resultados/individual?idUsuario=1&idLeccion=2
Obtiene el puntaje, las preguntas de la lección ,respuestas correctas y las que se respondieron

#### GET api/resultados/ranking?idLeccion=2
Obtiene a los usuarios de una de las lecciones tomando Nombre, Puntaje y Tiempo


##  Pruebas

####Puedes probar la API con:
- Swagger 
- Postman

