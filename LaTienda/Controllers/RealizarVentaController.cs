using LaTienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using LaTienda.Models;

namespace LaTienda.Controllers
{
    public class RealizarVentaController : Controller
    {

        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: RealizarVenta
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult Index(string searchString)
        {
            var venta = new VentaFromViewModel();

            if (!String.IsNullOrEmpty(searchString))
            {
                var productos = db.ProductoSet.Include(p => p.MarcaSet).Include(p => p.RubroSet);
                foreach (var p in productos)
                {
                    if (p.Codigo.ToString().Equals(searchString))
                    {
                        venta.ProductoViewModel = ProductoViewModel.FromModel(p);
                    }
                }
            }

            ViewBag.Color_Id = db.ColorSet.ToList();
            ViewBag.Talle_Id = db.TalleSet.ToList();

            return View(venta);
        }

        public ViewResult BuscarStock(int color_id, int talle_id, int producto_id)
        {
            var venta = new VentaFromViewModel();

            var producto = db.ProductoSet.Include(p => p.MarcaSet).Include(p => p.RubroSet).Include(x => x.StockSet).FirstOrDefault(x => x.Id == producto_id);

            var stock = producto.StockSet.FirstOrDefault(x => x.Color_Id.Equals(color_id) && x.Talle_Id.Equals(talle_id));

            venta.ProductoViewModel = ProductoViewModel.FromModel(producto);
            if (stock != null)
                venta.StockViewModel = StockViewModel.FromModel(stock);

            ViewBag.Color_Id = db.ColorSet.ToList();
            ViewBag.Talle_Id = db.TalleSet.ToList();

            return View("Index", venta);
        }
    }
}