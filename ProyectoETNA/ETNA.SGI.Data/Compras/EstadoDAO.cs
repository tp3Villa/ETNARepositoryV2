﻿using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Compras
{
    public interface EstadoDAO
    {
        DataTable DGetAllEstadoByOrdenCompra();

        DataTable DGetAllEstadoByCotizacion();

        DataTable DGetAllEstadoByReqCompra();
    }
}
