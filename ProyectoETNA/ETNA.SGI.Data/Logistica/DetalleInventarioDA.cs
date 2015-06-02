﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Data.Logistica
{
    public class DetalleInventarioDA
    {
        /// <summary>
        /// Retorna los productos de un almacén que se encuentra en proceso de inventario
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<DetalleInventarioBE> ObtenerDetalleInventario(DetalleInventarioBE oBe)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();

            List<DetalleInventarioBE> listDetalle = new List<DetalleInventarioBE>();

            parameter.Add("@IN_IDINVENTARIO", oBe.In_idInventario);

            DetalleInventarioBE objDetalle;

            using (IDataReader dr = SqlHelper.Instance.ExecuteReader("SP_OBTENER_DETALLE_INVENTARIO", parameter))
            {
                while (dr.Read())
                {
                    objDetalle = new DetalleInventarioBE();
                    objDetalle.In_idDetalleInventario = dr.GetInt32(dr.GetOrdinal("id"));
                    objDetalle.Vc_producto = dr.GetString(dr.GetOrdinal("producto"));
                    objDetalle.Dt_fechaToma = dr.GetDateTime(dr.GetOrdinal("fecha"));
                    objDetalle.In_cantidad = dr.IsDBNull(dr.GetOrdinal("cantidad")) ? 0 : dr.GetInt32(dr.GetOrdinal("cantidad"));

                    listDetalle.Add(objDetalle);
                }
            }
            return listDetalle;
        }
        /// <summary>
        /// Actualiza el estado del inventario para indicar su finalización
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public int FinalizarTomaInventario(DetalleInventarioBE oBe)
        {
            try
            {
                int rpta = 0;
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@IN_IDINVENTARIO", oBe.In_idInventario);
                rpta = int.Parse(SqlHelper.Instance.ExecuteScalar("SP_FINALIZAR_TOMA_INVENTARIO", parameter).ToString());
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Permite registrar la cantidad ingresada para un producto de un inventario en proceso
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public int EditarTomaInventario(DetalleInventarioBE oBe)
        {
            try
            {
                int rpta = 0;
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@IN_IDDETALLEINVENTARIO", oBe.In_idDetalleInventario);
                parameter.Add("@IN_CANTIDAD", oBe.In_cantidad);
                rpta = int.Parse(SqlHelper.Instance.ExecuteScalar("SP_EDITAR_TOMA_INVENTARIO", parameter).ToString());
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
