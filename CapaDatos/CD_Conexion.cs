using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class CD_Conexion
    {
        //Agregamos la conexion con la BD creada de SQL Server
        private SqlConnection Conexion = new SqlConnection("@Server=localhost\\SQLEXPRESS;Database=DB_AgendaTel; Integrated Security=true;");

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }
        
        public SqlConnection CerrarConexion()
        { 
            if(Conexion.State == System.Data.ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }
    }

            
}
