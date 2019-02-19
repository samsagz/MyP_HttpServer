#MyP_HttpServer
Servidor HTTP 1.1
# UNIVERSIDAD EAFIT <h1>
## Realizado por : Ana Builes Arias - German Bedoya - Juan Fernando Zuluaga 
Este documento es una descripción de arquitectura (AD) para el proyecto caso de estudio Servidor Http 1.1. Está descripcion de arquitectura intenta dar algunos ejemplos de la arquitectura del caso de estudio y como los diferentes componentes de está se relacionan entre sí.

Este documento captura la arquitectura del caso de estudio Servidor Http 1.1 y el propósito es estudiar, analizar y documentar las decisiones claves en el diseño de la arquitectura del proyecto así como sus capacidades, la tecnología elegida y los requisitos identificados para los interesados en el caso de estudio.

## **VISTA DE REQUERIMIENTOS**

**Requerimientos Funcionales del caso de estudio**

1. El sistema debe de cumplir con el estándar HTTP/1.1 de 1999
2. El sistema debe de almacenar en un log todas las solicitudes hechas, sean correctas o incorrectas
3. El sistema debe de analizar la ruta ingresada y responder 200 si la ruta está correcta o 400 si la ruta no se encuentra o si hay algún error en ella.El sistema debe de controlar dos respuestas, OK con código 200 o Not Found 404

**Requerimientos No Funcionales del caso de estudio**

1. El sistema deberá ser eficiente, deberá soportar por lo menos 50 transacciones por segundo
2. El código del sistema debe ser bien organizado y legible
3. El sistema deberá ser mantenible en el tiempo

## **METAS DE CALIDAD**

En esta sección se hablará sobre los Atributos de Calidad objetivos en la arquitectura del caso de estudio

### **ATRIBUTOS DE CALIDAD**
** 1. CONFIABILIDAD **
El sistema debe ser tolerante a fallos.
** 2. MANTENIBILIDAD **
Ante cualquier fallo en el sistema este deberá ser de fácil identificación para su reparación en el menor tiempo posible

## **RESTRICCIONES DE LA ARQUITECTURA**
1. En la construcción del sevidor no se podrá realizar con frameworks, deberá ser una implementación desde cero en algún lenguaje de programación.
2. El servidor deberá estar en un repositorio en GitHub
3. El servidor deberá ser probado con postman o CURL

## **ESTRATEGIA DE LA SOLUCIÓN**

La estrategia de la solución por la cual se optó tras el análisis realizado para crear el servidor HTTP vr 1.1 es utilizar el lenguaje de programación XXX ya que con este lenguaje podemos tener un desarrollo ágil y sencillo, enfocándonos en la facilidad del codigo de estar organizado y legible para que cualquier persona pueda entenderlo

## **VISTA DE ALTO NIVEL**
## **DIAGRAMA DE FLUJO**
## **DIAGRAMA DE CLASES**

## **DECISIONES DE DISEÑO**

El servidor contará con dos tipos de verbos GET y POST. También incluirá las siguientes rutas para la visualización del usuario:

* localhost:8080/index.html
* localhost:8080/404.html

Adicional el servidor estará abierto en el puerto 8080.

### **RUTAS DEL CODIGO**

Repositorio : [GitHub]( https://github.com/samsagz/MyP_HttpServer )

## **REQUERIMIENTOS DE CALIDAD**
## **RIESGOS Y DEUDA TECNICA**
## **GLOSARIO**
