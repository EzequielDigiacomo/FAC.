using System.Security.Cryptography;
using System.Text;

namespace FAC.API.Recursos
{
    public class Utilidades
    {
        // Metodo para encriptar clave

        public static string EncriptarClave(string password)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoding = Encoding.UTF8;

                byte[] result = hash.ComputeHash(encoding.GetBytes(password));

                foreach (byte b in result) 
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }

    }
}
