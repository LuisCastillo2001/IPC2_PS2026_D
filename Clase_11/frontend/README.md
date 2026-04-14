# Frontend - Gestión de Clientes y Facturas

## Descripción

Frontend en Razor Pages (.NET 10.0) que consume la API de gestión de clientes y facturas.

## Características

- ✅ **Gestión de Clientes**
  - Listar todos los clientes
  - Crear nuevos clientes
  - Editar información de clientes existentes
  - Eliminar clientes

- ✅ **Gestión de Facturas**
  - Listar todas las facturas
  - Crear nuevas facturas
  - Ver detalles de facturas
  - Agregar líneas a facturas
  - Eliminar facturas

- ✅ **Interfaz Responsiva**
  - Navegación intuitiva
  - Diseño moderno con Bootstrap 5
  - Tablas interactivas

## Requisitos

- .NET 10.0 SDK
- Backend ejecutándose en `http://localhost:5000`

## Instalación y Ejecución

### 1. Instalar dependencias
```bash
cd frontend
dotnet restore
```

### 2. Ejecutar el proyecto
```bash
dotnet run
```

El frontend estará disponible en: `https://localhost:7048` o `http://localhost:5001`

### 3. Asegúrate que el backend esté corriendo

El backend debe estar ejecutándose en `http://localhost:5000/api` para que el frontend funcione correctamente.

## Estructura del Proyecto

```
frontend/
├── Pages/
│   ├── Index.cshtml                 # Página de inicio con resumen
│   ├── Index.cshtml.cs             
│   ├── _ViewStart.cshtml
│   ├── _ViewImports.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml           # Layout principal
│   ├── Clientes/
│   │   ├── Index.cshtml             # Listar clientes
│   │   ├── Index.cshtml.cs
│   │   ├── Crear.cshtml             # Crear cliente
│   │   ├── Crear.cshtml.cs
│   │   ├── Editar.cshtml            # Editar cliente
│   │   ├── Editar.cshtml.cs
│   │   └── Eliminar.cshtml.cs       # Eliminar cliente
│   └── Facturas/
│       ├── Index.cshtml             # Listar facturas
│       ├── Index.cshtml.cs
│       ├── Crear.cshtml             # Crear factura
│       ├── Crear.cshtml.cs
│       ├── Detalles.cshtml          # Ver y editar factura
│       ├── Detalles.cshtml.cs
│       └── Eliminar.cshtml.cs       # Eliminar factura
├── Program.cs                       # Configuración principal
├── appsettings.json                # Configuración
├── appsettings.Development.json    # Configuración desarrollo
├── Frontend.csproj                  # Archivo de proyecto
└── Properties/
    └── launchSettings.json          # Configuración de lanzamiento
```

## Endpoints de la API Consumidos

### Clientes
- `GET /api/clientes` - Obtener todos los clientes
- `GET /api/clientes/{id}` - Obtener cliente por ID
- `POST /api/clientes` - Crear nuevo cliente
- `PUT /api/clientes/{id}` - Actualizar cliente
- `DELETE /api/clientes/{id}` - Eliminar cliente

### Facturas
- `GET /api/facturas` - Obtener todas las facturas
- `GET /api/facturas/{id}` - Obtener factura por ID
- `POST /api/facturas` - Crear nueva factura
- `PUT /api/facturas/{id}` - Actualizar factura
- `DELETE /api/facturas/{id}` - Eliminar factura
- `POST /api/facturas/{id}/lineas` - Agregar línea a factura

## Nota Importante

- Sin variables con prefijo `_`
- Sin tipos nullable con `?`
- Naming en camelCase para consistencia
- Bootstrap 5 para estilos
- HttpClient Factory pattern para comunicación con API

## Autor

Desarrollado para IPC2 - Clase 11 - 2026
