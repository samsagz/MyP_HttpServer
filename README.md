# MyP_HttpServer 
Servidor HTTP 1.1

# UNIVERSIDAD EAFIT <h1>
### Realizado por : Ana Builes Arias - German Bedoya - Juan Fernando Zuluaga 
  
Este documento es una descripción de arquitectura (AD) para el proyecto caso de estudio Servidor Http 1.1. Está descripcion de arquitectura intenta dar algunos ejemplos de la arquitectura del caso de estudio y como los diferentes componentes de está se relacionan entre sí.

Este documento captura la arquitectura del caso de estudio Servidor Http 1.1 y el propósito es estudiar, analizar y documentar las decisiones claves en el diseño de la arquitectura del proyecto así como sus capacidades, la tecnología elegida y los requisitos identificados para los interesados en el caso de estudio.


## **VISTA DE REQUERIMIENTOS**


| **#** | **Descripción de los Requerimientos Funcionales**  |
| :-: |:---------------------------------------------------------------------------------------------------|
| 1 | El sistema debe de cumplir con el estándar HTTP/1.1 de 1999 |
| 2 | El sistema debe de almacenar en un log todas las solicitudes hechas, sean correctas o incorrectas |
| 3 | El sistema debe de analizar la ruta ingresada y responder 200 si la ruta está correcta o 404 si la ruta no se encuentra |

  
| **#** | **Descripción de los Requerimientos No Funcionales**  |
| :-: |:---------------------------------------------------------------------------------------------------|
| 1 | El sistema deberá ser eficiente, deberá soportar por lo menos 50 transacciones por segundo |
| 2 | El código del sistema debe ser bien organizado y legible |
| 3 | El sistema deberá ser mantenible en el tiempo |
  
## **METAS DE CALIDAD**

En esta sección se hablará sobre los Atributos de Calidad objetivos en la arquitectura del caso de estudio
  
### **ATRIBUTOS DE CALIDAD**
**1. CONFIABILIDAD**
El sistema debe ser tolerante a fallos.
<p>
  
**2. MANTENIBILIDAD**
Ante cualquier fallo en el sistema este deberá ser de fácil identificación para su reparación en el menor tiempo posible
  
## **RESTRICCIONES DE LA ARQUITECTURA**

1. En la construcción del sevidor no se podrá realizar con frameworks, deberá ser una implementación desde cero en algún lenguaje de programación.
2. El servidor deberá estar en un repositorio en GitHub
3. El servidor deberá ser probado con postman o CURL
  
## **ESTRATEGIA DE LA SOLUCIÓN**

La estrategia de la solución por la cual se optó tras el análisis realizado para crear el servidor HTTP vr 1.1 es utilizar el lenguaje de programación C# ya que con este lenguaje podemos tener un desarrollo ágil y sencillo, enfocándonos en la facilidad del codigo para estar organizado y legible para que cualquier persona pueda entenderlo. Además, se considera que este lenguaje de programación tiene una curva de aprendizaje menos pronunciada debido a que el equipo de desarrollo tiene dominio en este lenguaje.
  
## **VISTA DE ALTO NIVEL**

<img align="center" src="https://github.com/samsagz/MyP_HttpServer/blob/master/Diagramas/VistaDeAltoNivel.png" >
<p>

## **DIAGRAMA DE FLUJO**

<img align="center" src="https://github.com/samsagz/MyP_HttpServer/blob/master/Diagramas/DiagramaDeFlujo.png">
<p>
  
## **DIAGRAMA DE CLASES**

<img align="center" src="https://github.com/samsagz/MyP_HttpServer/blob/master/Diagramas/DiagramaDeClases.jpg">
<p>

## **DECISIONES DE DISEÑO**

El servidor contará con dos tipos de verbos GET y POST. También incluirá las siguientes rutas para la visualización del usuario:

* localhost:8080/index.html
* localhost:8080/404.html

Adicional el servidor estará abierto en el puerto 8080.

## **RUTAS DEL CODIGO**

Repositorio : [MyP_HttpServer]( https://github.com/samsagz/MyP_HttpServer )

## **CASOS DE PRUEBA**

| **ID** | **NOMBRE DEL CASO DE PRUEBA**  | **OBJETIVOS DEL CASO DE PRUEBA**  |
| :-: |:--------------------------------------------------| :--------------------------------------------------------------|
| UT001 | Validar estructura header | Validar que la estructura del header corresponda a la definida. |
| UT002 | Verificar la respuesta de error | Al momento de no existir una url ingresada, responder correctamente con el mensaje 404 |
| UT003 | Verificar la escritura del log | Al momento de realizar una solicitud, se debe de crear un archivo .txt con la peticion y las caracteristicas de la misma |


## **GLOSARIO**

| TERMINO | DESCRIPCIÓN  |
| :-: |:---------------------------------------------------------------------------------------------------|
| Http | Un servidor web brinda soporte para HTTP (Hypertext Transfer Protocol ó  Protocolo de Transferencia de Hipertexto). Como su nombre lo indica, HTTP especifica cómo transferir hypertext (es decir, documentos web vinculados) entre dos computadoras. Un protocolo es un conjunto de reglas para la comunicación entre dos computadoras. HTTP es un protocolo textual, sin estado. (https://developer.mozilla.org/es/docs/Learn/Common_questions/Que_es_un_servidor_WEB) |
| Socket | Un socket (enchufe), es un método para la comunicación entre un programa del cliente y un programa del servidor en una red. Un socket se define como el punto final en una conexión. (http://www.masadelante.com/faqs/socket)|

## **BIBLIOGRAFIA**
[HTTP Server: Everything you need to know to Build a simple HTTP server from scratch](https://medium.com/from-the-scratch/http-server-what-do-you-need-to-know-to-build-a-simple-http-server-from-scratch-d1ef8945e4fa), Skrew Everything, Mar 16, 2018
