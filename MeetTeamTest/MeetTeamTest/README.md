# Simulación de Sistema Distribuido

Este proyecto es una simulación simple de un sistema distribuido en C#, donde múltiples nodos intercambian mensajes y alcanzan consenso sobre un estado compartido.

## Estructura del proyecto

- `Nodes/`: Contiene las clases `Nodo` y `GestorDePropuestas`.
- `Simulador.cs`: Punto de entrada del programa con la lógica de simulación.
- `README.md`: Este archivo.

## Funcionalidades

- Simulación de nodos que proponen y reciben estados.
- Implementación de consenso (por mayoría).
- Simulación de fallas y particiones de red.
- Registro de eventos y estados por nodo.

## Cómo ejecutar

1. Clona el repositorio o descarga los archivos.
2. Abre el proyecto en Visual Studio o VS Code.
3. Compila y ejecuta `Simulador.cs`.

