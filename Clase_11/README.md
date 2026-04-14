# Clase 11 - Sistema de Facturación

## Descripción

Es una aplicación completa con:
- **Frontend**: Razor Pages (C#) en puerto 7001 (https) / 5002 (http)
- **Backend**: Web API (C#) en puerto 5001 (https) / 5000 (http)
- **Comunicación**: JSON HTTP usando `HttpClient` y `HttpClientFactory`

## Estructura del Proyecto

```
Clase_11/
├── backend/          # Web API REST
│   ├── Controllers/  # Endpoints de API
│   ├── Models/       # Entidades
│   ├── Services/     # Lógica de negocio
│   └── Program.cs    # Configuración
└── frontend/         # Razor Pages
    ├── Pages/        # Páginas Razor
    ├── Models/       # DTOs
    └── wwwroot/      # Archivos estáticos
```

## Características Principales

### Clientes
- ✅ Ver lista de clientes
- ✅ Crear nuevo cliente (formulario)
- ✅ Importar clientes desde archivo de texto

### Facturas
- ✅ Ver lista de facturas
- ✅ Crear factura con líneas dinámicas
- ✅ Visualizar factura detallada
- ✅ Eliminar facturas

## Instalación y Ejecución

### 1. Backend (Web API)

```bash
cd backend
dotnet restore
dotnet run
```

El backend se ejecutará en:
- `https://localhost:5001` (HTTPS)
- `http://localhost:5000` (HTTP)

### 2. Frontend (Razor Pages)

En otra terminal:

```bash
cd frontend
dotnet restore
dotnet run
```

El frontend se ejecutará en:
- `https://localhost:7001` (HTTPS)
- `http://localhost:5002` (HTTP)

## Endpoints de API

### Clientes
- `GET /api/clientes` - Obtener todos los clientes
- `GET /api/clientes/{id}` - Obtener cliente por ID
- `POST /api/clientes` - Crear nuevo cliente
- `PUT /api/clientes/{id}` - Actualizar cliente
- `DELETE /api/clientes/{id}` - Eliminar cliente
- `POST /api/clientes/importar` - Importar clientes desde archivo

### Facturas
- `GET /api/facturas` - Obtener todas las facturas
- `GET /api/facturas/{id}` - Obtener factura por ID
- `GET /api/facturas/cliente/{clienteId}` - Obtener facturas de un cliente
- `POST /api/facturas` - Crear nueva factura
- `PUT /api/facturas/{id}` - Actualizar factura
- `DELETE /api/facturas/{id}` - Eliminar factura
- `POST /api/facturas/{id}/lineas` - Agregar línea a factura

## Importar Clientes desde Archivo

El archivo debe tener el siguiente formato (líneas separadas con |):
```
Nombre|Correo|Teléfono|Dirección
```

Ejemplo incluido: `clientes_ejemplo.txt`

Para importar:
1. Ve a la página "Clientes"
2. Haz clic en "Importar Clientes"
3. Selecciona un archivo de texto (.txt)
4. El sistema lo procesará y mostrará los resultados

## Tecnologías Utilizadas

- **Framework Web**: ASP.NET Core 10
- **Language**: C#
- **Backend**: Web API
- **Frontend**: Razor Pages
- **Cliente HTTP**: HttpClient con HttpClientFactory
- **Serialización**: System.Net.Http.Json

## Patrón de Comunicación

El frontend utiliza `HttpClientFactory` para realizar peticiones HTTP:

```csharp
// GET
var datos = await httpClient.GetFromJsonAsync<List<T>>("https://localhost:5001/api/endpoint");

// POST
var response = await httpClient.PostAsJsonAsync("https://localhost:5001/api/endpoint", objeto);

// DELETE
var response = await httpClient.DeleteAsync("https://localhost:5001/api/endpoint/{id}");
```

## Características de Diseño

- ✅ Variables sin underscore (_)
- ✅ Variables con nombres naturales
- ✅ Solo Razor Pages (sin AJAX)
- ✅ Comunicación JSON
- ✅ Interfaz limpia y responsive
- ✅ Manejo de errores
- ✅ Validación de datos

## Notas Importantes

1. **Puertos HTTPS**: Asegúrate de confiar en el certificado autofirmado de desarrollo
2. **CORS**: El backend permite peticiones desde `https://localhost:7001` y `http://localhost:5001`
3. **Base de Datos**: Actualmente usa listas en memoria (sin persistencia)
4. **Validaciones**: Se realizan en el frontend y en el backend

## Próximas Mejoras

- Base de datos SQL Server
- Autenticación y autorización
- Más opciones de reporte
- Exportación de facturas a PDF
- Búsqueda y filtros avanzados

---

**IPC2 - Primer Semestre 2026**
