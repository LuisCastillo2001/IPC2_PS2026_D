# Guía Rápida - Frontend Razor Pages

## 🚀 Iniciar Rápido

```bash
# 1. En terminal 1: Backend
cd backend && dotnet run

# 2. En terminal 2: Frontend
cd frontend && dotnet run

# 3. Abre navegador: http://localhost:5001
```

---

## 📍 URLs Principales

| Página | URL | Descripción |
|--------|-----|-------------|
| Inicio | `/` | Dashboard con resumen |
| Clientes | `/Clientes` | Listar clientes |
| Crear Cliente | `/Clientes/Crear` | Formulario nuevo cliente |
| Editar Cliente | `/Clientes/Editar/{id}` | Formulario editar cliente |
| Facturas | `/Facturas` | Listar facturas |
| Crear Factura | `/Facturas/Crear` | Crear nueva factura |
| Detalles Factura | `/Facturas/Detalles/{id}` | Ver y editar factura |

---

## 🔌 Comunicación con API

Todos los endpoints base en: `http://localhost:5000/api`

### Configuración en Program.cs
```csharp
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
```

---

## 📦 Estructura de Modelos

### Objeto Cliente
```json
{
  "id": 1,
  "nombre": "Juan Pérez",
  "correo": "juan@example.com",
  "telefono": "7804-5123",
  "direccion": "Avenida 9, Zona 10",
  "fechaRegistro": "2026-04-14T10:30:00"
}
```

### Objeto Factura
```json
{
  "id": 1,
  "clienteId": 1,
  "cliente": { /* objeto Cliente */ },
  "fecha": "2026-04-14T10:30:00",
  "total": 2800.00,
  "lineas": [
    {
      "id": 1,
      "descripcion": "Asesoría",
      "cantidad": 1,
      "precioUnitario": 1500.00
    }
  ]
}
```

### Objeto Línea Factura
```json
{
  "id": 1,
  "descripcion": "Servicio de consultoría",
  "cantidad": 2,
  "precioUnitario": 500.00
}
```

---

## 🎯 Patrones de Código

### Inyección de HttpClient
```csharp
private readonly IHttpClientFactory httpClientFactory;

public MiModelo(IHttpClientFactory httpClientFactory)
{
    this.httpClientFactory = httpClientFactory;
}
```

### GET - Obtener Datos
```csharp
public async Task OnGetAsync()
{
    HttpClient client = httpClientFactory.CreateClient("ApiClient");
    List<ClienteItem> clientes = await client.GetFromJsonAsync<List<ClienteItem>>("clientes");
}
```

### POST - Crear
```csharp
public async Task<IActionResult> OnPostAsync()
{
    HttpClient client = httpClientFactory.CreateClient("ApiClient");
    var objeto = new { nombre = "Juan", correo = "juan@test.com" };
    HttpResponseMessage response = await client.PostAsJsonAsync("clientes", objeto);
    if (response.IsSuccessStatusCode) return RedirectToPage();
}
```

### PUT - Actualizar
```csharp
var actualizado = new { nombre = "Juan Actualizado" };
HttpResponseMessage response = await client.PutAsJsonAsync($"clientes/{id}", actualizado);
```

### DELETE - Eliminar
```csharp
HttpResponseMessage response = await client.DeleteAsync($"clientes/{id}");
```

---

## 🎨 Razor Pages Basics

### Binding de Propiedades
```csharp
[BindProperty]
public string Nombre { get; set; } = string.Empty;
```

```html
<input type="text" name="nombre" />
```

### Métodos de Página
```csharp
public async Task OnGetAsync()  // GET
public async Task OnPostAsync() // POST
```

### Redirigir a Página
```csharp
return RedirectToPage("/Clientes/Index");
return RedirectToPage(new { id = 5 });
```

### TempData para Mensajes
```csharp
TempData["Mensaje"] = "Guardado correctamente";
return RedirectToPage();

// Otro modelo
public async Task OnGetAsync()
{
    Mensaje = TempData["Mensaje"] as string;
}
```

---

## 🛡️ Validación

### En C#
```csharp
if (string.IsNullOrWhiteSpace(Nombre))
{
    Error = "El nombre es requerido";
    return Page();
}
```

### En HTML
```html
<input type="text" name="nombre" required />
<input type="number" min="1" name="cantidad" required />
<input type="email" name="correo" />
```

---

## 🎨 Bootstrap 5 Clases Útiles

```html
<!-- Container -->
<div class="container">

<!-- Filas y Columnas -->
<div class="row">
  <div class="col-md-6">Mitad</div>
  <div class="col-md-6">Mitad</div>
</div>

<!-- Tablas -->
<table class="table table-striped table-hover">
  <thead class="table-dark">
    <tr><th>Encabezado</th></tr>
  </thead>
  <tbody>
    <tr><td>Dato</td></tr>
  </tbody>
</table>

<!-- Cards -->
<div class="card">
  <div class="card-header">Título</div>
  <div class="card-body">Contenido</div>
</div>

<!-- Alertas -->
<div class="alert alert-success">OK</div>
<div class="alert alert-danger">Error</div>
<div class="alert alert-info">Info</div>

<!-- Botones -->
<button class="btn btn-primary">Primario</button>
<button class="btn btn-success">Éxito</button>
<button class="btn btn-danger">Peligro</button>

<!-- Formularios -->
<div class="mb-3">
  <label class="form-label">Etiqueta</label>
  <input type="text" class="form-control" />
</div>
```

---

## 🔍 Debugging

### Agregar logs
```csharp
Console.WriteLine("Valor: " + variable);
```

### Inspeccionar objeto
```csharp
var cliente = await client.GetFromJsonAsync<ClienteItem>("clientes/1");
Console.WriteLine($"Cliente: {cliente.Nombre}");
```

---

## ⚡ Performance Tips

1. **Usar GetFromJsonAsync en lugar de GetAsync + ReadAsAsync**
2. **IHttpClientFactory reutiliza conexiones**
3. **Async/await para no bloquear thread**
4. **Cachear datos si es posible**

---

## 🐛 Errores Comunes

| Error | Causa | Solución |
|-------|-------|----------|
| Connection refused | Backend no corre | Usa `dotnet run` en backend |
| "Object reference not set" | Null pointer | Valida con `if (obj != null)` |
| "Port already in use" | Puerto ocupado | Cambia puerto en launchSettings.json |
| CORS Error | Configuración API | Agrega CORS headers en backend |
| 404 Not Found | Endpoint no existe | Verifica URL y controlador |

---

## 📚 Archivos Clave

- `Program.cs` - Configuración principal
- `Pages/_Layout.cshtml` - Layout maestro
- `Pages/Index.cshtml` - Página de inicio
- `appsettings.json` - Configuración

---

## 🎯 Convenciones

✅ Variables: `camelCase`
✅ Clases: `PascalCase`
✅ Métodos privados: `PascalCase`
✅ Propiedades: `PascalCase`
✅ Sin `_` prefix
✅ Sin `?` en tipos

---

¡Referencia rápida completa! 📖
