# Minuta de Relevamiento - Choisium

## 1. Introducción

Choisium es una aplicación orientada a la toma de decisiones inteligentes, que permite a los usuarios organizar, analizar y comparar distintas alternativas frente a un problema determinado.

El sistema está diseñado como una API RESTful, enfocada en la gestión de proyectos de decisión, donde cada proyecto contiene tareas y opciones evaluables.

---

## 2. Objetivo del sistema

El objetivo principal de Choisium es brindar una herramienta que facilite la toma de decisiones mediante la organización estructurada de opciones y la asignación de puntajes que permitan determinar la mejor alternativa disponible.

---

## 3. Actores

* **Usuario**: persona que utiliza el sistema para crear proyectos, definir tareas y evaluar opciones.

---

## 4. Funcionalidades principales

El sistema deberá permitir:

### Gestión de usuarios

* Registro de usuarios
* Consulta de información de usuario

### Gestión de proyectos

* Crear proyectos de decisión
* Modificar datos del proyecto
* Eliminar proyectos
* Listar proyectos de un usuario

### Gestión de tareas

* Crear tareas dentro de un proyecto
* Modificar tareas
* Eliminar tareas
* Listar tareas de un proyecto

### Gestión de opciones

* Agregar opciones a una tarea
* Modificar opciones
* Eliminar opciones
* Asignar puntaje (score) a cada opción

### Evaluación de decisiones

* Obtener la mejor opción de una tarea en base al mayor puntaje asignado

---

## 5. Modelo conceptual

El sistema se basa en una estructura jerárquica:

* Un usuario puede tener múltiples proyectos
* Un proyecto puede contener múltiples tareas
* Una tarea puede tener múltiples opciones

Cada opción posee un puntaje que permite determinar la mejor alternativa dentro de una tarea.

---

## 6. Alcance

El sistema se limita a la gestión de decisiones mediante puntajes definidos manualmente por el usuario, sin incluir inteligencia artificial ni cálculos avanzados, por el hecho de que es un proyecto que pretende ser academico.

---

## 7. Consideraciones

* La lógica de negocio se implementará en la capa de aplicación siguiendo el patrón Clean Architecture.
* El sistema prioriza simplicidad, claridad y mantenibilidad.