using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET
{
    class Conexion_db
    {
        SqlConnection miConexion  =  new SqlConnection();
    SqlCommand comandosSQL = new SqlCommand();
    SqlDataAdapter miAdaptadorDatos = new SqlDataAdapter();

    DataSet ds = new DataSet();

         Conexion_db Público()
    {
        cadena cadena = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Fidel-pc\Documents\Visual Studio 2017\ADO_NET\ADO_NET\SistemaData.mdf; Integrated Security = True";
        miConexion.ConnectionString = cadena;
        miConexion.Abierto();
    }
    DataSet público obtener_datos()
    {
        ds.Claro();
        comandosSQL.Conexión = miConexion;

        comandosSQL.CommandText = " seleccionar * de clientes ";
        miAdaptadorDatos.SelectCommand = comandosSQL;
        miAdaptadorDatos.Rellenar(ds, " clientes ");

        comandosSQL.CommandText = " seleccionar * de productos ";
        miAdaptadorDatos.SelectCommand = comandosSQL;
        miAdaptadorDatos.Relleno(ds, " productos ");

        retorno ds;
    }
    public void mantenimiento_datos(String[] datos, String accion)
    {
        String sql = " ";
        if (accion == " nuevo ")
        {
            sql = " INSERTAR EN clientes (codigo, nombre, direccion, telefono, dui, nit) VALORES ( " +
                " ' " + datos[1] + " ', " +
                " ' " + datos[2] + " ', " +
                " ' " + datos[3] + " ', " +
                " ' " + datos[4] + " ', " +
                " ' " + datos[5] + " ', " +
                " ' " + datos[6] + " ' " +
                " ) ";
        }
        else if (accion == " modificar ")
        {
            sql = " ACTUALIZAR clientes SET " +
                " codigo = ' " + datos[1] + " ', " +
                " nombre = ' " + datos[2] + " ', " +
                " direccion = ' " + datos[3] + " ', " +
                " telefono = ' " + datos[4] + " ', " +
                " dui = ' " + datos[5] + " ', " +
                " nit = ' " + datos[6] + " ' " +
                " WHERE idCliente = ' " + datos[0] + " ' ";
        }
        else if (accion == " eliminar ")
        {
            sql = " ELIMINAR clientes DE clientes DONDE idCliente = ' " + datos[0] + " ' ";
        }
        procesSQL(sql);
    }
    nulo procesamientoSQL(String sql)
    {
        comandosSQL.Conexión = miConexion;
        comandosSQL.CommandText = sql;
        comandosSQL.ExecuteNonQuery();
    }
}
}
