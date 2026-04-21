using Clase_12.Dtos;
using Clase_12.Models;

namespace Clase_12.Services;

public interface IProductoService
{
    IReadOnlyCollection<Producto> GetAll();
    Producto? GetById(int id);
    Producto Create(CreateProductoRequest request);
    bool Update(int id, UpdateProductoRequest request);
    bool Delete(int id);
}
