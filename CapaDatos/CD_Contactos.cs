using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Contactos
    {
        //Abrimos conexion
        private CD_Conexion Conexion = new CD_Conexion();

        public DataTable Mostrar()
        {
            //Comandos para mostrar Contactos
            SqlCommand comando = new SqlCommand();
            comando.Connection = Conexion.AbrirConexion();
            //Agregamos una consulta INNER JOIN para que nos muestre en el dgv de las tablas que queremos
            comando.CommandText = "SELECT C.IdContacto, C.Nombres, C.Apellido, C.Edad, T.Numero" + "FROM Contactos C" + "INNER JOIN Telefonos T ON C.IdContacto = T.IdContacto";
            comando.CommandType = CommandType.Text;

            DataTable tabla = new DataTable();
            SqlDataReader leer = comando.ExecuteReader();
            tabla .Load(leer);
            return tabla;

        }

        //Hacemos el metodo Agregar
        public bool Agregar(int IdUsuario, string Nombres, string Apellido, int Edad, string Numero, out string mensaje)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandType=CommandType.Text;

            //Agregamos un try cath por si algo falla este lo atrapa
            try
            {
                comando.CommandText = "INSERT INTO Contactos (IdUsuario, Nombres, Apellido, Edad)" + "VALUES (@Nombres, @Apellido, @Edad);" + "SELECT SCOPE_IDENTITY();";

                //Agregamos parametros 
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                comando.Parameters.AddWithValue("@Nombres", Nombres);
                comando.Parameters.AddWithValue("@Apellido", Apellido);
                comando.Parameters.AddWithValue("@Edad", Edad);

                int IdContactoGenerado = Convert.ToInt32(comando.ExecuteScalar());
                comando.Parameters.Clear();

                comando.CommandText = "INSERT INTO Telefonos (IdContacto, Numero)" + "VALUES (@IdContacto, @Numero);";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@IdContacto", IdContactoGenerado);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.ExecuteNonQuery();
                Conexion.CerrarConexion();
                mensaje = "Contacto agregado con éxito";
                return true;

            }
            catch (Exception ex)
            {
                Conexion.CerrarConexion();
                mensaje = "Error al agregar:" +ex.Message;
                return false;
            }

        }
        
        


}
    }

    

