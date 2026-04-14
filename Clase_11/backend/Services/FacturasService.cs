using Clase_11.Models;

namespace Clase_11.Services;

public class FacturasService
{
    private static List<Factura> facturas = new();
    private static int proximoId = 1;

    public FacturasService(ClientesService clientesService)
    {
        ClientesService = clientesService;
    }

    public ClientesService ClientesService { get; }

    public List<Factura> ObtenerTodas()
    {
        return facturas;
    }

    public Factura? ObtenerPorId(int id)
    {
        return facturas.FirstOrDefault(f => f.Id == id);
    }

    public List<Factura> ObtenerPorCliente(int clienteId)
    {
        return facturas.Where(f => f.ClienteId == clienteId).ToList();
    }

    public Factura Crear(Factura nuevaFactura)
    {
        nuevaFactura.Id = proximoId++;
        nuevaFactura.Fecha = DateTime.Now;
        nuevaFactura.Total = nuevaFactura.Lineas.Sum(l => l.Subtotal);
        nuevaFactura.Cliente = ClientesService.ObtenerPorId(nuevaFactura.ClienteId);
        facturas.Add(nuevaFactura);
        return nuevaFactura;
    }

    public bool Actualizar(int id, Factura facturaActualizada)
    {
        var factura = facturas.FirstOrDefault(f => f.Id == id);
        if (factura == null)
            return false;

        factura.ClienteId = facturaActualizada.ClienteId;
        factura.Lineas = facturaActualizada.Lineas;
        factura.Total = factura.Lineas.Sum(l => l.Subtotal);
        factura.Cliente = ClientesService.ObtenerPorId(factura.ClienteId);

        return true;
    }

    public bool Eliminar(int id)
    {
        var factura = facturas.FirstOrDefault(f => f.Id == id);
        if (factura == null)
            return false;

        facturas.Remove(factura);
        return true;
    }

    public Factura AgregarLinea(int facturaId, LineaFactura linea)
    {
        var factura = facturas.FirstOrDefault(f => f.Id == facturaId);
        if (factura == null)
            throw new Exception("Factura no encontrada");

        linea.Id = factura.Lineas.Count + 1;
        linea.FacturaId = facturaId;
        linea.Subtotal = linea.Cantidad * linea.PrecioUnitario;
        factura.Lineas.Add(linea);
        factura.Total = factura.Lineas.Sum(l => l.Subtotal);

        return factura;
    }
}
