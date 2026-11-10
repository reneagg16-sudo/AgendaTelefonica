using System;
using CapaDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objetoCD = new CD_Usuarios();

        //llamamos los metodos de la CD_Usuarios
        public bool RegistroUsuario(string nombre, string usuario, string contraseña, string confirmarContraseña)
        {
          //Agregamos reglas para que ningun campo este vacio, para que contraseña sea igual que la confirmacion y por si el campo de la contraseña es mayor al requerido.
            try
            {
             if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(confirmarContraseña))
                { 
                    return false;
                }
             if (contraseña.Length > 50)
                {
                    return false;
                }
             if (contraseña != confirmarContraseña)
                {
                    return false;
                }
             //llamamos a la capa datos
             return objetoCD.RegistroUsuario(nombre, usuario, contraseña);
            }
            catch (Exception ) 
            {
             return false;
            }



        }


        public int IniciarSesion(String usuario, String contraseña, out string mensajeError)
        {
          mensajeError = "";
            try 
            {
             if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
                {
                    mensajeError = "Complete todos los campos correctamente";
                    return 0;
                }
                //llamo a la capa de datos con int
                int IdUsuario = objetoCD.IniciarSesion(usuario, contraseña);
             if (IdUsuario <= 0)
                {
                    mensajeError = "el usuario o la contraseña son incorrectas";
                    return 0;
                }

                     return IdUsuario;
            }

            catch (Exception ) 
            {
                mensajeError = "Error ";
                return 0;
            }
            
            return 0;
        }











}   }   


