using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        //Primero vamos a llamar a nuestra clase CD_Conexion
        private CD_Conexion Conexion = new CD_Conexion();

        //creamos metodos de registro y de login
        public bool RegistroUsuario(string nombre, string usuario, string contraseña)
        { 
            // Empezamos con false para que cuando se de click al btnRegistrar se active y sea true
            bool result = false;
            //abrimos un using que permitira abrir y cerrar la conexion sin necesidad de hacerlo manualmente
            using (SqlConnection CN = Conexion.AbrirConexion())
            {
             //Aqui se prepara la instruccion que queremos ejecutar
             string query = "INSERT INTO Usuarios (Nombre, Usuario, Contraseña) VALUES (@Nombre, @Usuario, @Contraseña)";

                using (SqlCommand comando = new SqlCommand(query, CN))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);
                    //Agregamos una condicion para saber si se realizo la operacion 
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if(filasAfectadas > 0)
                    {
                    result = true;
                    }
                    return result;
                }

            }
        }

        public int IniciarSesion(String usuario, String contraseña)
        {  
            //Hacemos un proceso similar al de registroUsuario
            int UsuarioSesion = 0;
            using (SqlConnection CN = Conexion.AbrirConexion())
            {
             String query = "SELECT id_Usuario FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

            using (SqlCommand comando = new SqlCommand (query, CN))
            {
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);

                    //Agregamos un objeto porque no se sabe el tipo de dato que puede buscar
                    object result = comando.ExecuteScalar();
                    //Agregamos una condicion y colocamos un operador logico donde ambas condiciones sean verdaderas
                    if(result != null && result != DBNull.Value)
                    {
                        result = true;
                    }
                    return UsuarioSesion;

            }
            }
        }
    }
}






