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
using LaTienda.Models.Auth;


namespace LaTienda.Controllers
{
    [CustomAuthorize(Roles = "Vendedor")]
    public class RealizarVentaController : Controller
    {

        private LaTiendaEntities db = new LaTiendaEntities();

        public ViewResult Index()
        {
            var venta = new VentaFromViewModel();
            var v = new VentaSet() {Total = 0, CAE = "", Fecha = DateTime.Now , FechaVen = DateTime.Now, Concepto = Enums.Concepto.Producto, PuntoDeVentaSet_Id = 1};
            db.VentaSet.Add(v);
            db.SaveChanges();
            venta.Id = v.Id;
            return View(venta);
        }
        
        public ViewResult BuscarProducto(int venta_id, string searchString)
        {
            VentaSet v = BuscarVenta(venta_id);

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
            VentaSet v = BuscarVenta(venta_id);

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
            VentaSet v = BuscarVenta(venta_id);

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
                v.CalcularTotal();
                db.SaveChanges();
                venta.LineaDeVentaViewModels.Add(LineaDeVentaViewModel.FromModel(lv));
                venta.Total = v.Total;
                
            }

           venta.ProductoViewModel = ProductoViewModel.FromModel(producto);
           venta.StockViewModel = StockViewModel.FromModel(stock);


            ViewBag.Color_Id = db.ColorSet.ToList();
            ViewBag.Talle_Id = db.TalleSet.ToList();

            return View("Index",venta);
        }

        public ViewResult BuscarCliente(int venta_id, string searchCliente)
        {
            VentaSet v = BuscarVenta(venta_id);

            var cliente = db.ClienteSet.Include(x => x.CondicionTributaria).FirstOrDefault(x => x.Documento.ToString().Equals(searchCliente));
            if (cliente != null)
            {
                v.ClienteSet = cliente;
                v.Cliente_Id = cliente.Id;
            }
            var venta = VentaFromViewModel.FromModel(v);
           // venta.ClienteViewModel = ClienteViewModel.FromModel(v.ClienteSet);
            return View("Index", venta);
        }

        public ViewResult AgregarCliente(int venta_id, int? cliente_id)
        {
            VentaSet v = BuscarVenta(venta_id);

            ClienteSet cliente;
            if (cliente_id != null)
            {
                cliente = db.ClienteSet.FirstOrDefault(x => x.Id.Equals(cliente_id.Value));
                if (cliente != null)
                {
                    v.ClienteSet = cliente;
                    v.Cliente_Id = cliente.Id;
                    db.SaveChanges();
                }
            }
            else
            {
                var cd = db.CondicionTributariaSet.FirstOrDefault(x => x.Condicion == Enums.CondicionTributariaEnum.CF);
                cliente = new ClienteSet
                {
                    CondicionTributaria = cd,
                    TipoDocumento = Enums.TipoDocumento.OTRO,
                    Domicilio = "",
                    Documento = 0,
                    Nombre = ""
                };
                v.ClienteSet = cliente;
                v.Cliente_Id = cliente.Id;
                db.SaveChanges();
            }
            var venta = VentaFromViewModel.FromModel(v);

            //venta.ClienteViewModel = ClienteViewModel.FromModel(cliente);
            return View("Index", venta);

        }

        private VentaSet BuscarVenta(int venta_id)
        {
            var v = db.VentaSet.Include(x => x.LineaDeVentaSet).Include(x => x.ClienteSet).Include(x => x.Comprobante).FirstOrDefault(x => x.Id.Equals(venta_id));

            foreach (var lv in v.LineaDeVentaSet)
            {
                lv.StockSet = db.StockSet.Include(x => x.ProductoSet).Include(x => x.ColorSet).Include(x => x.TalleSet).FirstOrDefault(x => x.Id.Equals(lv.StockSet_Id));
            }

            return v;
        }


        public ViewResult FinalizarVenta(int venta_id)
        {
            var v = BuscarVenta(venta_id);
            var venta = VentaFromViewModel.FromModel(v);
            if (v.Cliente_Id != null && v.LineaDeVentaSet != null)
            {
                v.Comprobante = v.ClienteSet.CondicionTributaria.ObtenerComprobante(Enums.Operacion.Venta);
                if (v.Comprobante != null && ((v.Total >= 10000 && v.ClienteSet.Documento != 0) || (v.Total < 10000 && v.ClienteSet.Documento == 0) || v.Total > 0))
                {
                    var resultado = ClienteAFIP.AutorizarVenta(v);


                    if (resultado.Equals("A"))
                    {
                        v.ActualizarStock();
                        db.SaveChanges();
                        return View("FinalizarVenta", venta);
                    }
                    else
                    {
                        //eliminar venta
                        var lvs = v.LineaDeVentaSet.ToList();
                        foreach (var lv in lvs)
                        {
                            db.LineaDeVentaSet.Remove(lv);
                        }
                        db.SaveChanges();
                        db.VentaSet.Remove(v);
                        db.SaveChanges();
                        return View("VentaFallida");
                    }
                }else return View("VentaFallida");
            }else return View("VentaFallida");
        }
    }
}