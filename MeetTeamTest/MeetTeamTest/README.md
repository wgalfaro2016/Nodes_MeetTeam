# Simulación de Sistema Distribuido

Este proyecto es una simulación simple de un sistema distribuido en C#, donde múltiples nodos intercambian mensajes, simulan fallos, particiones de red y alcanzan consenso sobre un estado compartido.

## Estructura del Proyecto

- `Nodes/`
  - `Nodo.cs`: Representa un nodo dentro del sistema.
  - `GestorDePropuestas.cs`: Administra las propuestas de estado y evalúa el consenso.
  - `GestorDeVecinos.cs`: Gestiona la conexión con otros nodos.
  - `GestorDeParticiones.cs`: Simula particiones de red entre nodos.
  - `RegistroDeNodo.cs`: Mantiene un registro de eventos ocurridos en el nodo.
- `Simulador.cs`: Punto de entrada del programa. Contiene la lógica de simulación.
- `README.md`: Este archivo.

## Funcionalidades

- Propuesta de estados por parte de nodos individuales.
- Comunicación entre nodos para compartir propuestas.
- Evaluación de consenso por mayoría.
- Simulación de fallas (nodos inactivos).
- Simulación de particiones de red (aislamiento entre nodos).
- Registro legible de todos los eventos ocurridos por nodo.

## Cómo Ejecutar

1. Clona el repositorio o descarga los archivos.
2. Abre el proyecto en Visual Studio o VS Code.
3. Compila y ejecuta el archivo `Simulador.cs`.

## Ejemplo de Salida

Al ejecutar la simulación, verás en consola una bitácora de eventos como:

