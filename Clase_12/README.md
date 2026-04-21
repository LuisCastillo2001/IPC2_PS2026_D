# Clase_12 - API JWT (Bearer) + CRUD

API sencilla con `Models/`, `Services/` y `Controllers/`, protegida con token JWT (Bearer).

## Ejecutar

```bash
cd Clase_12
dotnet restore
dotnet run
```

En consola verás algo como:

- `Now listening on: http://localhost:5032`

Usa esa URL como base.

## 1) Obtener Bearer Token

Endpoint:

- `POST /api/auth/login`

En Postman:

- Method: `POST`
- URL: `http://localhost:5032/api/auth/login`
- Headers:
  - `Content-Type: application/json`
- Body → raw → JSON:

```json
{
  "username": "admin",
  "password": "admin123"
}
```

Respuesta (200):

```json
{
  "accessToken": "<jwt>",
  "tokenType": "Bearer",
  "expiresInSeconds": 3600
}
```

## 2) Usar el token en endpoints protegidos (CRUD Productos)

Todos los endpoints bajo `api/productos` requieren header:

- `Authorization: Bearer <jwt>`

En Postman, crea una variable (opcional) llamada `token` con el valor del `accessToken`.
Luego usa el header:

- `Authorization: Bearer {{token}}`

### GET /api/productos

- Method: `GET`
- URL: `http://localhost:5032/api/productos`
- Headers:
  - `Authorization: Bearer {{token}}`

### GET /api/productos/{id}

- Method: `GET`
- URL: `http://localhost:5032/api/productos/1`
- Headers:
  - `Authorization: Bearer {{token}}`

### POST /api/productos

- Method: `POST`
- URL: `http://localhost:5032/api/productos`
- Headers:
  - `Authorization: Bearer {{token}}`
  - `Content-Type: application/json`
- Body → raw → JSON:

```json
{
  "nombre": "Borrador",
  "precio": 2.75,
  "stock": 50
}
```

### PUT /api/productos/{id}

- Method: `PUT`
- URL: `http://localhost:5032/api/productos/1`
- Headers:
  - `Authorization: Bearer {{token}}`
  - `Content-Type: application/json`
- Body → raw → JSON:

```json
{
  "nombre": "Cuaderno (rayado)",
  "precio": 13.0,
  "stock": 8
}
```

Respuesta esperada: `204 No Content`

### DELETE /api/productos/{id}

- Method: `DELETE`
- URL: `http://localhost:5032/api/productos/1`
- Headers:
  - `Authorization: Bearer {{token}}`

Respuesta esperada: `204 No Content`

## Códigos HTTP que maneja

- `200 OK`: lecturas exitosas (login, GET).
- `201 Created`: creación exitosa (POST), devuelve el recurso y `Location`.
- `204 No Content`: actualización/eliminación exitosa (PUT/DELETE).
- `400 Bad Request`: validación fallida (campos requeridos, rangos, etc.).
- `401 Unauthorized`: token faltante/inválido o credenciales inválidas en login.
- `404 Not Found`: recurso no existe (por id).
- `500 Internal Server Error`: configuración de Auth/JWT faltante en `appsettings.json`.

## Configuración

- Credenciales demo: ver `appsettings.json` en `Auth:Username` y `Auth:Password`.
- JWT: ver `appsettings.json` en `Jwt:*`.


