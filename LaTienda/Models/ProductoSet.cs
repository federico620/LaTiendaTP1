using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda
{
    public partial class ProductoSet
    {
        public ProductoSet(int id, int codigo, string descripcion, double costo, int margenDeGanancia, int porcentajeIva)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Costo = costo;
            MargenDeGanancia = margenDeGanancia;
            PorcentajeIva = porcentajeIva;
            CalcularNetoGravado();
            CalcularIva();
            CalcularPrecioDeVenta();
            this.StockSet = new HashSet<StockSet>();
        }

        public void CalcularNetoGravado()
        {
            NetoGravado = Costo + Costo * MargenDeGanancia / 100;
        }

        public void CalcularIva()
        {
            Iva = NetoGravado * PorcentajeIva / 100;
        }

        public void CalcularPrecioDeVenta()
        {
            PrecioDeVenta = NetoGravado + Iva;
        }
    }
}