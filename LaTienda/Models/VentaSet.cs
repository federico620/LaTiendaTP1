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
                total += lv.StockSet.ProductoSet.NetoGravado * lv.Cantidad;
            }
            return total;
        }

        public double CalcularImpIva()
        {
            double total = 0;
            foreach (var lv in LineaDeVentaSet)
            {
                total += lv.StockSet.ProductoSet.Iva * lv.Cantidad;
            }
            return total;
        }

       public bool HabilitadoParaVender()
        {
            return Comprobante != null && (this.Total >= 10000 && this.ClienteSet.Documento != 0) || (this.Total < 10000 && this.ClienteSet.Documento == 0) || Total > 0;
        }

        public void ActualizarStock()
        {
            foreach(var lv in LineaDeVentaSet)
            {
                lv.StockSet.ActualizarStock(lv.Cantidad);
            }
        }

        public ServiceReferenceAFIP.AlicIva[] CalcularIvas()
        {
            double baseImp = 0;
            double importe = 0;
            foreach (var lv in LineaDeVentaSet)
            {
                baseImp += lv.StockSet.ProductoSet.NetoGravado * lv.Cantidad;
                importe += lv.StockSet.ProductoSet.Iva * lv.Cantidad;
            }

            ServiceReferenceAFIP.AlicIva[] alicIvas = new ServiceReferenceAFIP.AlicIva[]
            {
                new ServiceReferenceAFIP.AlicIva
                {
                Id = 5,
                BaseImp = baseImp,
                Importe = importe
                }
            };
            return alicIvas;
        }
    }
}