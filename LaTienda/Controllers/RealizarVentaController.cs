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

        public ViewResult Index()
        {
            var venta = new VentaFromViewModel();
            var v = new VentaSet() { Fecha = DateTime.Now};
            db.VentaSet.Add(v);
            db.SaveChanges();
            venta.Id = v.Id;
            return View(venta);
        }
        
        public ViewResult BuscarProducto(int venta_id, string searchString)
        {
            var v = db.VentaSet.Include(x => x.LineaDeVentaSet).FirstOrDefault(x => x.Id.Equals(venta_id));

            foreach (var lv in v.LineaDeVentaSet)
            {
                lv.StockSet = db.StockSet.Include(x => x.ProductoSet).Include(x => x.ColorSet).Include(x => x.TalleSet).FirstOrDefault(x => x.Id.Equals(lv.StockSet_Id));
            }

            var venta = VentaFromViewModel.FromModel(v);
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

            return View("Index",venta);
        }

        public ViewResult BuscarStock(int venta_id, int color_id, int talle_id, int producto_id)
        {
            var v = db.VentaSet.Include(x => x.LineaDeVentaSet).FirstOrDefault(x => x.Id.Equals(venta_id));

            foreach (var lv in v.LineaDeVentaSet)
            {
                lv.StockSet = db.StockSet.Include(x => x.ProductoSet).Include(x => x.ColorSet).Include(x => x.TalleSet).FirstOrDefault(x => x.Id.Equals(lv.StockSet_Id));
            }

            var venta = VentaFromViewModel.FromModel(v);
            var producto = db.ProductoSet.Include(p => p.MarcaSet).Include(p => p.RubroSet).Include(x => x.StockSet).FirstOrDefault(x => x.Id == producto_id);

            var stock = producto.StockSet.FirstOrDefault(x => x.Color_Id.Equals(color_id) && x.Talle_Id.Equals(talle_id));

            venta.ProductoViewModel = ProductoViewModel.FromModel(producto);
            if (stock != null)
                venta.StockViewModel = StockViewModel.FromModel(stock);

            ViewBag.Color_Id = db.ColorSet.ToList();
            ViewBag.Talle_Id = db.TalleSet.ToList();

            return View("Index", venta);
        }

        public ViewResult AgregarProducto(int venta_id, int producto_id, int stock_id, int cantidad)
        {
            //var v = db.VentaSet.Include(x => x.LineaDeVentaSet.Select(y => y.StockSet).Select(z => z.ProductoSet)).FirstOrDefault(x => x.Id.Equals(venta_id));
            var v = db.VentaSet.Include(x => x.LineaDeVentaSet).FirstOrDefault(x => x.Id.Equals(venta_id));
            
            foreach (var lv in v.LineaDeVentaSet)
             {
                lv.StockSet = db.StockSet.Include(x => x.ProductoSet).Include(x => x.ColorSet).Include(x => x.TalleSet).FirstOrDefault(x => x.Id.Equals(lv.StockSet_Id));
            }

            var venta = VentaFromViewModel.FromModel(v);
            var producto = db.ProductoSet.Include(p => p.MarcaSet).Include(p => p.RubroSet).Include(x => x.StockSet).FirstOrDefault(x => x.Id == producto_id);

            var stock = producto.StockSet.FirstOrDefault(x => x.Id.Equals(stock_id));

            if(stock.Cantidad >= cantidad)
            {
                var lv = new LineaDeVentaSet();
                lv.Cantidad = cantidad;
                lv.PrecioDeVenta = producto.PrecioDeVenta;
                lv.StockSet = stock;
                lv.StockSet_Id = stock_id;
                v.LineaDeVentaSet.Add(lv);                
                db.SaveChanges();
                venta.LineaDeVentaViewModels.Add(LineaDeVentaViewModel.FromModel(lv));
            }

           venta.ProductoViewModel = ProductoViewModel.FromModel(producto);
           venta.StockViewModel = StockViewModel.FromModel(stock);

            ViewBag.Color_Id = db.ColorSet.ToList();
            ViewBag.Talle_Id = db.TalleSet.ToList();

            return View("Index",venta);
        }
    }
}