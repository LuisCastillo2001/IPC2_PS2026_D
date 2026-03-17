# Ejemplo Web: Lista Enlazada Simple con Razor Pages

Este proyecto muestra un ejemplo sencillo de lista enlazada simple para peliculas usando ASP.NET Core Razor Pages.

No se usa JavaScript.
No se usan arreglos, listas, diccionarios u otra coleccion nativa para guardar los datos.
El almacenamiento se hace con nodos enlazados.

## Estructura

- `Models/Pelicula.cs`
  - Representa la entidad pelicula.
  - Campos: `Titulo`, `Director`, `Anio`.

- `Models/Nodo.cs`
  - Representa un nodo de la lista.
  - Campos: `Pelicula`, `Siguiente`.

- `Estructuras/ListaEnlazadaSimple.cs`
  - Implementa la lista enlazada.
  - Tiene `Raiz` como primer nodo.
  - Metodos:
    - `append(Nodo nuevoNodo)`: agrega un nodo al final.
    - `print()`: recorre la lista y devuelve un texto con todas las peliculas.
    - `pop()`: elimina el ultimo nodo.
    - `reset()`: vacia la lista.

- `Servicios/ListaEnlazadaService.cs`
  - Es un servicio simple para usar la lista desde Razor Pages.
  - Crea nodos y peliculas para delegar a la estructura enlazada.

- `Pages/Index.cshtml`
  - Vista principal.
  - Tiene formularios para:
    - Agregar pelicula (`append`).
    - Eliminar ultimo nodo (`pop`).
    - Limpiar lista (`reset`).
  - Muestra el recorrido de la lista con `while`.
  - Muestra la salida de `print()`.

- `Pages/VerLista.cshtml`
  - Vista solo para lectura del contenido de la lista.
  - Muestra el recorrido nodo por nodo y la salida de `print()`.

- `Pages/VerLista.cshtml.cs`
  - Logica de lectura de la lista para la pagina `VerLista`.

- `Pages/Index.cshtml.cs`
  - Logica del PageModel.
  - Handlers:
    - `OnPostAgregar()`
    - `OnPostEliminarUltimo()`
    - `OnPostLimpiar()`
  - Carga `Raiz` y `TextoLista` para pintar la vista.

## Flujo Basico (CRUD sencillo)

- Create: formulario para agregar pelicula.
- Read: visualizacion de nodos en pantalla y texto de `print()`.
- Delete: eliminar ultimo nodo con `pop()` o limpiar toda la lista con `reset()`.
- Update: no se implementa para mantener el ejemplo enfocado en los metodos solicitados.

## Navegacion y estilo (simple)

- Se agregaron direcciones internas con anclas en la pagina principal para ir rapido a:
  - agregar pelicula
  - acciones de eliminar y limpiar
  - recorrido de la lista
  - referencias
- Se mejoro el estilo visual con tarjetas, botones y secciones para que sea mas agradable.
- Todo sigue en Razor Pages sin JavaScript.

## Referencias de paginas

En la vista principal hay una seccion de referencias para practicar navegacion Razor:

- `/Index`
- `/VerLista`
- `/Privacy`
- `/Error`

## Ejecutar

1. Restaurar y compilar:
   - `dotnet build`
2. Ejecutar:
   - `dotnet run`
3. Abrir en navegador la URL que muestre la consola.

## Objetivo didactico

Este ejemplo esta pensado para practicar:

- Uso de nodos enlazados en C#.
- Recorridos con `while`.
- Uso de Razor Pages sin JavaScript.
- Separacion basica por carpetas (modelo, estructura, servicio y pagina).
