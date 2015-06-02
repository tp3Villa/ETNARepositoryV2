﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Data.Logistica
{
    public class ProgramacionInventarioDA
    {
        /// <summary>
        /// Retorna la relación de inventarios programados en el sistema
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<ProgramacionInventarioBE> ObtenerInventariosProgramados(ProgramacionInventarioBE oBe)
        {
            List<ProgramacionInventarioBE> listProgInventario = new List<ProgramacionInventarioBE>();

            Dictionary<string, object> parameter = new Dictionary<string, object>();

            parameter.Add("@IN_TIPOINVENTARIO", oBe.In_tipoInventario);
            parameter.Add("@IN_IDALMACEN", oBe.In_idAlmacen);

            ProgramacionInventarioBE objProgInventario;

            using (IDataReader dr = SqlHelper.Instance.ExecuteReader("SP_OBTENER_INVENTARIOS_PROGRAMADOS", parameter))
            {
                while (dr.Read())
                {
                    objProgInventario = new ProgramacionInventarioBE();
                    objProgInventario.In_idProgInventario = dr.GetInt32(dr.GetOrdinal("id"));
                    objProgInventario.Dt_fechaProgramada = dr.GetDateTime(dr.GetOrdinal("fecha"));
                    objProgInventario.In_tipoInventario = dr.GetInt32(dr.GetOrdinal("idTipo"));
                    objProgInventario.Vc_tipoInventario = dr.GetString(dr.GetOrdinal("tipo"));
                    objProgInventario.In_idAlmacen = dr.GetInt32(dr.GetOrdinal("idAlmacen"));
                    objProgInventario.Vc_almacen = dr.GetString(dr.GetOrdinal("almacen"));
                    objProgInventario.Vc_usuario = dr.GetString(dr.GetOrdinal("usuario"));
                    objProgInventario.Vc_estado = dr.GetString(dr.GetOrdinal("estado"));
                    listProgInventario.Add(objProgInventario);
                }
            }
            return listProgInventario;
        }
        /// <summary>
        /// Obtiene relación de inventarios
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<ProgramacionInventarioBE> ObtenerInventarios(ProgramacionInventarioBE oBe)
        {
            List<ProgramacionInventarioBE> listProgInventario = new List<ProgramacionInventarioBE>();

            Dictionary<string, object> parameter = new Dictionary<string, object>();

            parameter.Add("@IN_ESTADOINVENTARIO", oBe.In_idEstadoInventario);
            parameter.Add("@IN_IDALMACEN", oBe.In_idAlmacen);

            ProgramacionInventarioBE objProgInventario;

            using (IDataReader dr = SqlHelper.Instance.ExecuteReader("SP_OBTENER_INVENTARIOS", parameter))
            {
                while (dr.Read())
                {
                    objProgInventario = new ProgramacionInventarioBE();
                    objProgInventario.In_idProgInventario = dr.GetInt32(dr.GetOrdinal("id"));
                    objProgInventario.Dt_fechaProgramada = dr.GetDateTime(dr.GetOrdinal("fecha"));
                    objProgInventario.In_tipoInventario = dr.GetInt32(dr.GetOrdinal("idTipo"));
                    objProgInventario.Vc_tipoInventario = dr.GetString(dr.GetOrdinal("tipo"));
                    objProgInventario.In_idAlmacen = dr.GetInt32(dr.GetOrdinal("idAlmacen"));
                    objProgInventario.Vc_almacen = dr.GetString(dr.GetOrdinal("almacen"));
                    objProgInventario.Vc_usuario = dr.GetString(dr.GetOrdinal("usuario"));
                    objProgInventario.Vc_estado = dr.GetString(dr.GetOrdinal("estado"));
                    listProgInventario.Add(objProgInventario);
                }
            }
            return listProgInventario;
        }
        /// <summary>
        /// Agrega un nuevo inventario programado en el sistema
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public int RegistrarInventariosProgramados(ProgramacionInventarioBE oBe)
        {
            try
            {
                int rpta = 0;
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@DT_FechaProgramada", oBe.Dt_fechaProgramada);
                parameter.Add("@IN_TipoInventario", oBe.In_tipoInventario);
                parameter.Add("@CH_Cod_Usuario", oBe.Ch_Cod_Usuario);
                parameter.Add("@IN_idAlmacen", oBe.In_idAlmacen);
                rpta = int.Parse(SqlHelper.Instance.ExecuteScalar("SP_INSERTAR_INVENTARIO_PROGRAMADO", parameter).ToString());
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cambia los datos de un inventario programado
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public int ActualizarInventariosProgramados(ProgramacionInventarioBE oBe)
        {
            try
            {
                int rpta = 0;
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@IN_idProgInventario", oBe.In_idProgInventario);
                parameter.Add("@DT_FechaProgramada", oBe.Dt_fechaProgramada);
                parameter.Add("@IN_TipoInventario", oBe.In_tipoInventario);
                parameter.Add("@IN_idAlmacen", oBe.In_idAlmacen);
                rpta = int.Parse(SqlHelper.Instance.ExecuteScalar("SP_ACTUALIZAR_INVENTARIO_PROGRAMADO", parameter).ToString());
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Eliminar un inventario programado
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public int EliminarInventariosProgramados(ProgramacionInventarioBE oBe)
        {
            try
            {
                int rpta = 0;
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@IN_idProgInventario", oBe.In_idProgInventario);
                rpta = int.Parse(SqlHelper.Instance.ExecuteScalar("SP_ELIMINAR_INVENTARIO_PROGRAMADO", parameter).ToString());
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualizar el inventario con el estado INICIADO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public int IniciarInventario(ProgramacionInventarioBE oBe)
        {
            try
            {
                int rpta = 0;
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@IN_idProgInventario", oBe.In_idProgInventario);
                rpta = int.Parse(SqlHelper.Instance.ExecuteScalar("SP_INICIAR_INVENTARIO", parameter).ToString());
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Ejecuta el proceso de Ajuste de Inventario
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public int AjustarInventario(ProgramacionInventarioBE oBe)
        {
            try
            {
                int rpta = 0;
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@IN_idProgInventario", oBe.In_idProgInventario);
                rpta = int.Parse(SqlHelper.Instance.ExecuteScalar("SP_AJUSTAR_INVENTARIO", parameter).ToString());
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
