﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class ClienteAFIP
    {

        public static void AutorizarVenta(VentaSet venta)
        {
            string guid = "C2840D23-7DE1-4D3D-A4D3-AD34C17C92D4";
            var wrapper = new ServiceReferenceWrapper.LoginServiceClient().SolicitarAutorizacion(guid);
            var con = new ServiceReferenceAFIP.ServiceSoapClient();
            //ImpTotConc es 0 para facturac
            //ImpNeto Para comprobantes tipo C este campo corresponde al Importe del SubTotal.
            var fecabreq = new ServiceReferenceAFIP.FECAECabRequest
            {
                CbteTipo = (int)venta.ComprobanteSet.TipoComprobante,
                CantReg = 1,
                PtoVta = 1,
            };

            var authReq = new ServiceReferenceAFIP.FEAuthRequest
            {
                Cuit = wrapper.Cuit,
                Sign = wrapper.Sign,
                Token = wrapper.Token,
            };

            var ultAut = con.FECompUltimoAutorizado(authReq, 1, (int)venta.ComprobanteSet.TipoComprobante);
            var numNuevoComp = ultAut.CbteNro + 1;
            var alicIvas = venta.LineaDeVentaSet.Select(x => new ServiceReferenceAFIP.AlicIva
            {
                Id = 5,
                BaseImp = x.StockSet.ProductoSet.NetoGravado,
                Importe = x.StockSet.ProductoSet.Iva,
            }).ToArray();

            
            var fedetreq = new ServiceReferenceAFIP.FECAEDetRequest
            {
                Concepto = (int)venta.ComprobanteSet.Concepto,
                DocTipo = (int)venta.ClienteSet.TipoDocumento,
                DocNro = (long)venta.ClienteSet.Documento,
                CbteDesde = numNuevoComp,
                CbteHasta = numNuevoComp,
                CbteFch = venta.ComprobanteSet.Fecha.ToString("yyyyMMdd"),
                ImpTotal = venta.Total,
                ImpTotConc = 0,
                ImpNeto = venta.CalcularNetoGravado(),
                ImpOpEx = 0,
                ImpIVA = venta.CalcularImpIva(),
                ImpTrib = 0,
                MonId = "PES",
                MonCotiz = 1,
                Iva = alicIvas,
            };
            //CbteFch = $"{venta.Fecha.Year}{venta.Fecha.Month}{venta.Fecha.Day}",
            

            var fedetreqs = new ServiceReferenceAFIP.FECAEDetRequest[] { fedetreq };
            var fecaeReq = new ServiceReferenceAFIP.FECAERequest
            {
                FeCabReq = fecabreq,
                FeDetReq = fedetreqs,
            };

            //var reqBody = new ServiceReferenceAFIP.FECAESolicitarRequestBody(authReq, fecaeReq);
            //var solicitarReq = new ServiceReferenceAFIP.FECAESolicitarRequest(reqBody);
            
            var comp = con.FECAESolicitar(authReq,fecaeReq);
        }
    }
}