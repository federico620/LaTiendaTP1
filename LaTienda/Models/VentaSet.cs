using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda
{
    public partial class VentaSet
    {
        public void CalcularTotal()
        {
            double total = 0;
            foreach (var lv in LineaDeVentaSet)
            {
                total += lv.PrecioDeVenta * lv.Cantidad;
            }
            this.Total = total;
        }
        public double CalcularNetoGravado()
        {
            double total = 0;
            foreach (var lv in LineaDeVentaSet)
            {
                total += lv.StockSet.ProductoSet.NetoGravado;
            }
            return total;
        }

        public double CalcularImpIva()
        {
            double total = 0;
            foreach (var lv in LineaDeVentaSet)
            {
                total += lv.StockSet.ProductoSet.Iva;
            }
            return total;
        }

        public void InicializarComprobante()
        {
            if (Total < 10000 && ClienteSet.CondicionTributaria.Equals(Enums.CondicionTributaria.CF))
            {
                this.ComprobanteSet = new ComprobanteSet {Fecha = this.Fecha, FechaVen = this.Fecha.AddDays(10), Concepto = Enums.Concepto.Producto, TipoComprobante = Enums.TipoComprobante.FacturaB };
            }
            else if (Total < 10000 && ClienteSet == null)
            {
                this.ComprobanteSet = new ComprobanteSet { Fecha = this.Fecha, FechaVen = this.Fecha.AddDays(10), Concepto = Enums.Concepto.Producto, TipoComprobante = Enums.TipoComprobante.FacturaB };
            }
            else if (ClienteSet.CondicionTributaria == Enums.CondicionTributaria.RI)
            {
                this.ComprobanteSet = new ComprobanteSet { Fecha = this.Fecha, FechaVen = this.Fecha.AddDays(10), Concepto = Enums.Concepto.Producto, TipoComprobante = Enums.TipoComprobante.FacturaA };
            }
            else if (ClienteSet.CondicionTributaria == Enums.CondicionTributaria.M)
            {
                this.ComprobanteSet = new ComprobanteSet { Fecha = this.Fecha, FechaVen = this.Fecha.AddDays(10), Concepto = Enums.Concepto.Producto, TipoComprobante = Enums.TipoComprobante.FacturaA };
            }
            else if (ClienteSet.CondicionTributaria == Enums.CondicionTributaria.E)
            {
                this.ComprobanteSet = new ComprobanteSet { Fecha = this.Fecha, FechaVen = this.Fecha.AddDays(10), Concepto = Enums.Concepto.Producto, TipoComprobante = Enums.TipoComprobante.FacturaB };
            }
            else if (ClienteSet.CondicionTributaria == Enums.CondicionTributaria.NR)
            {
                this.ComprobanteSet = new ComprobanteSet { Fecha = this.Fecha, FechaVen = this.Fecha.AddDays(10), Concepto = Enums.Concepto.Producto, TipoComprobante = Enums.TipoComprobante.FacturaB };
            }
        }
    }
}