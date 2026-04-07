# CRUD Biblioteca - Documentación Postman

## Descripción
API REST para gestionar una biblioteca digital con operaciones completas de CRUD para libros.

## URL Base
```
http://localhost:5067/api/libros
```

---

## Endpoints

### 1. Obtener todos los libros
**Método:** `GET`  
**Ruta:** `/api/libros`

```
GET http://localhost:5067/api/libros
```

**Respuesta (200 OK):**
```json
[
  {
    "id": 1,
    "titulo": "Cien años de soledad",
    "autor": "Gabriel García Márquez",
    "isbn": "978-0-060-85328-8",
    "anoPublicacion": 1967,
    "genero": "Realismo Mágico",
    "paginas": 417,
    "precio": 45.99,
    "disponible": true
  },
  {
    "id": 2,
    "titulo": "Don Quijote",
    "autor": "Miguel de Cervantes",
    "isbn": "978-0-575-07889-2",
    "anoPublicacion": 1605,
    "genero": "Novela",
    "paginas": 992,
    "precio": 39.99,
    "disponible": true
  }
]
```

---

### 2. Obtener libro por ID
**Método:** `GET`  
**Ruta:** `/api/libros/{id}`

```
GET http://localhost:5067/api/libros/1
```

**Respuesta (200 OK):**
```json
{
  "id": 1,
  "titulo": "Cien años de soledad",
  "autor": "Gabriel García Márquez",
  "isbn": "978-0-060-85328-8",
  "anoPublicacion": 1967,
  "genero": "Realismo Mágico",
  "paginas": 417,
  "precio": 45.99,
  "disponible": true
}
```

**Respuesta (404 Not Found):**
```json
{
  "mensaje": "Libro con ID 999 no encontrado"
}
```

---

### 3. Obtener libros disponibles
**Método:** `GET`  
**Ruta:** `/api/libros/disponibles`

```
GET http://localhost:5067/api/libros/disponibles
```

**Respuesta (200 OK):**
```json
[
  {
    "id": 1,
    "titulo": "Cien años de soledad",
    "autor": "Gabriel García Márquez",
    "isbn": "978-0-060-85328-8",
    "anoPublicacion": 1967,
    "genero": "Realismo Mágico",
    "paginas": 417,
    "precio": 45.99,
    "disponible": true
  }
]
```

---

### 4. Buscar libros por autor
**Método:** `GET`  
**Ruta:** `/api/libros/buscar/autor/{autor}`

```
GET http://localhost:5067/api/libros/buscar/autor/García
```

**Respuesta (200 OK):**
```json
[
  {
    "id": 1,
    "titulo": "Cien años de soledad",
    "autor": "Gabriel García Márquez",
    "isbn": "978-0-060-85328-8",
    "anoPublicacion": 1967,
    "genero": "Realismo Mágico",
    "paginas": 417,
    "precio": 45.99,
    "disponible": true
  }
]
```

---

### 5. Buscar libros por género
**Método:** `GET`  
**Ruta:** `/api/libros/buscar/genero/{genero}`

```
GET http://localhost:5067/api/libros/buscar/genero/Misterio
```

**Respuesta (200 OK):**
```json
[
  {
    "id": 3,
    "titulo": "El Código Da Vinci",
    "autor": "Dan Brown",
    "isbn": "978-0-385-33312-0",
    "anoPublicacion": 2003,
    "genero": "Misterio",
    "paginas": 689,
    "precio": 29.99,
    "disponible": false
  }
]
```

---

### 6. Crear nuevo libro (CREATE)
**Método:** `POST`  
**Ruta:** `/api/libros`

**Headers:**
```
Content-Type: application/json
```

**Body (JSON):**
```json
{
  "titulo": "El Quijote de la Mancha",
  "autor": "Miguel de Cervantes",
  "isbn": "978-0-575-07889-3",
  "anoPublicacion": 1605,
  "genero": "Novela Clásica",
  "paginas": 1000,
  "precio": 35.50,
  "disponible": true
}
```

**Respuesta (201 Created):**
```json
{
  "id": 4,
  "titulo": "El Quijote de la Mancha",
  "autor": "Miguel de Cervantes",
  "isbn": "978-0-575-07889-3",
  "anoPublicacion": 1605,
  "genero": "Novela Clásica",
  "paginas": 1000,
  "precio": 35.50,
  "disponible": true
}
```

