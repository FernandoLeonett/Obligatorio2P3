using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace Dominio
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }
        [Required, MaxLength(30), Index(IsUnique = true)]

        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string PasswordEncriptado { get; set; }
        public Usuario(string email, string password)
        {
            Email = email;
            Password = password;
            EncriptarContraseña();
        }
        public Usuario() { }

        public override string ToString()
        {
            return Email + " " + Password;
        }

        public static bool VerificarEmail(string email)
        {
            //Expresiones regurales utilizo para validar Email.
            bool respuesta = Regex.IsMatch(email.Trim(), "^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$");
            return respuesta;
        }

        public static bool VerificarPassword(string pass)
        {
            bool respuesta = false;
            bool contieneMay = false;
            bool contieneMin = false;
            bool contieneNum = false;
            pass = pass.Trim();
            int largoPass = pass.Length;
            if (largoPass >= 6)
            {
                int i = 0;
                while (!respuesta && i < largoPass)
                {
                    if (!int.TryParse(pass.Substring(i, 1), out int numero))
                    {
                        if (!contieneMay && pass.Substring(i, 1) == pass.Substring(i, 1).ToUpper())
                        {
                            contieneMay = true;
                        }
                        else if (!contieneMin && pass.Substring(i, 1) == pass.Substring(i, 1).ToLower())
                        {
                            contieneMin = true;
                        }
                    }
                    else if (!contieneNum)
                    {
                        contieneNum = true;
                    }
                    if (contieneNum && contieneMin && contieneMay) { respuesta = true; }
                    i++;
                }
            }
            return respuesta;
        }

        public void EncriptarContraseña()
        {
            string respuesta = string.Empty;
            //transformo la password en byte
            byte[] claveEncriptada = Encoding.Unicode.GetBytes(Password);
            //Utilizo el byte generado para luego convertilo en string base 64 para luego almacenarlo en BD
            PasswordEncriptado = Convert.ToBase64String(claveEncriptada);
        }

        public static string DesencriptarContraseña(string pass)
        {
            //realizo los pasos de manera inversa a la funcion EncriptarContraseña
            string respuesta = string.Empty;
            byte[] claveDesencriptada = Convert.FromBase64String(pass);
            respuesta = System.Text.Encoding.Unicode.GetString(claveDesencriptada);
            return respuesta;
        }






    }


}
