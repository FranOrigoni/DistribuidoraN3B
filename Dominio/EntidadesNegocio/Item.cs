namespace Dominio.EntidadesNegocio
{
    public class Item
    {
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }
        public decimal PrecioCongeladoProducto { get; set; }
    }
}