**Respuesta (400 Bad Request):**
```json
{
  "mensaje": "El título y autor son obligatorios"
}
```

---

### 7. Actualizar libro (UPDATE)
**Método:** `PUT`  
**Ruta:** `/api/libros/{id}`

**Headers:**
```
Content-Type: application/json
```

**Body (JSON):**
```json
{
  "titulo": "Cien años de soledad - Edición Especial",
  "autor": "Gabriel García Márquez",
  "isbn": "978-0-060-85328-8",
  "anoPublicacion": 1967,
  "genero": "Realismo Mágico",
  "paginas": 417,
  "precio": 49.99,
  "disponible": false
}
```

**Respuesta (200 OK):**
```json
{
  "id": 1,
  "titulo": "Cien años de soledad - Edición Especial",
  "autor": "Gabriel García Márquez",
  "isbn": "978-0-060-85328-8",
  "anoPublicacion": 1967,
  "genero": "Realismo Mágico",
  "paginas": 417,
  "precio": 49.99,
  "disponible": false
}
```

**Respuesta (404 Not Found):**
```json
{
  "mensaje": "Libro con ID 999 no encontrado"
}
```

---

### 8. Eliminar libro (DELETE)
**Método:** `DELETE`  
**Ruta:** `/api/libros/{id}`

```
DELETE http://localhost:5067/api/libros/3
```

**Respuesta (200 OK):**
```json
{
  "mensaje": "Libro con ID 3 eliminado exitosamente"
}
```

**Respuesta (404 Not Found):**
```json
{
  "mensaje": "Libro con ID 999 no encontrado"
}
```

---

## Guía para usar en Postman

### Pasos para importar y probar:

1. **Abre Postman**
2. **Crea una nueva colección** (Collections > + New Collection)
3. **Copia cada endpoint** y crea una nueva request en Postman

### Configuración básica:

1. **Método HTTP:** Selecciona GET, POST, PUT, DELETE según corresponda
2. **URL:** Ingresa la dirección del endpoint
3. **Headers:** Para POST y PUT, añade:
   ```
   Key: Content-Type
   Value: application/json
   ```
4. **Body:** Para POST y PUT, selecciona "raw" y elige "JSON"

### Ejemplo paso a paso (Crear un nuevo libro):

1. Click en `+` para nueva request
2. Cambia el método a `POST`
3. URL: `http://localhost:5067/api/libros`
4. Ve a la pestaña "Body"
5. Selecciona "raw" y cambia de "Text" a "JSON"
6. Copia el JSON del libro:
```json
{
  "titulo": "La Revolución del Código",
  "autor": "John Doe",
  "isbn": "978-0-000-00000-0",
  "anoPublicacion": 2024,
  "genero": "Tecnología",
  "paginas": 350,
  "precio": 55.00,
  "disponible": true
}
```
7. Click en "Send"

---

## Resumen de Operaciones

| Operación | Método | Ruta | Descripción |
|-----------|--------|------|-------------|
| Listar todos | GET | `/api/libros` | Obtiene todos los libros |
| Obtener por ID | GET | `/api/libros/{id}` | Obtiene un libro específico |
| Disponibles | GET | `/api/libros/disponibles` | Libros disponibles |
| Buscar por autor | GET | `/api/libros/buscar/autor/{autor}` | Busca por nombre del autor |
| Buscar por género | GET | `/api/libros/buscar/genero/{genero}` | Busca por género |
| Crear | POST | `/api/libros` | Crea un nuevo libro |
| Actualizar | PUT | `/api/libros/{id}` | Actualiza un libro existente |
| Eliminar | DELETE | `/api/libros/{id}` | Elimina un libro |

---

## Estructura del Proyecto

```
Clase_10/
├── Models/
│   └── Libro.cs              # Modelo de datos
├── Services/
│   └── BibliotecaService.cs  # Lógica de negocio
├── Controllers/
│   └── LibrosController.cs   # Endpoints de la API
├── Program.cs                # Configuración
└── appsettings.json          # Configuración de la aplicación
```

---

## Notas Importantes

- La API utiliza listas de C# (`List<T>`) en memoria, los datos se pierden al reiniciar
- Todos los IDs son generados automáticamente
- El campo `disponible` indica si el libro está disponible para préstamo
- Los búsquedas son insensibles a mayúsculas/minúsculas
