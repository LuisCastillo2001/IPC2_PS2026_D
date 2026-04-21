using System.Collections.Concurrent;
using System.Threading;
using Clase_12.Dtos;
using Clase_12.Models;

namespace Clase_12.Services;

public sealed class ProductoService : IProductoService
{
    private readonly ConcurrentDictionary<int, Producto> _items = new();
    private int _nextId = 0;

    public ProductoService()
    {
        // Seed mínimo para que el GET no esté vacío.
        var p1 = Create(new CreateProductoRequest { Nombre = "Cuaderno", Precio = 12.50m, Stock = 10 });
        var p2 = Create(new CreateProductoRequest { Nombre = "Lapicero", Precio = 3.25m, Stock = 100 });
    }

    public IReadOnlyCollection<Producto> GetAll() => _items.Values
        .OrderBy(p => p.Id)
        .ToArray();

    public Producto? GetById(int id) => _items.TryGetValue(id, out var producto)
        ? producto
        : null;

    public Producto Create(CreateProductoRequest request)
    {
        var id = Interlocked.Increment(ref _nextId);
        var producto = new Producto
        {
            Id = id,
            Nombre = request.Nombre.Trim(),
            Precio = request.Precio,
            Stock = request.Stock
        };

        _items[id] = producto;
        return producto;
    }

    public bool Update(int id, UpdateProductoRequest request)
    {
        if (!_items.TryGetValue(id, out var existing))
        {
            return false;
        }

        existing.Nombre = request.Nombre.Trim();
        existing.Precio = request.Precio;
        existing.Stock = request.Stock;
        return true;
    }

    public bool Delete(int id) => _items.TryRemove(id, out _);
}
