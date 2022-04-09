using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasosDeUso;
using Dominio.EntidadesNegocio;
using WebMVC.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebMVC.Controllers
{
    public class ProductosController : Controller
    {
        public IManejadorProductos ManejadorProductos { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public ProductosController(IManejadorProductos manProds, IWebHostEnvironment whenv )
        {
            ManejadorProductos = manProds;
            WebHostEnvironment = whenv;
        }

        // GET: ProductosController
        public ActionResult Index()
        {
            IEnumerable<Producto> productos = ManejadorProductos.TraerTodosLosProductos();

            return View(productos);
        }

        // GET: ProductosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductosController/Create
        public ActionResult CreateNacional()
        {
            ViewModelNacional vm = new ViewModelNacional();
            vm.Categorias = ManejadorProductos.TraerTodasLasCategorias();
            vm.Proveedores = ManejadorProductos.TraerTodosLosProveedores();

            return View(vm);
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNacional(ViewModelNacional vm)
        {
            try
            {
                string nomArchivo = vm.Imagen.FileName;
                nomArchivo = vm.Producto.Codigo + "_" + nomArchivo;
                vm.Producto.Foto = nomArchivo;

                bool ok = ManejadorProductos.AgregarNuevoProducto(vm.Producto, vm.IdCategoriaSeleccionada, vm.IdProveedorSeleccionado);


                if (ok)
                {
                    string rutaRaiz = WebHostEnvironment.WebRootPath;
                    string rutaImagenes = Path.Combine(rutaRaiz, "imagenes");
                    string rutaArchivo = Path.Combine(rutaImagenes, nomArchivo);

                    FileStream stream = new FileStream(rutaArchivo, FileMode.Create);
                    vm.Imagen.CopyTo(stream);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("NO SE PUDO HACER EL ALTA");
                    vm.Categorias = ManejadorProductos.TraerTodasLasCategorias();
                    vm.Proveedores = ManejadorProductos.TraerTodosLosProveedores();
                    return View(vm);
                }

              
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
