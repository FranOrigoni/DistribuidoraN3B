using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;

namespace CasosDeUso
{
    public class ManejadorProductos : IManejadorProductos
    {
        public IRepositorioProductos RepoProductos { get; set; }
        public IRepositorioCategorias RepoCategorias { get; set; }
        public IRepositorioProveedores RepoProveedores { get; set; }

        public ManejadorProductos(IRepositorioProductos repoProd, IRepositorioCategorias repoCat, IRepositorioProveedores repoProv)
        {
            RepoProductos = repoProd;
            RepoCategorias = repoCat;
            RepoProveedores = repoProv;
        }

        public bool AgregarNuevoProducto(Producto prod, int idCategoria, int idProveedor)
        {
            bool ok = false;

            if (prod.Validar())
            {
                Categoria cat = RepoCategorias.FindById(idCategoria);

                if(cat != null)
                {
                    Proveedor prov = RepoProveedores.FindById(idProveedor);

                    if(prov != null)
                    {
                        prod.Categoria = cat;
                        prod.Proveedor = prov;
                        ok = RepoProductos.Add(prod);
                    }
                }

            }


            return ok;
        }

        public IEnumerable<Producto> TraerTodosLosProductos()
        {
            return RepoProductos.FindAll();
        }
    }
}
